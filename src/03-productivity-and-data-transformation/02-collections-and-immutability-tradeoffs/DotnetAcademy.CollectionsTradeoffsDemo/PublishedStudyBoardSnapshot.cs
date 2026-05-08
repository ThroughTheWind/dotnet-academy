namespace DotnetAcademy.CollectionsTradeoffsDemo;

public sealed record PublishedStudyBoardSnapshot(
    int TotalItems,
    int CompletedItems,
    IReadOnlyList<string> PriorityTitles,
    IReadOnlyList<string> CategorySummary)
{
    public int RemainingItems => TotalItems - CompletedItems;
}