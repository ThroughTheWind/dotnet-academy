using DotnetAcademy.InheritanceBasicsDemo;

namespace DotnetAcademy.InheritanceBasicsDemo.Tests;

public class InheritanceBasicsPresenterTests
{
    [Fact]
    public void GuidedLessonResourceBuildSummaryIncludesFocusArea()
    {
        var resource = new GuidedLessonResource("Composition over inheritance", 25, "abstraction choices");

        Assert.Equal("Composition over inheritance (25 min guided lesson on abstraction choices)", resource.BuildSummary());
    }

    [Fact]
    public void GuidedLessonResourceUsesBaseFollowUpAction()
    {
        LearningResource resource = new GuidedLessonResource("Composition over inheritance", 25, "abstraction choices");

        Assert.Equal("Review the key idea once before moving on.", resource.GetFollowUpAction());
    }

    [Fact]
    public void CodeChallengeResourceOverridesFollowUpAction()
    {
        LearningResource resource = new CodeChallengeResource("Refactor a base type carefully", 30, 2);

        Assert.Equal("Run the challenge again with a different input set.", resource.GetFollowUpAction());
    }

    [Fact]
    public void BuildLinesIncludesDerivedSummariesAndTradeoffNote()
    {
        var lines = InheritanceBasicsPresenter.BuildLines();

        Assert.Contains("Composition over inheritance (25 min guided lesson on abstraction choices)", lines);
        Assert.Contains("Refactor a base type carefully (30 min challenge, 2 expected outputs)", lines);
        Assert.Contains("Tradeoff note: prefer inheritance only when the derived type is a true specialized version of the base type.", lines);
    }
}