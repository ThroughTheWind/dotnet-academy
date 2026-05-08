namespace DotnetAcademy.LambdasDelegatesEventsPatternMatchingDemo;

public static class StudyResultDescriber
{
	public static string Describe(StudyResult result)
	{
		ArgumentNullException.ThrowIfNull(result);

		return result switch
		{
			ReadyToReview { Score: >= 90 } ready => $"{ready.Title} => ready to review after a strong {ready.Score}% result.",
			ReadyToReview ready => $"{ready.Title} => ready to review after a steady {ready.Score}% result.",
			NeedsPractice { Score: < 70 } practice => $"{practice.Title} => practice again because the score is {practice.Score}%.",
			NeedsPractice practice => $"{practice.Title} => one more focused pass could raise the {practice.Score}% result.",
			DeferredStudy deferred => $"{deferred.Title} => revisit later because {deferred.Reason}.",
			_ => throw new ArgumentOutOfRangeException(nameof(result), "The study result shape was not recognized.")
		};
	}
}