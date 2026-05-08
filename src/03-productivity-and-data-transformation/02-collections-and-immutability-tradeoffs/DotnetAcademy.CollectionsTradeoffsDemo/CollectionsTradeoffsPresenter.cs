namespace DotnetAcademy.CollectionsTradeoffsDemo;

public static class CollectionsTradeoffsPresenter
{
    public static IReadOnlyList<string> BuildLines()
    {
        var board = BuildSampleBoard();
        var lines = new List<string>
        {
            "Dotnet Academy: Collections and Immutability Tradeoffs",
            "------------------------------------------------------",
            $"Tracked categories: {board.CategoryCount}",
            "Priority items:"
        };

        lines.AddRange(board.BuildPriorityTitles().Select(title => $"- {title}"));
        lines.Add("Category summary:");
        lines.AddRange(board.BuildCategorySummary());

        if (board.TryFindByCode("board-03", out var foundItem))
        {
            lines.Add($"Lookup example: {foundItem.Code} => {foundItem.Title}");
        }

        var snapshotBeforeUpdate = board.PublishSnapshot();
        board.MarkComplete("BOARD-02");

        lines.Add($"Snapshot before update: {snapshotBeforeUpdate.CompletedItems} complete, {snapshotBeforeUpdate.RemainingItems} remaining");
        lines.Add($"Live board after update: {board.CompletedCount} complete, {board.TotalCount} total");
        lines.Add($"Snapshot still says: {snapshotBeforeUpdate.CompletedItems} complete, {snapshotBeforeUpdate.RemainingItems} remaining");
        lines.Add("Tradeoff note: keep the working board mutable while planning, then publish snapshots when readers need stable data.");

        return lines;
    }

    public static StudyBoard BuildSampleBoard()
    {
        var board = new StudyBoard();
        board.Add(new StudyBoardItem("BOARD-01", "Review list ordering rules", "collections", priority: 2, completed: true));
        board.Add(new StudyBoardItem("BOARD-02", "Contrast dictionary lookups", "collections", priority: 1));
        board.Add(new StudyBoardItem("BOARD-03", "Review snapshot boundaries", "immutability", priority: 3));
        board.Add(new StudyBoardItem("BOARD-04", "Publish stable report models", "reporting", priority: 4));
        return board;
    }
}