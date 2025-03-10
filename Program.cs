using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerUI;
using Zamin.Extensions.DependencyInjection;
using Zamin.Infra.Data.Sql.Commands.Interceptors;
using Zamin.Utilities.SerilogRegistration.Extensions;
using ZaminConsumer.Utilities;

SerilogExtensions.RunWithSerilogExceptionHandling(() =>
{
    var builder = WebApplication.CreateBuilder(args);
    builder = builder.AddZaminSerilog(o =>
    {
        o.ApplicationName = builder.Configuration.GetValue<string>("ApplicationName");
        o.ServiceId = builder.Configuration.GetValue<string>("ServiceId");
        o.ServiceName = builder.Configuration.GetValue<string>("ServiceName");
        o.ServiceVersion = builder.Configuration.GetValue<string>("ServiceVersion");
    });
    //builder.Services.AddSingleton<CommandDispatcherDecorator, CustomCommandDecorator>(); // TODO: Need to Learn more
    //builder.Services.AddSingleton<QueryDispatcherDecorator, CustomQueryDecorator>(); // TODO: Need to Learn more
    //builder.Services.AddSingleton<EventDispatcherDecorator, CustomEventDecorator>(); // TODO: Need to Learn more

    builder.Services.AddControllers();
    builder.Services.AddZaminApiCore("ZaminConsumer");
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddZaminWebUserInfoService(builder.Configuration, "WebUserInfo", true);
    builder.Services.AddZaminParrotTranslator(builder.Configuration, "ParrotTranslator"); // TODO: Need to Learn more
    //builder.Services.AddNonValidatingValidator();
    builder.Services.AddZaminMicrosoftSerializer();
    builder.Services.AddZaminAutoMapperProfiles(builder.Configuration, "AutoMapper");
    builder.Services.AddZaminInMemoryCaching();
    builder.Services.AddDbContext<CommandDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ZaminConsumer"))
    .AddInterceptors(new SetPersianYeKeInterceptor(), new AddAuditDataInterceptor()));

    builder.Services.AddDbContext<QueryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ZaminConsumer")));

    var swaggerOption = builder.Configuration.GetSection("Swagger");
    if (swaggerOption != null && swaggerOption.GetValue<bool>("Enabled") == true)
        builder.Services.AddSwaggerGen(o =>
        {
            o.SwaggerDoc(swaggerOption.GetValue<string>("Name"), new OpenApiInfo
            {
                Title = swaggerOption.GetValue<string>("Title"),
                Version = swaggerOption.GetValue<string>("Version")
            });
        });

    var app = builder.Build();

    if (app.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();

    app.UseZaminApiExceptionHandler();
    app.UseSerilogRequestLogging();
    if (swaggerOption != null && swaggerOption.GetValue<bool>("Enabled") == true)
    {
        app.UseSwagger();
        app.UseSwaggerUI(option =>
        {
            option.DocExpansion(DocExpansion.None);
            option.SwaggerEndpoint(swaggerOption.GetValue<string>("URL"), swaggerOption.GetValue<string>("Title"));
            option.RoutePrefix = string.Empty;
            option.OAuthUsePkce();
        });
    }

    app.UseRouting();
    app.UseStatusCodePages();
    app.UseCors(delegate (CorsPolicyBuilder builder)
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
    });
    app.UseHttpsRedirection();
    //app.UseAuthorization();
    app.MapControllers();

    //app.UseEndpoints(endpoints => endpoints.MapControllers());
    app.Run();
});
