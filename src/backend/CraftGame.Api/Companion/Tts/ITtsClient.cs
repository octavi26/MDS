namespace CraftGame.Api.Companion.Tts;

public interface ITtsClient
{
    /// <summary>
    /// Synthesizes a voice clip for <paramref name="text"/> and returns its
    /// public path (e.g. "/media/abc.wav"), or null if synthesis is unavailable.
    /// </summary>
    Task<string?> SynthesizeAsync(string text, CancellationToken cancellationToken = default);
}
