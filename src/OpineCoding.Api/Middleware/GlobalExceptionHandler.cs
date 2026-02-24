using Microsoft.AspNetCore.Diagnostics;
using OpineCoding.Api.Common;

namespace OpineCoding.Api.Middleware;

internal sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Unhandled exception occurred");

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        await httpContext.Response.WriteAsJsonAsync(
            new ErrorResponse("An unexpected error occurred."),
            cancellationToken: cancellationToken);

        return true;
    }
}
