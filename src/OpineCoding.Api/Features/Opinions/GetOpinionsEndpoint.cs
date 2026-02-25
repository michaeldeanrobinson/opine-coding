using OpineCoding.Api.Common;

namespace OpineCoding.Api.Features.Opinions;

internal sealed class GetOpinionsEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/opinions", () => Results.Ok(GetOpinionsHandler.Handle()))
            .WithName("GetOpinions")
            .Produces<GetOpinionsResponse>();
    }
}
