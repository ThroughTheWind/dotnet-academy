namespace DotnetAcademy.NullabilityDebuggingDemo;

public static class NullabilityDebuggingPresenter
{
    public static IReadOnlyList<string> BuildLines(string? mentorName, string? recentWarning, bool shouldDebugToday)
    {
        var lines = new List<string>
        {
            "Dotnet Academy: Nullability And Debugging Basics",
            "-----------------------------------------------",
            $"mentorName raw state: {FormatOptionalValue(mentorName)}",
            $"mentor display: {GetMentorDisplayName(mentorName)}",
            $"recent warning: {GetWarningDisplay(recentWarning)}",
            $"safe fallback tip: {GetFallbackTip(mentorName)}",
            "Debugging checklist:"
        };

        lines.AddRange(BuildDebuggingChecklist(shouldDebugToday));
        return lines;
    }

    public static string GetMentorDisplayName(string? mentorName)
    {
        return string.IsNullOrWhiteSpace(mentorName)
            ? "no mentor assigned"
            : mentorName.Trim();
    }

    public static string GetWarningDisplay(string? recentWarning)
    {
        return string.IsNullOrWhiteSpace(recentWarning)
            ? "no warning message recorded"
            : recentWarning.Trim();
    }

    public static string GetFallbackTip(string? mentorName)
    {
        return mentorName is null
            ? "Use ?? or a null check before relying on optional text values."
            : "The value is present, so the app can use it directly after validation.";
    }

    public static IReadOnlyList<string> BuildDebuggingChecklist(bool shouldDebugToday)
    {
        var lines = new List<string>
        {
            "- Reproduce the behavior with the same input.",
            "- Inspect the current variable values before the suspicious line."
        };

        lines.Add(shouldDebugToday
            ? "- Step through the code or add temporary output to confirm where the value changed."
            : "- If the issue disappears, rerun with the same data before changing the code.");

        return lines;
    }

    private static string FormatOptionalValue(string? value)
    {
        return value is null ? "<null>" : value;
    }
}
