using DotnetAcademy.RecordsStructsEnumsDemo;

namespace DotnetAcademy.RecordsStructsEnumsDemo.Tests;

public class RecordsStructsEnumsPresenterTests
{
    [Fact]
    public void FormatStatusReturnsFriendlyReviewLabel()
    {
        Assert.Equal("Needs review", RecordsStructsEnumsPresenter.FormatStatus(PracticeStatus.Review));
    }

    [Fact]
    public void RecordCopyKeepsOriginalStatusAndUpdatesCopiedStatus()
    {
        var original = new LearningMilestone("Records and value semantics", PracticeStatus.InProgress);
        var copied = original with { Status = PracticeStatus.Completed };

        Assert.Equal(PracticeStatus.InProgress, original.Status);
        Assert.Equal(PracticeStatus.Completed, copied.Status);
        Assert.Equal(original.Title, copied.Title);
    }

    [Fact]
    public void PracticeBudgetSummaryShowsRemainingSessions()
    {
        var budget = new PracticeBudget(5, 3);

        Assert.Equal("Practice budget: 3/5 sessions completed, 2 sessions remaining.", budget.GetSummary());
    }

    [Fact]
    public void BuildLinesIncludesRecordCopyBudgetAndEnumLabel()
    {
        var lines = RecordsStructsEnumsPresenter.BuildLines();

        Assert.Contains("Original milestone: Records and value semantics (In progress)", lines);
        Assert.Contains("Copied milestone: Records and value semantics (Completed)", lines);
        Assert.Contains("Practice budget: 3/5 sessions completed, 2 sessions remaining.", lines);
        Assert.Contains("Preferred review label: Needs review", lines);
    }
}