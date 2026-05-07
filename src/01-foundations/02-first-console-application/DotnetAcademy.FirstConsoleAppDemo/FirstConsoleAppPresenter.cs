namespace DotnetAcademy.FirstConsoleAppDemo;

public static class FirstConsoleAppPresenter
{
    public static IReadOnlyList<string> BuildLines(string[] args)
    {
        var learnerName = args.Length > 0 && !string.IsNullOrWhiteSpace(args[0])
            ? args[0].Trim()
            : "learner";

        return new[]
        {
            "Dotnet Academy: First Console Application",
            "-----------------------------------------",
            $"Hello, {learnerName}!",
            "This demo shows a minimal console app built with top-level statements.",
            "Program.cs is the entry point for this project.",
            "Use `dotnet run -- Ada` to pass a name to the app."
        };
    }
}
