using DotnetAcademy.LinqQueryThinkingDemo;

namespace DotnetAcademy.LinqQueryThinkingDemo.Tests;

public class LinqQueryThinkingPresenterTests
{
    [Fact]
    public void BuildCompletedLinesFiltersProjectsAndOrdersByScore()
    {
        var lines = LinqQueryThinkingPresenter.BuildCompletedLines(LinqQueryThinkingPresenter.BuildSampleAttempts());

        Assert.Equal(4, lines.Count);
        Assert.Equal("- Filter completed sessions (92% in 18 min)", lines[0]);
        Assert.Equal("- Group attempts by category (88% in 16 min)", lines[1]);
    }

    [Fact]
    public void BuildFocusNoteReturnsInProgressMessageForIncompleteAttempt()
    {
        var note = LinqQueryThinkingPresenter.BuildFocusNote(
            new StudyAttempt("Sort results with intent", "query thinking", 68, completed: false, 25));

        Assert.Equal("still in progress after 25 minutes", note);
    }

    [Fact]
    public void BuildFocusLinesIncludesIncompleteAndLowerScoringItems()
    {
        var lines = LinqQueryThinkingPresenter.BuildFocusLines(LinqQueryThinkingPresenter.BuildSampleAttempts());

        Assert.Equal(3, lines.Count);
        Assert.Contains("- Sort results with intent: still in progress after 25 minutes", lines);
        Assert.Contains("- Project study summaries: one more pass could strengthen the 78% result", lines);
        Assert.Contains("- Spot duplicate tags: one more pass could strengthen the 74% result", lines);
    }

    [Fact]
    public void BuildCategorySummaryLinesGroupsAttemptsAndCalculatesAverageScores()
    {
        var lines = LinqQueryThinkingPresenter.BuildCategorySummaryLines(LinqQueryThinkingPresenter.BuildSampleAttempts());

        Assert.Equal(3, lines.Count);
        Assert.Equal("collections: 1 attempts, average score 74%", lines[0]);
        Assert.Equal("linq: 2 attempts, average score 85%", lines[1]);
        Assert.Equal("query thinking: 2 attempts, average score 78%", lines[2]);
    }

    [Fact]
    public void BuildLinesIncludesSectionsAndQueryNote()
    {
        var lines = LinqQueryThinkingPresenter.BuildLines();

        Assert.Contains("Completed items:", lines);
        Assert.Contains("Focus list:", lines);
        Assert.Contains("Category summary:", lines);
        Assert.Contains("Query note: start with the question you need the data to answer, then choose operators that express that question clearly.", lines);
    }
}