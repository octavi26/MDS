using System.Text.RegularExpressions;

namespace CraftGame.Api.Companion.Sanitization;

public sealed partial class CompanionLineSanitizer : ICompanionLineSanitizer
{
    private const int MaxLength = 120;

    public string? Sanitize(string? line)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            return null;
        }

        var normalized = WhitespaceRegex().Replace(line.Trim(), " ");
        normalized = normalized.Trim('"', '\'', '`', ' ', '\t');

        if (string.IsNullOrWhiteSpace(normalized))
        {
            return null;
        }

        var firstSentence = FirstSentenceRegex().Match(normalized);
        if (firstSentence.Success)
        {
            normalized = firstSentence.Value.Trim();
        }

        if (normalized.Length <= MaxLength)
        {
            return normalized;
        }

        var shortened = normalized[..MaxLength].TrimEnd();
        var lastSpace = shortened.LastIndexOf(' ');

        if (lastSpace > 40)
        {
            shortened = shortened[..lastSpace];
        }

        return shortened.TrimEnd('.', ',', ';', ':') + ".";
    }

    [GeneratedRegex(@"\s+")]
    private static partial Regex WhitespaceRegex();

    [GeneratedRegex(@"^.+?[.!?](?=\s|$)")]
    private static partial Regex FirstSentenceRegex();
}
