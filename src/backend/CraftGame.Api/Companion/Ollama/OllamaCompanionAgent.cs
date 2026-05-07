using CraftGame.Api.Companion.Prompts;
using CraftGame.Api.Companion.Sanitization;

namespace CraftGame.Api.Companion.Ollama;

public sealed class OllamaCompanionAgent(
    IOllamaClient ollamaClient,
    ICompanionPromptBuilder promptBuilder,
    ICompanionLineSanitizer lineSanitizer,
    DeterministicCompanionAgent fallbackAgent) : ICompanionAgent
{
    private const string Source = "ollama";

    public async Task<CompanionComment> GenerateCommentAsync(
        CompanionEventContext context,
        CancellationToken cancellationToken = default)
    {
        var prompt = promptBuilder.BuildPrompt(context);

        string? rawLine;
        try
        {
            rawLine = await ollamaClient.GenerateAsync(prompt, cancellationToken);
        }
        catch (Exception ex) when (ex is not OperationCanceledException || !cancellationToken.IsCancellationRequested)
        {
            rawLine = null;
        }

        var line = lineSanitizer.Sanitize(rawLine);

        if (line is null)
        {
            return await fallbackAgent.GenerateCommentAsync(context, cancellationToken);
        }

        return new CompanionComment(
            line,
            context.EventType,
            Source,
            VoiceLineUrl: null);
    }
}
