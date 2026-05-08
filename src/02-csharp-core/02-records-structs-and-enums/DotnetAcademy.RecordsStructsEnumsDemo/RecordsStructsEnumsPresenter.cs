namespace DotnetAcademy.RecordsStructsEnumsDemo;

public static class RecordsStructsEnumsPresenter
{
    public static IReadOnlyList<string> BuildLines()
    {
        var originalMilestone = new LearningMilestone("Records and value semantics", PracticeStatus.InProgress);
        var updatedMilestone = originalMilestone with { Status = PracticeStatus.Completed };
        var budget = new PracticeBudget(5, 3);

        return
        [
            "Dotnet Academy: Records Structs And Enums",
            "------------------------------------------",
            $"Original milestone: {originalMilestone.Title} ({FormatStatus(originalMilestone.Status)})",
            $"Copied milestone: {updatedMilestone.Title} ({FormatStatus(updatedMilestone.Status)})",
            budget.GetSummary(),
            $"Preferred review label: {FormatStatus(PracticeStatus.Review)}"
        ];
    }

    public static string FormatStatus(PracticeStatus status)
    {
        return status switch
        {
            PracticeStatus.Planned => "Planned",
            PracticeStatus.InProgress => "In progress",
            PracticeStatus.Review => "Needs review",
            PracticeStatus.Completed => "Completed",
            _ => throw new ArgumentOutOfRangeException(nameof(status), status, "Unknown practice status.")
        };
    }
}