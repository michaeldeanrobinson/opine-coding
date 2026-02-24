using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using OpineCoding.Api.Common;

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
                if (String.IsNullOrEmpty(env.WebRootPath))
                {
                    return Results.NoContent();
                }

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

        IEnumerable<IEndpoint> endpoints = typeof(IEndpoint).Assembly
            .GetTypes()
            .Where(t => t is { IsAbstract: false, IsInterface: false } && t.IsAssignableTo(typeof(IEndpoint)))
            .Select(t => Activator.CreateInstance(t) as IEndpoint)
            .OfType<IEndpoint>();

        foreach (IEndpoint endpoint in endpoints)
        {
            endpoint.MapEndpoint(app);
        }

        return app;
    }
}
