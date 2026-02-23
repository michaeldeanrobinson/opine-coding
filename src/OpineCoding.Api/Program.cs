using OpineCoding.Api.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();

WebApplication app = builder.Build();

app.MapDefaultHealthChecks();
app.MapDefaultEndpoints();

app.Run();
