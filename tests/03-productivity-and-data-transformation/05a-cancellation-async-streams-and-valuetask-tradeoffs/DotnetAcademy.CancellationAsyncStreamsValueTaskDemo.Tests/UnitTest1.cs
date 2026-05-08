using System.Runtime.CompilerServices;
using DotnetAcademy.CancellationAsyncStreamsValueTaskDemo;

namespace DotnetAcademy.CancellationAsyncStreamsValueTaskDemo.Tests;

public class AsyncTradeoffsPresenterTests
{
    [Fact]
    public async Task CollectAsyncReturnsAllStreamedUpdates()
    {
        var stream = new DelayedStudyUpdateFeed(
        [
            new ScheduledStudyUpdate(new StudyUpdate("Async streams", "mentor digest", 2), 0),
            new ScheduledStudyUpdate(new StudyUpdate("Cancellation", "live planner", 3), 0)
        ]);

        var updates = await AsyncTradeoffsWorkflow.CollectAsync(stream.ReadAllAsync());

        Assert.Equal(2, updates.Count);
        Assert.Contains(updates, update => update.ModuleName == "Async streams");
        Assert.Contains(updates, update => update.SourceName == "live planner");
    }

    [Fact]
    public async Task PreviewCancellationAsyncReturnsConsumedItemsBeforeCancellation()
    {
        using var cancellationSource = new CancellationTokenSource();

        var consumedCount = await AsyncTradeoffsWorkflow.PreviewCancellationAsync(CreateCancelingStream(cancellationSource), cancellationSource.Token);

        Assert.Equal(2, consumedCount);
    }

    [Fact]
    public async Task GetRecommendationAsyncCompletesSynchronouslyForCacheHit()
    {
        var cache = new StudyRecommendationCache(new Dictionary<string, string>
        {
            ["Cancellation"] = "propagate the token"
        });

        var recommendationTask = cache.GetRecommendationAsync("Cancellation");

        Assert.True(recommendationTask.IsCompletedSuccessfully);

        var recommendation = await recommendationTask;

        Assert.True(recommendation.WasCached);
        Assert.Equal("propagate the token", recommendation.Text);
    }

    [Fact]
    public async Task GetRecommendationAsyncUsesAsyncFallbackForCacheMiss()
    {
        var cache = new StudyRecommendationCache(new Dictionary<string, string>(), fallbackDelayMilliseconds: 5);

        var recommendationTask = cache.GetRecommendationAsync("ValueTask");

        Assert.False(recommendationTask.IsCompletedSuccessfully);

        var recommendation = await recommendationTask;

        Assert.False(recommendation.WasCached);
        Assert.Equal("profile before replacing Task with ValueTask; keep the API simple until repeated synchronous completion is common", recommendation.Text);
    }

    [Fact]
    public async Task BuildLinesAsyncIncludesStreamingCancellationAndValueTaskGuidance()
    {
        var lines = await AsyncTradeoffsPresenter.BuildLinesAsync();

        Assert.Contains("Streamed updates consumed: 4", lines);
        Assert.Contains("Pending steps: 8", lines);
        Assert.Contains("Cancellation preview: stopped after 2 streamed updates when the time budget expired.", lines);
        Assert.Contains("- ValueTask: 1 pending step from cache profiler (async fallback: profile before replacing Task with ValueTask; keep the API simple until repeated synchronous completion is common)", lines);
        Assert.Contains("ValueTask note: keep Task as the default and reach for ValueTask only when profiling shows lots of synchronous completions, such as cache hits.", lines);
    }

    private static async IAsyncEnumerable<StudyUpdate> CreateCancelingStream(
        CancellationTokenSource cancellationSource,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        yield return new StudyUpdate("Async streams", "preview feed", 2);
        yield return new StudyUpdate("Cancellation", "preview feed", 1);

        cancellationSource.Cancel();
        await Task.Delay(1, cancellationToken);

        yield return new StudyUpdate("ValueTask", "preview feed", 1);
    }
}