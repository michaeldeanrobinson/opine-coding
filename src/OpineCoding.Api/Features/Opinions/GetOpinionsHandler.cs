namespace OpineCoding.Api.Features.Opinions;

internal static class GetOpinionsHandler
{
    internal static GetOpinionsResponse Handle()
    {
        using Stream? stream = typeof(GetOpinionsHandler).Assembly
            .GetManifestResourceStream("opine");

        if (stream is null)
        {
            return new GetOpinionsResponse([]);
        }

        using StreamReader reader = new(stream);
        string content = reader.ReadToEnd();

        return Parse(content);
    }

    private static GetOpinionsResponse Parse(string content)
    {
        List<OpinionSection> sections = [];
        string? currentSection = null;
        List<string> currentRules = [];
        bool inCodeBlock = false;

        foreach (string line in content.Split('\n'))
        {
            string trimmed = line.TrimEnd('\r');
            string stripped = trimmed.TrimStart();

            if (stripped.StartsWith("```", StringComparison.Ordinal))
            {
                inCodeBlock = !inCodeBlock;
                continue;
            }

            if (inCodeBlock)
            {
                continue;
            }

            if (trimmed.StartsWith("## ", StringComparison.Ordinal))
            {
                if (currentSection is not null)
                {
                    sections.Add(new OpinionSection(currentSection, [.. currentRules]));
                    currentRules = [];
                }

                currentSection = trimmed[3..];
            }
            else if (trimmed.StartsWith("- ", StringComparison.Ordinal) && currentSection is not null)
            {
                currentRules.Add(trimmed[2..]);
            }
        }

        if (currentSection is not null && currentRules.Count > 0)
        {
            sections.Add(new OpinionSection(currentSection, [.. currentRules]));
        }

        return new GetOpinionsResponse([.. sections]);
    }
}
