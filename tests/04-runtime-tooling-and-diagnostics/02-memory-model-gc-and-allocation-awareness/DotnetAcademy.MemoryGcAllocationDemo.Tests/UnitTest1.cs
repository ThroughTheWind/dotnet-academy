using DotnetAcademy.MemoryGcAllocationDemo;

namespace DotnetAcademy.MemoryGcAllocationDemo.Tests;

public class MemoryGcAllocationWorkflowTests
{
    [Fact]
    public void RunTransientScenarioTracksCreatedObjectsWithoutRetention()
    {
        var observation = MemoryGcAllocationWorkflow.RunTransientScenario(iterationCount: 4, batchSize: 6);

        Assert.Equal("Transient batch summaries", observation.ScenarioName);
        Assert.Equal(24, observation.CreatedObjectCount);
        Assert.Equal(0, observation.RetainedSummaryCount);
        Assert.Equal(0, observation.RetainedRecordCount);
        Assert.True(observation.AllocatedBytes > 0);
        Assert.True(observation.Gen0Collections >= 0);
        Assert.True(observation.Gen1Collections >= 0);
        Assert.True(observation.Gen2Collections >= 0);
    }

    [Fact]
    public void RunRetainedScenarioTracksRetainedSummaries()
    {
        var observation = MemoryGcAllocationWorkflow.RunRetainedScenario(iterationCount: 4, batchSize: 6);

        Assert.Equal("Retained batch summaries", observation.ScenarioName);
        Assert.Equal(24, observation.CreatedObjectCount);
        Assert.Equal(4, observation.RetainedSummaryCount);
        Assert.Equal(24, observation.RetainedRecordCount);
        Assert.True(observation.AllocatedBytes > 0);
        Assert.True(observation.LiveBytesDeltaAfterCollection >= 0);
    }

    [Fact]
    public void RetainedScenarioKeepsMoreLogicalStateThanTransientScenario()
    {
        var transient = MemoryGcAllocationWorkflow.RunTransientScenario(iterationCount: 3, batchSize: 5);
        var retained = MemoryGcAllocationWorkflow.RunRetainedScenario(iterationCount: 3, batchSize: 5);

        Assert.Equal(transient.CreatedObjectCount, retained.CreatedObjectCount);
        Assert.True(retained.RetainedSummaryCount > transient.RetainedSummaryCount);
        Assert.True(retained.RetainedRecordCount > transient.RetainedRecordCount);
    }

    [Fact]
    public void BuildLinesIncludesScenarioSectionsAndNotes()
    {
        var lines = MemoryGcAllocationPresenter.BuildLines(iterationCount: 2, batchSize: 3);

        Assert.Contains("Memory Model, GC, And Allocation Awareness Demo", lines);
        Assert.Contains("Scenario: transient batch summaries", lines);
        Assert.Contains("Scenario: retained batch summaries", lines);
        Assert.Contains("Observation note: total allocated bytes measure work done during the scenario, while live managed bytes show what still survives after collection.", lines);
        Assert.Contains("GC note: this sample forces a full collection around each scenario only to make the live-memory comparison easier to read.", lines);
    }

    [Fact]
    public void RunTransientScenarioThrowsForInvalidWorkload()
    {
        var iterationException = Assert.Throws<ArgumentOutOfRangeException>(() => MemoryGcAllocationWorkflow.RunTransientScenario(iterationCount: 0, batchSize: 3));
        var batchException = Assert.Throws<ArgumentOutOfRangeException>(() => MemoryGcAllocationWorkflow.RunTransientScenario(iterationCount: 2, batchSize: 0));

        Assert.Equal("iterationCount", iterationException.ParamName);
        Assert.Equal("batchSize", batchException.ParamName);
    }
}