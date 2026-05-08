using DotnetAcademy.LambdasDelegatesEventsPatternMatchingDemo;

namespace DotnetAcademy.LambdasDelegatesEventsPatternMatchingDemo.Tests;

public class LambdasDelegatesEventsPatternMatchingPresenterTests
{
	[Fact]
	public void StudyResultDescriberBuildsStrongReadyToReviewMessage()
	{
		var result = new ReadyToReview("Generics checkpoint", 92);

		Assert.Equal("Generics checkpoint => ready to review after a strong 92% result.", StudyResultDescriber.Describe(result));
	}

	[Fact]
	public void StudyProgressTrackerRecordRaisesResultRecordedEvent()
	{
		var tracker = new StudyProgressTracker();
		string? capturedDescription = null;

		tracker.ResultRecorded += (_, args) => capturedDescription = args.Description;
		tracker.Record(new NeedsPractice("Collections drill", 68));

		Assert.Equal("Collections drill => practice again because the score is 68%.", capturedDescription);
	}

	[Fact]
	public void BuildSampleTrackerCapturesThreeNotificationMessages()
	{
		var tracker = LambdasDelegatesEventsPatternMatchingPresenter.BuildSampleTracker(out var notifications);

		Assert.Equal(3, tracker.GetResults().Count);
		Assert.Equal(3, notifications.Count);
		Assert.Contains("Recorded: Exceptions recap => revisit later because time ran out.", notifications);
	}

	[Fact]
	public void StudyProgressTrackerBuildLinesUsesDelegateFilterAndFormatter()
	{
		var tracker = LambdasDelegatesEventsPatternMatchingPresenter.BuildSampleTracker(out _);
		StudyResultFilter needsFollowUp = result => result is NeedsPractice or DeferredStudy;
		StudyResultFormatter formatter = result => $"- {StudyResultDescriber.Describe(result)}";

		var lines = tracker.BuildLines(needsFollowUp, formatter);

		Assert.Equal(2, lines.Count);
		Assert.Contains("- Collections drill => practice again because the score is 68%.", lines);
		Assert.Contains("- Exceptions recap => revisit later because time ran out.", lines);
	}

	[Fact]
	public void BuildLinesIncludesNotificationsFocusListAndDelegateNote()
	{
		var lines = LambdasDelegatesEventsPatternMatchingPresenter.BuildLines();

		Assert.Contains("Recorded: Generics checkpoint => ready to review after a strong 92% result.", lines);
		Assert.Contains("Recorded: Collections drill => practice again because the score is 68%.", lines);
		Assert.Contains("Focus list:", lines);
		Assert.Contains("Delegate note: lambdas supplied both the filter and formatter at the call site.", lines);
	}
}