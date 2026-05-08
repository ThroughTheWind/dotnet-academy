namespace DotnetAcademy.AsyncAwaitFoundationsDemo;

public sealed class StudyModuleProgress
{
    public StudyModuleProgress(string moduleName, int completedSessions, int pendingSessions, int totalMinutes)
    {
        ModuleName = string.IsNullOrWhiteSpace(moduleName)
            ? throw new ArgumentException("A module name is required.", nameof(moduleName))
            : moduleName.Trim();
        CompletedSessions = completedSessions >= 0
            ? completedSessions
            : throw new ArgumentOutOfRangeException(nameof(completedSessions), "Completed sessions cannot be negative.");
        PendingSessions = pendingSessions >= 0
            ? pendingSessions
            : throw new ArgumentOutOfRangeException(nameof(pendingSessions), "Pending sessions cannot be negative.");
        TotalMinutes = totalMinutes > 0
            ? totalMinutes
            : throw new ArgumentOutOfRangeException(nameof(totalMinutes), "Total minutes must be greater than zero.");
    }

    public string ModuleName { get; }

    public int CompletedSessions { get; }

    public int PendingSessions { get; }

    public int TotalMinutes { get; }
}