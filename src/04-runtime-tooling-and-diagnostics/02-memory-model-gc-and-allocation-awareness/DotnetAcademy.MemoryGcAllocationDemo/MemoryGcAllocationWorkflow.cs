namespace DotnetAcademy.MemoryGcAllocationDemo;

public static class MemoryGcAllocationWorkflow
{
    private static readonly string[] Categories = ["runtime", "diagnostics", "memory", "tooling"];

    public static GcAllocationObservation RunTransientScenario(int iterationCount = 48, int batchSize = 180)
    {
        return ObserveScenario("Transient batch summaries", iterationCount, batchSize, retainSummaries: false);
    }

    public static GcAllocationObservation RunRetainedScenario(int iterationCount = 48, int batchSize = 180)
    {
        return ObserveScenario("Retained batch summaries", iterationCount, batchSize, retainSummaries: true);
    }

    private static GcAllocationObservation ObserveScenario(string scenarioName, int iterationCount, int batchSize, bool retainSummaries)
    {
        ValidateWorkload(iterationCount, batchSize);

        ForceFullCollection();

        var liveBefore = GC.GetTotalMemory(forceFullCollection: false);
        var allocatedBefore = GC.GetTotalAllocatedBytes(precise: true);
        var gen0Before = GC.CollectionCount(0);
        var gen1Before = GC.CollectionCount(1);
        var gen2Before = GC.CollectionCount(2);

        List<StudyBatchSummary>? retained = retainSummaries ? new List<StudyBatchSummary>(iterationCount) : null;
        var createdObjectCount = 0;
        var retainedRecordCount = 0;

        for (var iterationIndex = 0; iterationIndex < iterationCount; iterationIndex++)
        {
            var items = CreateBatch(iterationIndex, batchSize);
            createdObjectCount += items.Count;

            var summary = BuildSummary(iterationIndex, items);
            if (retained is not null)
            {
                retained.Add(summary);
                retainedRecordCount += summary.ItemCount;
            }
        }

        ForceFullCollection();

        var liveAfter = GC.GetTotalMemory(forceFullCollection: false);
        var allocatedAfter = GC.GetTotalAllocatedBytes(precise: true);

        var observation = new GcAllocationObservation(
            scenarioName,
            iterationCount,
            batchSize,
            createdObjectCount,
            retained?.Count ?? 0,
            retainedRecordCount,
            allocatedAfter - allocatedBefore,
            Math.Max(0L, liveAfter - liveBefore),
            GC.CollectionCount(0) - gen0Before,
            GC.CollectionCount(1) - gen1Before,
            GC.CollectionCount(2) - gen2Before);

        GC.KeepAlive(retained);
        return observation;
    }

    private static List<StudyAllocationItem> CreateBatch(int iterationIndex, int batchSize)
    {
        var items = new List<StudyAllocationItem>(batchSize);

        for (var itemIndex = 0; itemIndex < batchSize; itemIndex++)
        {
            var category = Categories[(iterationIndex + itemIndex) % Categories.Length];
            var minutes = 15 + ((iterationIndex * 7 + itemIndex * 3) % 50);
            var notes = $"Iteration {iterationIndex + 1} item {itemIndex + 1} for {category}";
            items.Add(new StudyAllocationItem(category, minutes, notes));
        }

        return items;
    }

    private static StudyBatchSummary BuildSummary(int iterationIndex, List<StudyAllocationItem> items)
    {
        var totalMinutes = items.Sum(item => item.Minutes);
        var distinctCategoryCount = items.Select(item => item.Category).Distinct(StringComparer.Ordinal).Count();
        var summaryText = $"Batch {iterationIndex + 1}: {items.Count} items, {distinctCategoryCount} categories, {totalMinutes} min";
        return new StudyBatchSummary(iterationIndex + 1, items.Count, totalMinutes, summaryText);
    }

    private static void ValidateWorkload(int iterationCount, int batchSize)
    {
        if (iterationCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(iterationCount), "Iteration count must be greater than zero.");
        }

        if (batchSize <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(batchSize), "Batch size must be greater than zero.");
        }
    }

    private static void ForceFullCollection()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
    }
}