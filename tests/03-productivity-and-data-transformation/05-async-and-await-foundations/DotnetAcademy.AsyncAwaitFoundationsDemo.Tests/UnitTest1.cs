using DotnetAcademy.AsyncAwaitFoundationsDemo;

namespace DotnetAcademy.AsyncAwaitFoundationsDemo.Tests;

public class AsyncAwaitFoundationsPresenterTests
{
    [Fact]
    public async Task LoadAllAsyncReturnsModulesFromAllSources()
    {
        var sources = new IStudyModuleProgressSource[]
        {
            new StubProgressSource(new StudyModuleProgress("File exports", 4, 3, 28)),
            new StubProgressSource(new StudyModuleProgress("Configuration setup", 3, 2, 41))
        };

        var modules = await AsyncAwaitFoundationsWorkflow.LoadAllAsync(sources);

        Assert.Equal(2, modules.Count);
        Assert.Contains(modules, module => module.ModuleName == "File exports");
        Assert.Contains(modules, module => module.ModuleName == "Configuration setup");
    }

    [Fact]
    public void BuildAttentionLinesFormatsSingularAndPluralPendingCounts()
    {
        var modules = new[]
        {
            new StudyModuleProgress("LINQ review", 5, 1, 32),
            new StudyModuleProgress("File exports", 4, 3, 28)
        };

        var lines = AsyncAwaitFoundationsWorkflow.BuildAttentionLines(modules);

        Assert.Equal("- File exports: 3 pending sessions, 28 min total", lines[0]);
        Assert.Equal("- LINQ review: 1 pending session, 32 min total", lines[1]);
    }

    [Fact]
    public async Task BuildLinesAsyncIncludesSummaryAndAsyncNote()
    {
        var lines = await AsyncAwaitFoundationsPresenter.BuildLinesAsync();

        Assert.Contains("Modules loaded: 3", lines);
        Assert.Contains("Total minutes: 101", lines);
        Assert.Contains("Async note: start independent work, await the tasks, and shape the finished results after completion rather than blocking with Result or Wait.", lines);
    }

    [Fact]
    public async Task LoadAllAsyncThrowsWhenNoSourcesExist()
    {
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => AsyncAwaitFoundationsWorkflow.LoadAllAsync([]));

        Assert.Equal("At least one progress source is required.", exception.Message);
    }

    [Fact]
    public void SumTotalMinutesAddsAcrossModules()
    {
        var total = AsyncAwaitFoundationsWorkflow.SumTotalMinutes(
        [
            new StudyModuleProgress("LINQ review", 5, 1, 32),
            new StudyModuleProgress("Configuration setup", 3, 2, 41)
        ]);

        Assert.Equal(73, total);
    }

    private sealed class StubProgressSource(StudyModuleProgress progress) : IStudyModuleProgressSource
    {
        public Task<StudyModuleProgress> LoadAsync()
        {
            return Task.FromResult(progress);
        }
    }
}