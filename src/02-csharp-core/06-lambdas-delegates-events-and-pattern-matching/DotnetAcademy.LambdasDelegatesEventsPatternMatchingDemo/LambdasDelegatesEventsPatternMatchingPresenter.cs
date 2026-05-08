namespace DotnetAcademy.LambdasDelegatesEventsPatternMatchingDemo;

public static class LambdasDelegatesEventsPatternMatchingPresenter
{
	public static IReadOnlyList<string> BuildLines()
	{
		var tracker = BuildSampleTracker(out var notifications);

		StudyResultFilter needsFollowUp = result => result is NeedsPractice or DeferredStudy;
		StudyResultFormatter formatter = result => $"- {StudyResultDescriber.Describe(result)}";

		var lines = new List<string>
		{
			"Dotnet Academy: Lambdas, Delegates, Events, and Pattern Matching",
			"---------------------------------------------------------------"
		};

		lines.AddRange(notifications);
		lines.Add("Focus list:");
		lines.AddRange(tracker.BuildLines(needsFollowUp, formatter));
		lines.Add("Delegate note: lambdas supplied both the filter and formatter at the call site.");

		return lines;
	}

	public static StudyProgressTracker BuildSampleTracker(out List<string> notifications)
	{
		var recordedMessages = new List<string>();
		var tracker = new StudyProgressTracker();

		tracker.ResultRecorded += HandleResultRecorded;
		tracker.Record(new ReadyToReview("Generics checkpoint", 92));
		tracker.Record(new NeedsPractice("Collections drill", 68));
		tracker.Record(new DeferredStudy("Exceptions recap", "time ran out"));
		tracker.ResultRecorded -= HandleResultRecorded;
		notifications = recordedMessages;

		return tracker;

		void HandleResultRecorded(object? sender, StudyResultRecordedEventArgs args)
		{
			recordedMessages.Add($"Recorded: {args.Description}");
		}
	}
}