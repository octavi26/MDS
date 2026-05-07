using CraftGame.Api.Companion;
using CraftGame.Api.Companion.Ollama;
using CraftGame.Api.Companion.Prompts;
using CraftGame.Api.Companion.Sanitization;

namespace CraftGame.Api.Tests.Companion;

public sealed class OllamaCompanionAgentTests
{
    private static readonly CompanionEventContext SampleContext = new(
        CompanionEventType.LevelCompleted,
        ElementName: null,
        LevelName: "Village Start",
        GoalName: "Village",
        Inventory: ["Wood", "House", "Village"],
        MoveCount: 9);

    [Fact]
    public async Task GenerateCommentAsync_ReturnsOllamaSourcedComment_WhenClientReturnsLine()
    {
        var agent = new OllamaCompanionAgent(
            new StubOllamaClient("Society has officially entered its group chat era."),
            new CompanionPromptBuilder(),
            new CompanionLineSanitizer(),
            new DeterministicCompanionAgent());

        var comment = await agent.GenerateCommentAsync(SampleContext);

        Assert.Equal("ollama", comment.Source);
        Assert.Equal("Society has officially entered its group chat era.", comment.Text);
        Assert.Equal(CompanionEventType.LevelCompleted, comment.EventType);
    }

    [Fact]
    public async Task GenerateCommentAsync_FallsBackToDeterministic_WhenClientReturnsNull()
    {
        var agent = new OllamaCompanionAgent(
            new StubOllamaClient(null),
            new CompanionPromptBuilder(),
            new CompanionLineSanitizer(),
            new DeterministicCompanionAgent());

        var comment = await agent.GenerateCommentAsync(SampleContext);

        Assert.Equal("deterministic-fallback", comment.Source);
        Assert.Equal("Village Start complete: Village. Clean work, suspiciously competent.", comment.Text);
    }

    [Fact]
    public async Task GenerateCommentAsync_FallsBackToDeterministic_WhenClientReturnsEmpty()
    {
        var agent = new OllamaCompanionAgent(
            new StubOllamaClient("   \t  \n"),
            new CompanionPromptBuilder(),
            new CompanionLineSanitizer(),
            new DeterministicCompanionAgent());

        var comment = await agent.GenerateCommentAsync(SampleContext);

        Assert.Equal("deterministic-fallback", comment.Source);
    }

    [Fact]
    public async Task GenerateCommentAsync_FallsBackToDeterministic_WhenClientThrows()
    {
        var agent = new OllamaCompanionAgent(
            new ThrowingOllamaClient(),
            new CompanionPromptBuilder(),
            new CompanionLineSanitizer(),
            new DeterministicCompanionAgent());

        var comment = await agent.GenerateCommentAsync(SampleContext);

        Assert.Equal("deterministic-fallback", comment.Source);
    }

    [Fact]
    public async Task GenerateCommentAsync_PropagatesCallerCancellation()
    {
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        var agent = new OllamaCompanionAgent(
            new ThrowingOllamaClient(),
            new CompanionPromptBuilder(),
            new CompanionLineSanitizer(),
            new DeterministicCompanionAgent());

        await Assert.ThrowsAnyAsync<OperationCanceledException>(
            () => agent.GenerateCommentAsync(SampleContext, cts.Token));
    }

    private sealed class StubOllamaClient(string? response) : IOllamaClient
    {
        public Task<string?> GenerateAsync(string prompt, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(response);
        }
    }

    private sealed class ThrowingOllamaClient : IOllamaClient
    {
        public Task<string?> GenerateAsync(string prompt, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            throw new HttpRequestException("Ollama unreachable.");
        }
    }
}
