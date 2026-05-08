namespace DotnetAcademy.LambdasDelegatesEventsPatternMatchingDemo;

public sealed class StudyResultRecordedEventArgs : EventArgs
{
	public StudyResultRecordedEventArgs(StudyResult result, string description)
	{
		Result = result ?? throw new ArgumentNullException(nameof(result));
		Description = string.IsNullOrWhiteSpace(description) ? throw new ArgumentException("A description is required.", nameof(description)) : description.Trim();
	}

	public StudyResult Result { get; }

	public string Description { get; }
}