using DotnetAcademy.ControlFlowMethodsDemo;

namespace DotnetAcademy.ControlFlowMethodsDemo.Tests;

public class ControlFlowMethodsPresenterTests
{
    [Fact]
    public void GetReadinessMessageRequiresPracticeWhenLearnerHasNotPracticed()
    {
        var message = ControlFlowMethodsPresenter.GetReadinessMessage(3, practicedToday: false);

        Assert.Equal("Practice once today before moving to the next topic.", message);
    }

    [Fact]
    public void GetReadinessMessagePromotesLargerChallengeForReadyLearner()
    {
        var message = ControlFlowMethodsPresenter.GetReadinessMessage(4, practicedToday: true);

        Assert.Equal("You are ready for a larger challenge that combines several basics.", message);
    }

    [Fact]
    public void BuildPracticeSessionsReturnsThreeItemsForEarlierLearner()
    {
        var lines = ControlFlowMethodsPresenter.BuildPracticeSessions(3);

        Assert.Equal(3, lines.Count);
    }

    [Fact]
    public void BuildLinesIncludesStudySummaryAndSuggestedSessions()
    {
        var lines = ControlFlowMethodsPresenter.BuildLines(3, practicedToday: false);

        Assert.Contains("Dotnet Academy: Control Flow And Methods", lines);
        Assert.Contains("Suggested practice sessions:", lines);
        Assert.Contains("- Practice session 1: write one small method and test one decision.", lines);
    }
}

