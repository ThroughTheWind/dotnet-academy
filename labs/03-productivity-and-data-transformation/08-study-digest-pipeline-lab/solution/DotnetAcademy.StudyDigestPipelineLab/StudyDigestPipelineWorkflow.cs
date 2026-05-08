using System.Text.Json;

namespace DotnetAcademy.StudyDigestPipelineLab;

public static class StudyDigestPipelineWorkflow
{
    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };

    public static StudyDigestSummary BuildSummary(string learnerName, IEnumerable<StudyWorkItem> items, StudyDigestSettings settings)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(learnerName);
        ArgumentNullException.ThrowIfNull(items);
        ArgumentNullException.ThrowIfNull(settings);

        settings.Validate();

        var itemArray = items.ToArray();

        if (itemArray.Length == 0)
        {
            throw new InvalidOperationException("At least one study work item is required.");
        }

        var focusItems = itemArray
            .Where(item => item.PendingSteps >= settings.MinimumPendingSteps)
            .OrderByDescending(item => item.PendingSteps)
            .ThenByDescending(item => item.Minutes)
            .ThenBy(item => item.ModuleName, StringComparer.Ordinal)
            .ToArray();

        var categories = itemArray
            .GroupBy(item => item.Category, StringComparer.OrdinalIgnoreCase)
            .OrderBy(group => group.Key, StringComparer.Ordinal)
            .Select(group => new StudyCategorySummary(
                group.Key,
                group.Count(),
                group.Sum(item => item.PendingSteps),
                group.Sum(item => item.Minutes)))
            .ToArray();

        return new StudyDigestSummary(
            learnerName,
            itemArray.Length,
            focusItems.Length,
            itemArray.Sum(item => item.Minutes),
            categories,
            focusItems);
    }

    public static IReadOnlyList<string> BuildReportLines(StudyDigestSummary summary)
    {
        ArgumentNullException.ThrowIfNull(summary);

        var lines = new List<string>
        {
            "Study Digest Pipeline Lab",
            "-------------------------",
            $"Learner: {summary.LearnerName}",
            $"Items loaded: {summary.TotalItems}",
            $"Focus items: {summary.FocusItemCount}",
            $"Total minutes: {summary.TotalMinutes}",
            "Category summary:"
        };

        lines.AddRange(summary.Categories.Select(category =>
            $"- {category.Category}: {category.ItemCount} items, {category.TotalPendingSteps} pending steps, {category.TotalMinutes} min"));

        lines.Add("Focus list:");
        lines.AddRange(summary.FocusItems.Select(item =>
            $"- {item.ModuleName} [{item.Category}] from {item.SourceName}: {item.PendingSteps} pending {FormatPendingLabel(item.PendingSteps)}, {item.Minutes} min"));

        return lines;
    }

    public static async Task<IReadOnlyList<StudyWorkItem>> LoadAllAsync(
        IEnumerable<IStudyWorkItemSource> sources,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(sources);

        var sourceArray = sources.ToArray();

        if (sourceArray.Length == 0)
        {
            throw new InvalidOperationException("At least one study work item source is required.");
        }

        var tasks = sourceArray.Select(source => source.LoadAsync(cancellationToken)).ToArray();
        var batches = await Task.WhenAll(tasks);

        return batches
            .SelectMany(batch => batch)
            .OrderBy(item => item.Category, StringComparer.Ordinal)
            .ThenByDescending(item => item.PendingSteps)
            .ThenBy(item => item.ModuleName, StringComparer.Ordinal)
            .ToArray();
    }

    public static async Task<StudyDigestExportResult> RunExportAsync(
        string learnerName,
        IEnumerable<IStudyWorkItemSource> sources,
        StudyDigestSettings settings,
        string outputDirectory,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(outputDirectory))
        {
            throw new ArgumentException("An output directory is required.", nameof(outputDirectory));
        }

        var items = await LoadAllAsync(sources, cancellationToken);
        var summary = BuildSummary(learnerName, items, settings);

        Directory.CreateDirectory(outputDirectory);

        var summaryFilePath = Path.Combine(outputDirectory, "study-digest-summary.json");
        var reportFilePath = Path.Combine(outputDirectory, "study-digest-report.txt");

        await WriteSummaryJsonAsync(summaryFilePath, summary, cancellationToken);
        await WriteReportTextAsync(reportFilePath, BuildReportLines(summary), cancellationToken);

        return new StudyDigestExportResult(summary, summaryFilePath, reportFilePath);
    }

    public static async Task WriteReportTextAsync(string filePath, IEnumerable<string> lines, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException("A report file path is required.", nameof(filePath));
        }

        ArgumentNullException.ThrowIfNull(lines);

        await File.WriteAllLinesAsync(filePath, lines, cancellationToken);
    }

    public static async Task WriteSummaryJsonAsync(string filePath, StudyDigestSummary summary, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException("A summary file path is required.", nameof(filePath));
        }

        ArgumentNullException.ThrowIfNull(summary);

        var json = JsonSerializer.Serialize(summary, SerializerOptions);
        await File.WriteAllTextAsync(filePath, json, cancellationToken);
    }

    private static string FormatPendingLabel(int pendingSteps)
    {
        return pendingSteps == 1 ? "step" : "steps";
    }
}