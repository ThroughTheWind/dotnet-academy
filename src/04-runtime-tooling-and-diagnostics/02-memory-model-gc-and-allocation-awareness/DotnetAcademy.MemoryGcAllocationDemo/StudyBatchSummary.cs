namespace DotnetAcademy.MemoryGcAllocationDemo;

public sealed class StudyBatchSummary
{
    public StudyBatchSummary(int batchNumber, int itemCount, int totalMinutes, string summaryText)
    {
        BatchNumber = batchNumber;
        ItemCount = itemCount;
        TotalMinutes = totalMinutes;
        SummaryText = summaryText;
    }

    public int BatchNumber { get; }

    public int ItemCount { get; }

    public int TotalMinutes { get; }

    public string SummaryText { get; }
}