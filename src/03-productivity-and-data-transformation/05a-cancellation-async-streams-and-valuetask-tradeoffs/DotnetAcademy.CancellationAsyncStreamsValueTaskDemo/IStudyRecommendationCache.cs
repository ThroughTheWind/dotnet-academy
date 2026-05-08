namespace DotnetAcademy.CancellationAsyncStreamsValueTaskDemo;

public interface IStudyRecommendationCache
{
    ValueTask<StudyRecommendation> GetRecommendationAsync(string moduleName, CancellationToken cancellationToken = default);
}