using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace OpineCoding.Api.Extensions;

internal static class WebApplicationExtensions
{
    internal static WebApplication MapDefaultHealthChecks(this WebApplication app)
    {
        app.MapHealthChecks("/health");
        app.MapHealthChecks("/alive", new HealthCheckOptions { Predicate = _ => false });
        return app;
    }

    internal static WebApplication MapDefaultEndpoints(this WebApplication app)
    {
        app.MapGet("/", () => Results.Ok())
            .AllowAnonymous()
            .ExcludeFromDescription();

        app.MapGet("favicon.ico", (IWebHostEnvironment env) =>
            {
                string path = Path.Combine(env.WebRootPath, "favicon.ico");

                if (!File.Exists(path))
                {
                    return Results.NoContent();
                }

                return Results.File(path, "image/x-icon");
            })
            .AllowAnonymous()
            .ExcludeFromDescription()
            .CacheOutput(policy => policy.Expire(TimeSpan.FromDays(7)));

        return app;
    }
}
