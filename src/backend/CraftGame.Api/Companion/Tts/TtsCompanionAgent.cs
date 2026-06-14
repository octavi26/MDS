using Microsoft.Extensions.Options;

namespace CraftGame.Api.Companion.Tts;

/// <summary>
/// Wraps any <see cref="ICompanionAgent"/> and attaches a synthesized voice line
/// to the comment. If synthesis is disabled or fails, the original (text-only)
/// comment is returned unchanged so gameplay is never blocked.
/// </summary>
public sealed class TtsCompanionAgent(
    ICompanionAgent inner,
    ITtsClient ttsClient,
    IOptions<TtsClientOptions> options) : ICompanionAgent
{
    public async Task<CompanionComment> GenerateCommentAsync(
        CompanionEventContext context,
        CancellationToken cancellationToken = default)
    {
        var comment = await inner.GenerateCommentAsync(context, cancellationToken);

        var settings = options.Value;
        if (!settings.Enabled || string.IsNullOrWhiteSpace(comment.Text))
        {
            return comment;
        }

        var path = await ttsClient.SynthesizeAsync(comment.Text, cancellationToken);
        if (string.IsNullOrWhiteSpace(path))
        {
            return comment;
        }

        var url = $"{settings.PublicBaseUrl.TrimEnd('/')}{path}";
        return comment with { VoiceLineUrl = url };
    }
}
