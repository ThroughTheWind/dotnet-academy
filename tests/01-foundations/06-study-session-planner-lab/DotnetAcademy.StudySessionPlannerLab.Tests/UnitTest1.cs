using DotnetAcademy.StudySessionPlannerLab;

namespace DotnetAcademy.StudySessionPlannerLab.Tests;

public class StudySessionPlannerPresenterTests
{
    private static readonly string[] EmptyArguments = [];
    private static readonly string[] AdaArguments = ["Ada"];
    private static readonly string[] AdaWithMentorAndWarningArguments = ["Ada", "Jordan", "Spacing issue in output"];

    [Fact]
    public void BuildLinesUsesFallbackValuesWhenOptionalInputsAreMissing()
    {
        var lines = StudySessionPlannerPresenter.BuildLines(AdaArguments);

        Assert.Contains("Learner: Ada", lines);
        Assert.Contains("Mentor: Unassigned", lines);
        Assert.Contains("Recent warning: None", lines);
    }

    [Fact]
    public void GetLearnerNameReturnsSafeFallbackWhenArgumentsAreMissing()
    {
        var learnerName = StudySessionPlannerPresenter.GetLearnerName(EmptyArguments);

        Assert.Equal("Learner", learnerName);
    }

    [Fact]
    public void GetReadinessMessageHighlightsRemainingWorkBeforeWeeklyTarget()
    {
        var message = StudySessionPlannerPresenter.GetReadinessMessage(2, practicedToday: true);

        Assert.Equal("Readiness: 2 topics left before the weekly target is complete.", message);
    }

    [Fact]
    public void BuildActionStepsAddsStretchGoalWhenWeeklyTargetIsReached()
    {
        var lines = StudySessionPlannerPresenter.BuildActionSteps(0, practicedToday: true);

        Assert.Contains("3. Add one stretch goal, such as custom study hours or another warning rule.", lines);
    }

    [Fact]
    public void BuildLinesIncludesWarningSpecificDebugTipWhenWarningExists()
    {
        var lines = StudySessionPlannerPresenter.BuildLines(AdaWithMentorAndWarningArguments);

        Assert.Contains("Mentor: Jordan", lines);
        Assert.Contains("Recent warning: Spacing issue in output", lines);
        Assert.Contains("Debug tip: Start with the warning text, then confirm the variables feeding that branch.", lines);
    }
}