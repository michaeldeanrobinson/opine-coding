# Developer Guide

## Adding a Feature Slice

Every feature follows the same structure. Create a folder under `Features/` and add these files:

```
Features/
  {FeatureName}/
    {FeatureName}Endpoint.cs   ← IEndpoint implementation (internal sealed)
    {FeatureName}Request.cs    ← inbound record (public)
    {FeatureName}Response.cs   ← outbound record (public)
    {FeatureName}Handler.cs    ← business logic (internal static)
```

The endpoint is discovered and registered automatically at startup — no changes to `Program.cs` or `WebApplicationExtensions` are needed.

---

## Rules

| Rule | Reason |
| :--- | :--- |
| `IEndpoint` implementation must be `internal sealed` | Slices are not public API |
| `IEndpoint` implementation must have a public parameterless constructor | `Activator.CreateInstance` is used for registration |
| Inject dependencies inside `MapEndpoint` via Minimal API parameter binding, not via constructor | Keeps the constructor parameterless; DI still works per-request |
| Request and response records are `public sealed record` | They cross the HTTP boundary |
| Handler class is `internal static class` | Business logic does not leave the slice |
| No slice may reference another slice | Use `Common/` for shared contracts or duplicate the type |

---

## Concrete Example

**`Features/GetStatus/GetStatusRequest.cs`**
```csharp
namespace OpineCoding.Api.Features.GetStatus;

public sealed record GetStatusRequest(string Version);
```

**`Features/GetStatus/GetStatusResponse.cs`**
```csharp
namespace OpineCoding.Api.Features.GetStatus;

public sealed record GetStatusResponse(string Status, string Version);
```

**`Features/GetStatus/GetStatusHandler.cs`**
```csharp
namespace OpineCoding.Api.Features.GetStatus;

internal static class GetStatusHandler
{
    internal static GetStatusResponse Handle(GetStatusRequest request)
    {
        return new("ok", request.Version);
    }
}
```

**`Features/GetStatus/GetStatusEndpoint.cs`**
```csharp
using OpineCoding.Api.Common;

namespace OpineCoding.Api.Features.GetStatus;

internal sealed class GetStatusEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/status", (string version) =>
            {
                GetStatusResponse response = GetStatusHandler.Handle(new GetStatusRequest(version));
                return Results.Ok(response);
            })
            .WithName("GetStatus")
            .Produces<GetStatusResponse>();
    }
}
```

---

## Shared Code Locations

| What | Where |
| :--- | :--- |
| Shared response contracts, pagination, error envelopes | `Common/` |
| DbContext, HTTP clients, external service wrappers | `Infrastructure/` |
| Startup wiring, health checks, favicon | `Extensions/` |
