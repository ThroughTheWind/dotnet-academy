namespace DotnetAcademy.ConfigurationBasicsDemo;

public sealed class StudyPlannerSettings
{
    public const string SectionName = "StudyPlanner";

    public string CatalogName { get; set; } = string.Empty;

    public string FocusCategory { get; set; } = string.Empty;

    public int ReminderMinutes { get; set; }

    public bool IncludeArchived { get; set; }

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(CatalogName))
        {
            throw new InvalidOperationException("StudyPlanner:CatalogName is required.");
        }

        if (string.IsNullOrWhiteSpace(FocusCategory))
        {
            throw new InvalidOperationException("StudyPlanner:FocusCategory is required.");
        }

        if (ReminderMinutes <= 0)
        {
            throw new InvalidOperationException("StudyPlanner:ReminderMinutes must be greater than zero.");
        }
    }
}