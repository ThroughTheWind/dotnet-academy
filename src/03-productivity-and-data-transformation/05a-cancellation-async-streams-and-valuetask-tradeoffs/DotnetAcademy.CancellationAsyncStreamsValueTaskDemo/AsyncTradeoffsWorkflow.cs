namespace DotnetAcademy.CancellationAsyncStreamsValueTaskDemo;

public static class AsyncTradeoffsWorkflow
{
    public static async Task<IReadOnlyList<StudyUpdate>> CollectAsync(IAsyncEnumerable<StudyUpdate> updates, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(updates);

        var collected = new List<StudyUpdate>();

        await foreach (var update in updates.WithCancellation(cancellationToken))
        {
            collected.Add(update);
        }

        return collected;
    }

    public static async Task<int> PreviewCancellationAsync(IAsyncEnumerable<StudyUpdate> updates, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(updates);

        var consumedCount = 0;

        try
        {
            await foreach (var update in updates.WithCancellation(cancellationToken))
            {
                _ = update;
                consumedCount++;
            }
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            return consumedCount;
        }

        return consumedCount;
    }

    public static async Task<IReadOnlyList<RecommendedStudyUpdate>> AttachRecommendationsAsync(
        IEnumerable<StudyUpdate> updates,
        IStudyRecommendationCache cache,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(updates);
        ArgumentNullException.ThrowIfNull(cache);

        var recommendedUpdates = new List<RecommendedStudyUpdate>();

        foreach (var update in updates
            .OrderByDescending(update => update.PendingSteps)
            .ThenBy(update => update.ModuleName))
        {
            var recommendation = await cache.GetRecommendationAsync(update.ModuleName, cancellationToken);

            recommendedUpdates.Add(new RecommendedStudyUpdate(
                update.ModuleName,
                update.SourceName,
                update.PendingSteps,
                recommendation));
        }

        return recommendedUpdates;
    }

    public static IReadOnlyList<string> BuildFocusLines(IEnumerable<RecommendedStudyUpdate> updates)
    {
        ArgumentNullException.ThrowIfNull(updates);

        return updates
            .Select(update =>
                $"- {update.ModuleName}: {update.PendingSteps} pending {FormatPendingLabel(update.PendingSteps)} from {update.SourceName} ({FormatRecommendationMode(update.Recommendation.WasCached)}: {update.Recommendation.Text})")
            .ToList();
    }

    public static int SumPendingSteps(IEnumerable<StudyUpdate> updates)
    {
        ArgumentNullException.ThrowIfNull(updates);
        return updates.Sum(update => update.PendingSteps);
    }

    private static string FormatPendingLabel(int pendingSteps)
    {
        return pendingSteps == 1 ? "step" : "steps";
    }

    private static string FormatRecommendationMode(bool wasCached)
    {
        return wasCached ? "cache hit" : "async fallback";
    }
}