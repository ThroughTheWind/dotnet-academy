namespace DotnetAcademy.RecordsStructsEnumsDemo;

public readonly struct PracticeBudget
{
    public PracticeBudget(int plannedSessions, int completedSessions)
    {
        if (plannedSessions <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(plannedSessions), "Planned sessions must be greater than zero.");
        }

        if (completedSessions < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(completedSessions), "Completed sessions cannot be negative.");
        }

        if (completedSessions > plannedSessions)
        {
            throw new ArgumentOutOfRangeException(nameof(completedSessions), "Completed sessions cannot exceed planned sessions.");
        }

        PlannedSessions = plannedSessions;
        CompletedSessions = completedSessions;
    }

    public int PlannedSessions { get; }

    public int CompletedSessions { get; }

    public int RemainingSessions => PlannedSessions - CompletedSessions;

    public string GetSummary()
    {
        var remainingLabel = RemainingSessions == 1 ? "session" : "sessions";
        return $"Practice budget: {CompletedSessions}/{PlannedSessions} sessions completed, {RemainingSessions} {remainingLabel} remaining.";
    }
}