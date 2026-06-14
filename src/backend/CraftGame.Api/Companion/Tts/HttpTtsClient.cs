using System.Net.Http.Json;

namespace CraftGame.Api.Companion.Tts;

public sealed class HttpTtsClient(HttpClient httpClient) : ITtsClient
{
    public async Task<string?> SynthesizeAsync(string text, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return null;
        }

        try
        {
            var response = await httpClient.PostAsJsonAsync("tts", new TtsRequest(text), cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var payload = await response.Content.ReadFromJsonAsync<TtsResponse>(cancellationToken: cancellationToken);
            return string.IsNullOrWhiteSpace(payload?.Url) ? null : payload.Url;
        }
        catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
        {
            return null;
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    private sealed record TtsRequest(string Text);

    private sealed record TtsResponse(string? Url);
}
