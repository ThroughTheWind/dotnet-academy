namespace DotnetAcademy.CancellationAsyncStreamsValueTaskDemo;

public sealed class StudyRecommendationCache(IReadOnlyDictionary<string, string> cachedRecommendations, int fallbackDelayMilliseconds = 15)
    : IStudyRecommendationCache
{
    private readonly IReadOnlyDictionary<string, string> cachedRecommendations = cachedRecommendations ?? throw new ArgumentNullException(nameof(cachedRecommendations));
    private readonly int fallbackDelayMilliseconds = fallbackDelayMilliseconds >= 0
        ? fallbackDelayMilliseconds
        : throw new ArgumentOutOfRangeException(nameof(fallbackDelayMilliseconds));

    public ValueTask<StudyRecommendation> GetRecommendationAsync(string moduleName, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(moduleName);

        if (cachedRecommendations.TryGetValue(moduleName, out var recommendationText))
        {
            return ValueTask.FromResult(new StudyRecommendation(recommendationText, true));
        }

        return new ValueTask<StudyRecommendation>(LoadFallbackAsync(cancellationToken));
    }

    private async Task<StudyRecommendation> LoadFallbackAsync(CancellationToken cancellationToken)
    {
        if (fallbackDelayMilliseconds > 0)
        {
            await Task.Delay(fallbackDelayMilliseconds, cancellationToken);
        }

        return new StudyRecommendation(
            "profile before replacing Task with ValueTask; keep the API simple until repeated synchronous completion is common",
            false);
    }
}