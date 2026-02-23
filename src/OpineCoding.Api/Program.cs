using OpineCoding.Api.Extensions;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((context, services, config) => config
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .WriteTo.Console());

    builder.Services.AddHealthChecks();

    WebApplication app = builder.Build();

    app.MapDefaultHealthChecks();
    app.MapDefaultEndpoints();

    app.Run();
}
catch (Exception lastChanceException)
{
    Log.Fatal(lastChanceException, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
