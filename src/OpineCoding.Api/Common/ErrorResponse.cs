using System.Text.Json.Serialization;

namespace OpineCoding.Api.Common;

public sealed record ErrorResponse([property: JsonPropertyName("error")] string Error);
