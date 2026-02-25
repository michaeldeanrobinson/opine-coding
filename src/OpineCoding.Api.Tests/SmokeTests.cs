using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace OpineCoding.Api.Tests;

public sealed class SmokeTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Theory]
    [InlineData("/health", HttpStatusCode.OK)]
    [InlineData("/alive", HttpStatusCode.OK)]
    [InlineData("/opinions", HttpStatusCode.OK)]
    public async Task Get_ReturnsExpectedStatus(string path, HttpStatusCode expected)
    {
        HttpResponseMessage response = await _client.GetAsync(path);

        Assert.Equal(expected, response.StatusCode);
    }
}
