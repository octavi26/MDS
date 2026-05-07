using CraftGame.Api.Companion.Sanitization;

namespace CraftGame.Api.Tests.Companion;

public sealed class CompanionLineSanitizerTests
{
    [Fact]
    public void Sanitize_ReturnsNull_ForEmptyOutput()
    {
        var sanitizer = new CompanionLineSanitizer();

        Assert.Null(sanitizer.Sanitize("   "));
    }

    [Fact]
    public void Sanitize_CollapsesWhitespaceAndRemovesQuotes()
    {
        var sanitizer = new CompanionLineSanitizer();

        var line = sanitizer.Sanitize("\"Steam.\nHumanity found the kettle button.\"");

        Assert.Equal("Steam.", line);
    }

    [Fact]
    public void Sanitize_KeepsOnlyFirstSentence()
    {
        var sanitizer = new CompanionLineSanitizer();

        var line = sanitizer.Sanitize("Village complete. Please ignore the civic paperwork.");

        Assert.Equal("Village complete.", line);
    }

    [Fact]
    public void Sanitize_TrimsLongOutput()
    {
        var sanitizer = new CompanionLineSanitizer();
        var raw = "This discovery is so impressively overcomplicated that even the tutorial is quietly applying for hazard pay and a better chair.";

        var line = sanitizer.Sanitize(raw);

        Assert.NotNull(line);
        Assert.True(line.Length <= 120);
        Assert.EndsWith(".", line);
    }
}
