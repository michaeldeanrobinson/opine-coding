using OpineCoding.Api.Extensions;
using OpineCoding.Api.Middleware;
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

    builder.Services.AddProblemDetails();
    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
    builder.Services.AddHealthChecks();
    builder.Services.AddOpenApi();

    WebApplication app = builder.Build();

    app.UseExceptionHandler();

    app.MapDefaultHealthChecks()
       .MapDefaultEndpoints()
       .MapDefaultOpenApi();

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
