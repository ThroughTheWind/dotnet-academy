namespace DotnetAcademy.LambdasDelegatesEventsPatternMatchingDemo;

public abstract record StudyResult
{
	protected StudyResult(string title)
	{
		Title = string.IsNullOrWhiteSpace(title) ? throw new ArgumentException("A title is required.", nameof(title)) : title.Trim();
	}

	public string Title { get; }
}

public sealed record ReadyToReview : StudyResult
{
	public ReadyToReview(string title, int score) : base(title)
	{
		Score = score is >= 0 and <= 100 ? score : throw new ArgumentOutOfRangeException(nameof(score), "Score must stay between 0 and 100.");
	}

	public int Score { get; }
}

public sealed record NeedsPractice : StudyResult
{
	public NeedsPractice(string title, int score) : base(title)
	{
		Score = score is >= 0 and <= 100 ? score : throw new ArgumentOutOfRangeException(nameof(score), "Score must stay between 0 and 100.");
	}

	public int Score { get; }
}

public sealed record DeferredStudy : StudyResult
{
	public DeferredStudy(string title, string reason) : base(title)
	{
		Reason = string.IsNullOrWhiteSpace(reason) ? throw new ArgumentException("A reason is required.", nameof(reason)) : reason.Trim();
	}

	public string Reason { get; }
}