namespace DotnetAcademy.StudyDigestPipelineLab;

public static class StudyDigestPipelinePresenter
{
    public static string GetLearnerName(string[] args)
    {
        ArgumentNullException.ThrowIfNull(args);
        return args.FirstOrDefault(static argument => !string.IsNullOrWhiteSpace(argument)) ?? "Learner";
    }

    public static async Task<IReadOnlyList<string>> BuildLinesAsync(
        string[] args,
        string? baseDirectory = null,
        IEnumerable<IStudyWorkItemSource>? sources = null,
        IEnumerable<KeyValuePair<string, string?>>? environmentOverrides = null,
        CancellationToken cancellationToken = default)
    {
        var learnerName = GetLearnerName(args);
        baseDirectory ??= AppContext.BaseDirectory;

        var settings = StudyDigestLabConfiguration.LoadSettings(baseDirectory, environmentOverrides);
        sources ??= BuildSampleSources(baseDirectory);

        var outputDirectory = Path.Combine(baseDirectory, settings.OutputFolderName);
        var exportResult = await StudyDigestPipelineWorkflow.RunExportAsync(learnerName, sources, settings, outputDirectory, cancellationToken);

        var lines = StudyDigestPipelineWorkflow.BuildReportLines(exportResult.Summary).ToList();
        lines.Add($"Output note: wrote {Path.GetFileName(exportResult.SummaryFilePath)} and {Path.GetFileName(exportResult.ReportFilePath)}.");
        lines.Add("Flow note: load file and delayed sources first, then use LINQ to shape the combined collection before writing outputs.");
        lines.Add("Design note: keep local collections mutable while gathering data, then produce sorted summaries and persisted output from one shaped view of the data.");

        return lines;
    }

    public static IReadOnlyList<IStudyWorkItemSource> BuildSampleSources(string baseDirectory)
    {
        if (string.IsNullOrWhiteSpace(baseDirectory))
        {
            throw new ArgumentException("A base directory is required.", nameof(baseDirectory));
        }

        var seedFilePath = Path.Combine(baseDirectory, "seed", "study-work-items.json");

        return
        [
            new JsonStudyWorkItemSource(seedFilePath),
            new DelayedStudyWorkItemSource(
            [
                new StudyWorkItem("Async digest", "async", "mentor queue", 3, 30),
                new StudyWorkItem("Cancellation review", "async", "mentor queue", 2, 25)
            ], 10)
        ];
    }
}