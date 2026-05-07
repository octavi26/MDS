namespace CraftGame.Api.Companion.Prompts;

public interface ICompanionPromptBuilder
{
    string BuildPrompt(CompanionEventContext context);
}
