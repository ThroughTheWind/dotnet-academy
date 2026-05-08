namespace DotnetAcademy.ClassesObjectsDemo;

public sealed class LearnerProfile
{
    public LearnerProfile(string name, int completedTopics, int weeklyGoal)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("A learner name is required.", nameof(name));
        }

        if (completedTopics < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(completedTopics), "Completed topics cannot be negative.");
        }

        if (weeklyGoal <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(weeklyGoal), "Weekly goal must be greater than zero.");
        }

        if (completedTopics > weeklyGoal)
        {
            throw new ArgumentOutOfRangeException(nameof(completedTopics), "Completed topics cannot exceed the weekly goal.");
        }

        Name = name.Trim();
        CompletedTopics = completedTopics;
        WeeklyGoal = weeklyGoal;
        FocusArea = "General practice";
    }

    public string Name { get; }

    public int CompletedTopics { get; private set; }

    public int WeeklyGoal { get; }

    public string FocusArea { get; private set; }

    public int RemainingTopics => WeeklyGoal - CompletedTopics;

    public bool IsWeeklyGoalReached => RemainingTopics == 0;

    public void SetFocusArea(string focusArea)
    {
        FocusArea = string.IsNullOrWhiteSpace(focusArea) ? "General practice" : focusArea.Trim();
    }

    public void CompleteTopic()
    {
        if (!IsWeeklyGoalReached)
        {
            CompletedTopics++;
        }
    }

    public string GetProgressSummary()
    {
        var completedLabel = CompletedTopics == 1 ? "topic" : "topics";
        var remainingLabel = RemainingTopics == 1 ? "topic" : "topics";
        return $"Progress: {CompletedTopics} {completedLabel} completed, {RemainingTopics} {remainingLabel} remaining.";
    }
}