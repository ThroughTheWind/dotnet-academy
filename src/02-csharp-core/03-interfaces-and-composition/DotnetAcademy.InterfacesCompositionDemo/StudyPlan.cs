namespace DotnetAcademy.InterfacesCompositionDemo;

public sealed class StudyPlan
{
    public StudyPlan(string learnerName, IReadOnlyList<ILearningActivity> activities)
    {
        LearnerName = string.IsNullOrWhiteSpace(learnerName) ? throw new ArgumentException("A learner name is required.", nameof(learnerName)) : learnerName.Trim();
        Activities = activities.Count > 0 ? activities : throw new ArgumentException("At least one activity is required.", nameof(activities));
    }

    public string LearnerName { get; }

    public IReadOnlyList<ILearningActivity> Activities { get; }

    public int GetTotalEstimatedMinutes()
    {
        return Activities.Sum(activity => activity.EstimatedMinutes);
    }

    public IReadOnlyList<string> BuildAgendaLines()
    {
        var lines = new List<string>
        {
            $"Learner: {LearnerName}",
            $"Total estimate: {GetTotalEstimatedMinutes()} minutes",
            "Agenda:"
        };

        foreach (var activity in Activities)
        {
            lines.Add($"- {activity.BuildSummary()}");
        }

        return lines;
    }
}