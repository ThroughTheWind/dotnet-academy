using System.Globalization;

namespace DotnetAcademy.MemoryGcAllocationDemo;

public static class MemoryGcAllocationPresenter
{
    public static IReadOnlyList<string> BuildLines(int iterationCount = 48, int batchSize = 180)
    {
        var transient = MemoryGcAllocationWorkflow.RunTransientScenario(iterationCount, batchSize);
        var retained = MemoryGcAllocationWorkflow.RunRetainedScenario(iterationCount, batchSize);

        var lines = new List<string>
        {
            "Memory Model, GC, And Allocation Awareness Demo",
            "-----------------------------------------------",
            $"Workload: {iterationCount} batches x {batchSize} items"
        };

        AddScenarioLines(lines, transient);
        AddScenarioLines(lines, retained);

        lines.Add("Observation note: total allocated bytes measure work done during the scenario, while live managed bytes show what still survives after collection.");
        lines.Add("GC note: this sample forces a full collection around each scenario only to make the live-memory comparison easier to read.");

        return lines;
    }

    private static void AddScenarioLines(List<string> lines, GcAllocationObservation observation)
    {
        lines.Add($"Scenario: {observation.ScenarioName.ToLowerInvariant()}");
        lines.Add($"- Created objects: {FormatNumber(observation.CreatedObjectCount)}");
        lines.Add($"- Retained summaries: {FormatNumber(observation.RetainedSummaryCount)}");
        lines.Add($"- Retained records represented: {FormatNumber(observation.RetainedRecordCount)}");
        lines.Add($"- Total allocated bytes: {FormatNumber(observation.AllocatedBytes)}");
        lines.Add($"- Live managed bytes after collection: {FormatNumber(observation.LiveBytesDeltaAfterCollection)}");
        lines.Add($"- GC collections: Gen0={observation.Gen0Collections} Gen1={observation.Gen1Collections} Gen2={observation.Gen2Collections}");
    }

    private static string FormatNumber(long value)
    {
        return value.ToString("N0", CultureInfo.InvariantCulture);
    }
}