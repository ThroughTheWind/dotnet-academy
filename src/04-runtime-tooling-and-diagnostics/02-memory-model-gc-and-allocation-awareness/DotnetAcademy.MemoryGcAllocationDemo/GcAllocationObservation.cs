namespace DotnetAcademy.MemoryGcAllocationDemo;

public sealed record GcAllocationObservation(
    string ScenarioName,
    int IterationCount,
    int BatchSize,
    int CreatedObjectCount,
    int RetainedSummaryCount,
    int RetainedRecordCount,
    long AllocatedBytes,
    long LiveBytesDeltaAfterCollection,
    int Gen0Collections,
    int Gen1Collections,
    int Gen2Collections);