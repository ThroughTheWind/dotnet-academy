namespace DotnetAcademy.CancellationAsyncStreamsValueTaskDemo;

public sealed record RecommendedStudyUpdate(string ModuleName, string SourceName, int PendingSteps, StudyRecommendation Recommendation);