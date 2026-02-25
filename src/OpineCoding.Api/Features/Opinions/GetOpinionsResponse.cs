namespace OpineCoding.Api.Features.Opinions;

public sealed record GetOpinionsResponse(IReadOnlyList<OpinionSection> Sections);

public sealed record OpinionSection(string Name, IReadOnlyList<string> Rules);
