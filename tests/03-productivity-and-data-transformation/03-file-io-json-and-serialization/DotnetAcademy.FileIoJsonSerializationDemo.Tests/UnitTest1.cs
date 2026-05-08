using DotnetAcademy.FileIoJsonSerializationDemo;

namespace DotnetAcademy.FileIoJsonSerializationDemo.Tests;

public class FileIoJsonSerializationPresenterTests
{
    [Fact]
    public void LoadSessionsReadsJsonInputFromDisk()
    {
        var root = CreateTempRoot();

        try
        {
            var inputFilePath = WriteSeedFile(root);

            var sessions = StudySessionArchiveWorkflow.LoadSessions(inputFilePath);

            Assert.Equal(4, sessions.Count);
            Assert.Equal("Read text with File.ReadAllText", sessions[0].Topic);
        }
        finally
        {
            DeleteRoot(root);
        }
    }

    [Fact]
    public void BuildSummaryGroupsCategoriesAndCountsMinutes()
    {
        var sessions = CreateSeedSessions();

        var summary = StudySessionArchiveWorkflow.BuildSummary(sessions);

        Assert.Equal(4, summary.TotalSessions);
        Assert.Equal(3, summary.CompletedSessions);
        Assert.Equal(81, summary.TotalMinutes);
        Assert.Equal("file io", summary.Categories[0].Category);
        Assert.Equal(42, summary.Categories[0].TotalMinutes);
    }

    [Fact]
    public void BuildTextReportLinesIncludesCategoryBreakdown()
    {
        var summary = StudySessionArchiveWorkflow.BuildSummary(CreateSeedSessions());

        var lines = StudySessionArchiveWorkflow.BuildTextReportLines(summary);

        Assert.Contains("Study Session Report", lines);
        Assert.Contains("Category summary:", lines);
        Assert.Contains("- serialization: 1 sessions, 25 min", lines);
    }

    [Fact]
    public void RunExportWritesSummaryJsonAndReportFiles()
    {
        var root = CreateTempRoot();

        try
        {
            var inputFilePath = WriteSeedFile(root);
            var outputDirectory = Path.Combine(root, "generated");

            var result = StudySessionArchiveWorkflow.RunExport(inputFilePath, outputDirectory);

            Assert.True(File.Exists(result.SummaryFilePath));
            Assert.True(File.Exists(result.ReportFilePath));
            Assert.Contains("\"completedSessions\": 3", File.ReadAllText(result.SummaryFilePath));
            Assert.Contains("Study Session Report", File.ReadAllText(result.ReportFilePath));
        }
        finally
        {
            DeleteRoot(root);
        }
    }

    [Fact]
    public void BuildLinesIncludesGeneratedFileNamesAndSerializationNote()
    {
        var root = CreateTempRoot();

        try
        {
            WriteSeedFile(root);

            var lines = FileIoJsonSerializationPresenter.BuildLines(root);

            Assert.Contains("Loaded file: study-sessions.json", lines);
            Assert.Contains(lines, line => line.EndsWith("study-session-summary.json", StringComparison.Ordinal));
            Assert.Contains(lines, line => line.EndsWith("study-session-report.txt", StringComparison.Ordinal));
            Assert.Contains("Serialization note: read from disk once, shape the data in memory, and write an explicit export model back to disk.", lines);
        }
        finally
        {
            DeleteRoot(root);
        }
    }

    private static IReadOnlyList<StudySessionRecord> CreateSeedSessions()
    {
        return
        [
            new StudySessionRecord("SESSION-01", "Read text with File.ReadAllText", "file io", 18, completed: true),
            new StudySessionRecord("SESSION-02", "Deserialize a JSON session export", "json", 14, completed: true),
            new StudySessionRecord("SESSION-03", "Write a report file with File.WriteAllLines", "file io", 24, completed: false),
            new StudySessionRecord("SESSION-04", "Serialize summary models with JsonSerializer", "serialization", 25, completed: true)
        ];
    }

    private static string CreateTempRoot()
    {
        var root = Path.Combine(Path.GetTempPath(), "dotnet-academy-file-io-tests", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        return root;
    }

    private static void DeleteRoot(string root)
    {
        if (Directory.Exists(root))
        {
            Directory.Delete(root, recursive: true);
        }
    }

    private static string WriteSeedFile(string root)
    {
        var seedDirectory = Path.Combine(root, "seed");
        Directory.CreateDirectory(seedDirectory);

        var inputFilePath = Path.Combine(seedDirectory, "study-sessions.json");
        File.WriteAllText(
            inputFilePath,
            """
            [
              {
                "sessionId": "SESSION-01",
                "topic": "Read text with File.ReadAllText",
                "category": "file io",
                "minutes": 18,
                "completed": true
              },
              {
                "sessionId": "SESSION-02",
                "topic": "Deserialize a JSON session export",
                "category": "json",
                "minutes": 14,
                "completed": true
              },
              {
                "sessionId": "SESSION-03",
                "topic": "Write a report file with File.WriteAllLines",
                "category": "file io",
                "minutes": 24,
                "completed": false
              },
              {
                "sessionId": "SESSION-04",
                "topic": "Serialize summary models with JsonSerializer",
                "category": "serialization",
                "minutes": 25,
                "completed": true
              }
            ]
            """);

        return inputFilePath;
    }
}