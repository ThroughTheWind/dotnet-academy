namespace DotnetAcademy.AsyncAwaitFoundationsDemo;

public static class AsyncAwaitFoundationsWorkflow
{
    public static IReadOnlyList<string> BuildAttentionLines(IEnumerable<StudyModuleProgress> modules)
    {
        ArgumentNullException.ThrowIfNull(modules);

        return modules
            .Where(module => module.PendingSessions > 0)
            .OrderByDescending(module => module.PendingSessions)
            .ThenByDescending(module => module.TotalMinutes)
            .ThenBy(module => module.ModuleName)
            .Select(module => $"- {module.ModuleName}: {module.PendingSessions} {FormatPendingLabel(module.PendingSessions)}, {module.TotalMinutes} min total")
            .ToList();
    }

    public static async Task<IReadOnlyList<StudyModuleProgress>> LoadAllAsync(IEnumerable<IStudyModuleProgressSource> sources)
    {
        ArgumentNullException.ThrowIfNull(sources);

        var sourceArray = sources.ToArray();

        if (sourceArray.Length == 0)
        {
            throw new InvalidOperationException("At least one progress source is required.");
        }

        var tasks = sourceArray.Select(source => source.LoadAsync()).ToArray();
        var modules = await Task.WhenAll(tasks);

        return modules;
    }

    public static int SumTotalMinutes(IEnumerable<StudyModuleProgress> modules)
    {
        ArgumentNullException.ThrowIfNull(modules);
        return modules.Sum(module => module.TotalMinutes);
    }

    private static string FormatPendingLabel(int pendingSessions)
    {
        return pendingSessions == 1 ? "pending session" : "pending sessions";
    }
}