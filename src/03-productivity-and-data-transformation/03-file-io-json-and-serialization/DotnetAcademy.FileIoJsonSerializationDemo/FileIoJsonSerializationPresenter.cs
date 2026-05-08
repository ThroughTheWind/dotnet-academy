namespace DotnetAcademy.FileIoJsonSerializationDemo;

public static class FileIoJsonSerializationPresenter
{
    public static IReadOnlyList<string> BuildLines(string? baseDirectory = null)
    {
        baseDirectory ??= AppContext.BaseDirectory;

        var inputFilePath = Path.Combine(baseDirectory, "seed", "study-sessions.json");
        var outputDirectory = Path.Combine(baseDirectory, "generated");
        var result = StudySessionArchiveWorkflow.RunExport(inputFilePath, outputDirectory);

        var lines = new List<string>
        {
            "Dotnet Academy: File I/O, JSON, and Serialization",
            "-----------------------------------------------",
            $"Loaded file: {Path.GetFileName(result.InputFilePath)}",
            $"Sessions loaded: {result.Sessions.Count}",
            $"Completed sessions: {result.Summary.CompletedSessions}",
            $"Total minutes: {result.Summary.TotalMinutes}",
            "Category summary:"
        };

        lines.AddRange(result.Summary.Categories.Select(category => $"- {category.Category}: {category.SessionCount} sessions, {category.TotalMinutes} min"));
        lines.Add("Generated files:");
        lines.Add($"- {Path.GetRelativePath(baseDirectory, result.SummaryFilePath)}");
        lines.Add($"- {Path.GetRelativePath(baseDirectory, result.ReportFilePath)}");
        lines.Add("Serialization note: read from disk once, shape the data in memory, and write an explicit export model back to disk.");

        return lines;
    }
}