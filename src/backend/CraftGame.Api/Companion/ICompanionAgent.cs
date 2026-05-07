namespace CraftGame.Api.Companion;

public interface ICompanionAgent
{
    Task<CompanionComment> GenerateCommentAsync(
        CompanionEventContext context,
        CancellationToken cancellationToken = default);
}
