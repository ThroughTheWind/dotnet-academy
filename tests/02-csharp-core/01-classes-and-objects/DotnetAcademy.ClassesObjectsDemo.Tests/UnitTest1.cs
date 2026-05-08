using DotnetAcademy.ClassesObjectsDemo;

namespace DotnetAcademy.ClassesObjectsDemo.Tests;

public class ClassesObjectsPresenterTests
{
    [Fact]
    public void ConstructorRejectsCompletedTopicsGreaterThanWeeklyGoal()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new LearnerProfile("Avery", 5, 4));
    }

    [Fact]
    public void SetFocusAreaUsesFallbackWhenInputBlank()
    {
        var learner = new LearnerProfile("Avery", 2, 4);

        learner.SetFocusArea("   ");

        Assert.Equal("General practice", learner.FocusArea);
    }

    [Fact]
    public void CompleteTopicStopsIncrementingAfterWeeklyGoalReached()
    {
        var learner = new LearnerProfile("Avery", 3, 4);

        learner.CompleteTopic();
        learner.CompleteTopic();

        Assert.Equal(4, learner.CompletedTopics);
        Assert.True(learner.IsWeeklyGoalReached);
    }

    [Fact]
    public void BuildLinesIncludesLearnerFocusProgressAndGoalState()
    {
        var lines = ClassesObjectsPresenter.BuildLines();

        Assert.Contains("Learner: Avery", lines);
        Assert.Contains("Focus area: Object modeling", lines);
        Assert.Contains("Progress: 3 topics completed, 1 topic remaining.", lines);
        Assert.Contains("Weekly goal reached: False", lines);
    }
}