using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.ApplicationServices.Events;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Extensions.DependencyInjection;
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
    builder.Services.AddControllers();

    IConfiguration configuration = builder.Configuration;


    builder.Services.AddSingleton<CommandDispatcherDecorator, CustomCommandDecorator>();
    builder.Services.AddSingleton<QueryDispatcherDecorator, CustomQueryDecorator>();
    builder.Services.AddSingleton<EventDispatcherDecorator, CustomEventDecorator>();

    //    //zamin
    builder.Services.AddZaminApiCore("ZaminConsumer", "ZaminConsumerTemplate");
    //    //microsoft
    builder.Services.AddEndpointsApiExplorer();
    //    //zamin
    //builder.Services.AddZaminWebUserInfoService(configuration, "WebUserInfo", true);
    //builder.Services.AddZaminParrotTranslator(configuration, "ParrotTranslator");
    //builder.Services.AddNonValidatingValidator();
    //builder.Services.AddZaminMicrosoftSerializer();
    //    builder.Services.AddZaminAutoMapperProfiles(configuration, "AutoMapper");
    //    builder.Services.AddZaminInMemoryCaching();
    builder.Services.AddDbContext<DatabaseContext>(
            c => c.UseSqlServer(configuration.GetConnectionString("CommandDb_ConnectionString")));
    //.AddInterceptors(new SetPersianYeKeInterceptor(),
    //new AddAuditDataInterceptor()));
    //builder.Services.AddSwagger(configuration, "Swagger");

    var app = builder.Build();

    //    //zamin
    app.UseZaminApiExceptionHandler();
    //    //Serilog
    //app.UseSerilogRequestLogging();

    //app.UseSwaggerUI("Swagger");
    app.UseStatusCodePages();
    app.UseCors(delegate (CorsPolicyBuilder builder)
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
    });
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
});
