namespace DotnetAcademy.AsyncAwaitFoundationsDemo;

public static class AsyncAwaitFoundationsPresenter
{
    public static async Task<IReadOnlyList<string>> BuildLinesAsync(IEnumerable<IStudyModuleProgressSource>? sources = null)
    {
        sources ??= BuildSampleSources();

        var modules = await AsyncAwaitFoundationsWorkflow.LoadAllAsync(sources);
        var attentionLines = AsyncAwaitFoundationsWorkflow.BuildAttentionLines(modules);

        var lines = new List<string>
        {
            "Dotnet Academy: Async And Await Foundations",
            "--------------------------------------------",
            $"Modules loaded: {modules.Count}",
            $"Total minutes: {AsyncAwaitFoundationsWorkflow.SumTotalMinutes(modules)}",
            "Modules needing attention:"
        };

        lines.AddRange(attentionLines);
        lines.Add("Async note: start independent work, await the tasks, and shape the finished results after completion rather than blocking with Result or Wait.");

        return lines;
    }

    public static IReadOnlyList<IStudyModuleProgressSource> BuildSampleSources()
    {
        return
        [
            new DelayedStudyModuleProgressSource(new StudyModuleProgress("LINQ review", 5, 1, 32), 25),
            new DelayedStudyModuleProgressSource(new StudyModuleProgress("Configuration setup", 3, 2, 41), 15),
            new DelayedStudyModuleProgressSource(new StudyModuleProgress("File exports", 4, 3, 28), 10)
        ];
    }
}