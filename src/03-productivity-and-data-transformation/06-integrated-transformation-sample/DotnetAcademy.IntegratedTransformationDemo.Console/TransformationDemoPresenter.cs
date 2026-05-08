using DotnetAcademy.IntegratedTransformationDemo;

namespace DotnetAcademy.IntegratedTransformationDemo.Console;

public static class TransformationDemoPresenter
{
    public static async Task<IReadOnlyList<string>> BuildLinesAsync(
        string? baseDirectory = null,
        string? outputRootDirectory = null,
        IEnumerable<IStudyWorkItemSource>? sources = null,
        IEnumerable<KeyValuePair<string, string?>>? environmentOverrides = null,
        CancellationToken cancellationToken = default)
    {
        baseDirectory ??= AppContext.BaseDirectory;
        outputRootDirectory ??= baseDirectory;

        var settings = TransformationDemoConfiguration.LoadSettings(baseDirectory, environmentOverrides);
        sources ??= BuildSampleSources(baseDirectory);

        var outputDirectory = Path.Combine(outputRootDirectory, settings.OutputFolderName);
        var exportResult = await IntegratedTransformationWorkflow.RunExportAsync(sources, settings, outputDirectory, cancellationToken);

        var lines = new List<string>
        {
            "Dotnet Academy: Integrated Transformation Demo",
            "----------------------------------------------",
            $"Items loaded: {exportResult.Items.Count}",
            $"Focus items: {exportResult.Summary.FocusItemCount}",
            $"Total pending steps: {exportResult.Summary.TotalPendingSteps}",
            $"Output summary: {Path.GetFileName(exportResult.SummaryFilePath)}",
            $"Output report: {Path.GetFileName(exportResult.ReportFilePath)}",
            "Focus modules:"
        };

        lines.AddRange(IntegratedTransformationWorkflow.BuildFocusLines(exportResult.Summary.FocusItems));
        lines.Add("Integration note: keep configuration, source loading, transformation, and file output in separate seams so the workflow stays testable.");

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
            new JsonFileStudyWorkItemSource(seedFilePath),
            new StaticStudyWorkItemSource(
            [
                new StudyWorkItem("Configuration layering", "platform", "planner board", 2, 35),
                new StudyWorkItem("Frozen lookup review", "analysis", "planner board", 1, 20)
            ]),
            new StreamingStudyWorkItemSource(
                new DelayedStudyWorkItemFeed(
                [
                    new ScheduledStudyWorkItem(new StudyWorkItem("Async digest", "async", "mentor digest", 3, 30), 2),
                    new ScheduledStudyWorkItem(new StudyWorkItem("Cancellation drill", "async", "mentor digest", 2, 35), 2)
                ]).ReadAllAsync(cancellationToken: default))
        ];
    }
}