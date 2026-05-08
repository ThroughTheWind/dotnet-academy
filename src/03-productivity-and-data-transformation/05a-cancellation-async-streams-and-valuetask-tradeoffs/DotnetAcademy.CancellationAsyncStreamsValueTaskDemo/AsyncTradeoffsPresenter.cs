namespace DotnetAcademy.CancellationAsyncStreamsValueTaskDemo;

public static class AsyncTradeoffsPresenter
{
    public static async Task<IReadOnlyList<string>> BuildLinesAsync(
        DelayedStudyUpdateFeed? fullStream = null,
        DelayedStudyUpdateFeed? previewStream = null,
        IStudyRecommendationCache? cache = null)
    {
        fullStream ??= BuildSampleStream();
        previewStream ??= BuildCancellationPreviewStream();
        cache ??= BuildSampleCache();

        var updates = await AsyncTradeoffsWorkflow.CollectAsync(fullStream.ReadAllAsync());

        using var cancellationBudget = new CancellationTokenSource(millisecondsDelay: 10);
        var previewCount = await AsyncTradeoffsWorkflow.PreviewCancellationAsync(
            previewStream.ReadAllAsync(cancellationBudget.Token),
            cancellationBudget.Token);

        var focusLines = await AsyncTradeoffsWorkflow.AttachRecommendationsAsync(updates, cache);

        var lines = new List<string>
        {
            "Dotnet Academy: Cancellation, Async Streams, And ValueTask Tradeoffs",
            "-------------------------------------------------------------------",
            $"Streamed updates consumed: {updates.Count}",
            $"Pending steps: {AsyncTradeoffsWorkflow.SumPendingSteps(updates)}",
            $"Cancellation preview: stopped after {previewCount} streamed updates when the time budget expired.",
            "Focus modules:"
        };

        lines.AddRange(AsyncTradeoffsWorkflow.BuildFocusLines(focusLines));
        lines.Add("Cancellation note: pass the same token through producers and consumers so the work can stop cleanly.");
        lines.Add("Async stream note: use await foreach when values arrive over time instead of buffering everything up front.");
        lines.Add("ValueTask note: keep Task as the default and reach for ValueTask only when profiling shows lots of synchronous completions, such as cache hits.");

        return lines;
    }

    public static DelayedStudyUpdateFeed BuildSampleStream()
    {
        return new DelayedStudyUpdateFeed(
        [
            new ScheduledStudyUpdate(new StudyUpdate("Async streams", "mentor digest", 2), 2),
            new ScheduledStudyUpdate(new StudyUpdate("Cancellation", "live planner", 3), 2),
            new ScheduledStudyUpdate(new StudyUpdate("Configuration reload", "settings watcher", 2), 2),
            new ScheduledStudyUpdate(new StudyUpdate("ValueTask", "cache profiler", 1), 2)
        ]);
    }

    public static DelayedStudyUpdateFeed BuildCancellationPreviewStream()
    {
        return new DelayedStudyUpdateFeed(
        [
            new ScheduledStudyUpdate(new StudyUpdate("Preview one", "preview feed", 1), 0),
            new ScheduledStudyUpdate(new StudyUpdate("Preview two", "preview feed", 1), 0),
            new ScheduledStudyUpdate(new StudyUpdate("Preview three", "preview feed", 1), 50)
        ]);
    }

    public static IStudyRecommendationCache BuildSampleCache()
    {
        return new StudyRecommendationCache(new Dictionary<string, string>
        {
            ["Async streams"] = "practice await foreach over IAsyncEnumerable<T> when results arrive gradually",
            ["Cancellation"] = "propagate the token through each awaited boundary that can stop early",
            ["Configuration reload"] = "cancel stale work before starting the next configuration pass"
        });
    }
}