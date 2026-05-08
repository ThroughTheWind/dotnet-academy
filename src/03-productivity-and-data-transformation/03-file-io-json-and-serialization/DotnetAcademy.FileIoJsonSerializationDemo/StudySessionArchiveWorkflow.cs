using System.Text.Json;

namespace DotnetAcademy.FileIoJsonSerializationDemo;

public static class StudySessionArchiveWorkflow
{
    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };

    public static StudySessionExportSummary BuildSummary(IEnumerable<StudySessionRecord> sessions)
    {
        ArgumentNullException.ThrowIfNull(sessions);

        var sessionArray = sessions.ToArray();

        if (sessionArray.Length == 0)
        {
            throw new InvalidOperationException("At least one study session is required.");
        }

        var categories = sessionArray
            .GroupBy(session => session.Category)
            .OrderBy(group => group.Key, StringComparer.Ordinal)
            .Select(group => new StudySessionCategorySummary(group.Key, group.Count(), group.Sum(session => session.Minutes)))
            .ToArray();

        return new StudySessionExportSummary(
            sessionArray.Length,
            sessionArray.Count(session => session.Completed),
            sessionArray.Sum(session => session.Minutes),
            categories);
    }

    public static IReadOnlyList<string> BuildTextReportLines(StudySessionExportSummary summary)
    {
        ArgumentNullException.ThrowIfNull(summary);

        var lines = new List<string>
        {
            "Study Session Report",
            "--------------------",
            $"Total sessions: {summary.TotalSessions}",
            $"Completed sessions: {summary.CompletedSessions}",
            $"Total minutes: {summary.TotalMinutes}",
            "Category summary:"
        };

        lines.AddRange(summary.Categories.Select(category => $"- {category.Category}: {category.SessionCount} sessions, {category.TotalMinutes} min"));

        return lines;
    }

    public static IReadOnlyList<StudySessionRecord> LoadSessions(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException("An input file path is required.", nameof(filePath));
        }

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("The input file was not found.", filePath);
        }

        var json = File.ReadAllText(filePath);
        var sessions = JsonSerializer.Deserialize<StudySessionRecord[]>(json, SerializerOptions)
            ?? throw new InvalidOperationException("The input file did not contain session data.");

        if (sessions.Length == 0)
        {
            throw new InvalidOperationException("At least one study session is required.");
        }

        return sessions;
    }

    public static StudySessionExportResult RunExport(string inputFilePath, string outputDirectory)
    {
        if (string.IsNullOrWhiteSpace(outputDirectory))
        {
            throw new ArgumentException("An output directory is required.", nameof(outputDirectory));
        }

        var sessions = LoadSessions(inputFilePath).ToArray();
        var summary = BuildSummary(sessions);

        Directory.CreateDirectory(outputDirectory);

        var summaryFilePath = Path.Combine(outputDirectory, "study-session-summary.json");
        var reportFilePath = Path.Combine(outputDirectory, "study-session-report.txt");

        WriteSummaryJson(summaryFilePath, summary);
        WriteReportText(reportFilePath, BuildTextReportLines(summary));

        return new StudySessionExportResult(inputFilePath, sessions, summary, summaryFilePath, reportFilePath);
    }

    public static void WriteReportText(string filePath, IEnumerable<string> lines)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException("A report file path is required.", nameof(filePath));
        }

        ArgumentNullException.ThrowIfNull(lines);

        File.WriteAllLines(filePath, lines);
    }

    public static void WriteSummaryJson(string filePath, StudySessionExportSummary summary)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException("A summary file path is required.", nameof(filePath));
        }

        ArgumentNullException.ThrowIfNull(summary);

        var json = JsonSerializer.Serialize(summary, SerializerOptions);
        File.WriteAllText(filePath, json);
    }
}