namespace DotnetAcademy.DomainModelingDemo;

public sealed class StandardWorkloadAdvisor : IWorkloadAdvisor
{
    public string BuildNote(IReadOnlyList<LearningStep> steps)
    {
        ArgumentNullException.ThrowIfNull(steps);

        var totalMinutes = 0;

        foreach (var step in steps)
        {
            totalMinutes += step.Effort.Minutes;
        }

        return totalMinutes switch
        {
            <= 60 => "This plan fits into one focused session.",
            <= 90 => "Keep the plan in two short sessions to preserve feedback quality.",
            _ => "Split the plan across multiple sessions so the model stays realistic."
        };
    }
}