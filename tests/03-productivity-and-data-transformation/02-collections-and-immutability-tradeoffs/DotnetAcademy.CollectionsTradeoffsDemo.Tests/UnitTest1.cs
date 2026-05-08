using DotnetAcademy.CollectionsTradeoffsDemo;

namespace DotnetAcademy.CollectionsTradeoffsDemo.Tests;

public class CollectionsTradeoffsPresenterTests
{
    [Fact]
    public void BuildPriorityTitlesOrdersOpenItemsByPriority()
    {
        var board = CollectionsTradeoffsPresenter.BuildSampleBoard();

        var lines = board.BuildPriorityTitles();

        Assert.Equal(3, lines.Count);
        Assert.Equal("BOARD-02: Contrast dictionary lookups [collections]", lines[0]);
        Assert.Equal("BOARD-03: Review snapshot boundaries [immutability]", lines[1]);
        Assert.Equal("BOARD-04: Publish stable report models [reporting]", lines[2]);
    }

    [Fact]
    public void TryFindByCodeUsesDictionaryLookupAndIgnoresCase()
    {
        var board = CollectionsTradeoffsPresenter.BuildSampleBoard();

        var found = board.TryFindByCode("board-03", out var item);

        Assert.True(found);
        Assert.NotNull(item);
        Assert.Equal("Review snapshot boundaries", item.Title);
    }

    [Fact]
    public void PublishSnapshotKeepsPointInTimeCountsAfterBoardMutates()
    {
        var board = CollectionsTradeoffsPresenter.BuildSampleBoard();

        var snapshot = board.PublishSnapshot();
        board.MarkComplete("BOARD-02");

        Assert.Equal(1, snapshot.CompletedItems);
        Assert.Equal(3, snapshot.RemainingItems);
        Assert.Equal(3, snapshot.PriorityTitles.Count);
        Assert.Equal(2, board.CompletedCount);
    }

    [Fact]
    public void BuildCategorySummaryGroupsItemsByCategory()
    {
        var board = CollectionsTradeoffsPresenter.BuildSampleBoard();

        var lines = board.BuildCategorySummary();

        Assert.Equal(3, lines.Count);
        Assert.Equal("collections: 2 items", lines[0]);
        Assert.Equal("immutability: 1 items", lines[1]);
        Assert.Equal("reporting: 1 items", lines[2]);
    }

    [Fact]
    public void BuildLinesIncludesLookupAndTradeoffNote()
    {
        var lines = CollectionsTradeoffsPresenter.BuildLines();

        Assert.Contains("Tracked categories: 3", lines);
        Assert.Contains("Lookup example: BOARD-03 => Review snapshot boundaries", lines);
        Assert.Contains("Snapshot still says: 1 complete, 3 remaining", lines);
        Assert.Contains("Tradeoff note: keep the working board mutable while planning, then publish snapshots when readers need stable data.", lines);
    }
}