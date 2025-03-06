using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Configuration;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.ApplicationServices.Events;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.Domain.Toolkits.ValueObjects;
using Zamin.Extensions.DependencyInjection;
using Zamin.Infra.Data.Sql.Commands.Interceptors;
using Zamin.Utilities.SerilogRegistration.Extensions;
using Zamin.Utilities.Swagger.Registration.Options;
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
    //builder.Services.AddControllers();

    builder.Services.AddSingleton<CommandDispatcherDecorator, CustomCommandDecorator>();
    builder.Services.AddSingleton<QueryDispatcherDecorator, CustomQueryDecorator>();
    builder.Services.AddSingleton<EventDispatcherDecorator, CustomEventDecorator>();

    builder.Services.AddZaminApiCore("ZaminConsumer");
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddZaminWebUserInfoService(builder.Configuration, "WebUserInfo", true);
    builder.Services.AddZaminParrotTranslator(builder.Configuration, "ParrotTranslator");
    //builder.Services.AddNonValidatingValidator();
    builder.Services.AddZaminMicrosoftSerializer();
    builder.Services.AddZaminAutoMapperProfiles(builder.Configuration, "AutoMapper");
    builder.Services.AddZaminInMemoryCaching();
    builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ZaminConsumer"))
    .AddInterceptors(new SetPersianYeKeInterceptor(), new AddAuditDataInterceptor()));

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

    app.Run();
});
