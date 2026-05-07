using System.Net;
using System.Text;
using System.Text.Json;
using CraftGame.Api.Companion;
using CraftGame.Api.Companion.Ollama;
using Microsoft.Extensions.Options;

namespace CraftGame.Api.Tests.Companion;

public sealed class OllamaClientTests
{
    private const string Prompt = "say something witty";

    [Fact]
    public async Task GenerateAsync_ReturnsTrimmedResponse_WhenRequestSucceeds()
    {
        var handler = new StubHttpMessageHandler(_ => JsonResponse(new { response = "  A short, dry line.  " }));
        var client = BuildClient(handler);

        var result = await client.GenerateAsync(Prompt);

        Assert.Equal("A short, dry line.", result);
        Assert.Single(handler.Requests);

        var request = handler.Requests[0];
        Assert.Equal(HttpMethod.Post, request.Method);
        Assert.NotNull(request.RequestUri);
        Assert.EndsWith("/api/generate", request.RequestUri!.AbsolutePath);

        Assert.NotNull(handler.RequestBodies[0]);
        var payload = JsonDocument.Parse(handler.RequestBodies[0]!).RootElement;
        Assert.Equal("test-model", payload.GetProperty("model").GetString());
        Assert.Equal(Prompt, payload.GetProperty("prompt").GetString());
        Assert.False(payload.GetProperty("stream").GetBoolean());
    }

    [Fact]
    public async Task GenerateAsync_ReturnsNull_OnHttpErrorStatus()
    {
        var handler = new StubHttpMessageHandler(_ => new HttpResponseMessage(HttpStatusCode.InternalServerError));
        var client = BuildClient(handler);

        var result = await client.GenerateAsync(Prompt);

        Assert.Null(result);
    }

    [Fact]
    public async Task GenerateAsync_ReturnsNull_WhenResponseFieldIsEmpty()
    {
        var handler = new StubHttpMessageHandler(_ => JsonResponse(new { response = "   " }));
        var client = BuildClient(handler);

        var result = await client.GenerateAsync(Prompt);

        Assert.Null(result);
    }

    [Fact]
    public async Task GenerateAsync_ReturnsNull_WhenResponseFieldIsMissing()
    {
        var handler = new StubHttpMessageHandler(_ => JsonResponse(new { other = "ignored" }));
        var client = BuildClient(handler);

        var result = await client.GenerateAsync(Prompt);

        Assert.Null(result);
    }

    [Fact]
    public async Task GenerateAsync_ReturnsNull_OnInvalidJson()
    {
        var handler = new StubHttpMessageHandler(_ => new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent("not-json", Encoding.UTF8, "application/json")
        });
        var client = BuildClient(handler);

        var result = await client.GenerateAsync(Prompt);

        Assert.Null(result);
    }

    [Fact]
    public async Task GenerateAsync_ReturnsNull_OnTransportException()
    {
        var handler = new StubHttpMessageHandler(_ => throw new HttpRequestException("connection refused"));
        var client = BuildClient(handler);

        var result = await client.GenerateAsync(Prompt);

        Assert.Null(result);
    }

    [Fact]
    public async Task GenerateAsync_ReturnsNull_OnInternalTimeout()
    {
        var handler = new StubHttpMessageHandler(async (_, token) =>
        {
            await Task.Delay(Timeout.Infinite, token);
            return new HttpResponseMessage(HttpStatusCode.OK);
        });
        var client = BuildClient(handler, timeoutSeconds: 1);

        var result = await client.GenerateAsync(Prompt);

        Assert.Null(result);
    }

    [Fact]
    public async Task GenerateAsync_PropagatesCallerCancellation()
    {
        var handler = new StubHttpMessageHandler(async (_, token) =>
        {
            await Task.Delay(Timeout.Infinite, token);
            return new HttpResponseMessage(HttpStatusCode.OK);
        });
        var client = BuildClient(handler);

        using var cts = new CancellationTokenSource();
        var task = client.GenerateAsync(Prompt, cts.Token);
        cts.Cancel();

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => task);
    }

    [Fact]
    public async Task GenerateAsync_ReturnsNull_ForBlankPrompt()
    {
        var handler = new StubHttpMessageHandler(_ => JsonResponse(new { response = "ignored" }));
        var client = BuildClient(handler);

        var result = await client.GenerateAsync("   ");

        Assert.Null(result);
        Assert.Empty(handler.Requests);
    }

    private static OllamaClient BuildClient(StubHttpMessageHandler handler, int timeoutSeconds = 10)
    {
        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("http://ollama.test/")
        };

        var options = Microsoft.Extensions.Options.Options.Create(new CompanionAgentOptions
        {
            Enabled = true,
            Provider = CompanionAgentProviders.Ollama,
            OllamaBaseUrl = "http://ollama.test",
            OllamaModel = "test-model",
            TimeoutSeconds = timeoutSeconds
        });

        return new OllamaClient(httpClient, options);
    }

    private static HttpResponseMessage JsonResponse(object payload)
    {
        var json = JsonSerializer.Serialize(payload);
        return new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };
    }

    private sealed class StubHttpMessageHandler : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> _responder;

        public List<HttpRequestMessage> Requests { get; } = new();
        public List<string?> RequestBodies { get; } = new();

        public StubHttpMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> responder)
        {
            _responder = (request, _) => Task.FromResult(responder(request));
        }

        public StubHttpMessageHandler(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> responder)
        {
            _responder = responder;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            Requests.Add(request);
            RequestBodies.Add(request.Content is null
                ? null
                : await request.Content.ReadAsStringAsync(cancellationToken));

            return await _responder(request, cancellationToken);
        }
    }
}
