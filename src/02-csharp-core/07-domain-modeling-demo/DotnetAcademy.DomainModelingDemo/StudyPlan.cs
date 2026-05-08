namespace DotnetAcademy.DomainModelingDemo;

public sealed class StudyPlan
{
    private readonly List<LearningStep> _steps = [];
    private readonly IWorkloadAdvisor _workloadAdvisor;

    public StudyPlan(string learnerName, IWorkloadAdvisor workloadAdvisor)
    {
        LearnerName = string.IsNullOrWhiteSpace(learnerName)
            ? throw new ArgumentException("A learner name is required.", nameof(learnerName))
            : learnerName.Trim();
        _workloadAdvisor = workloadAdvisor ?? throw new ArgumentNullException(nameof(workloadAdvisor));
    }

    public event EventHandler<StepAddedEventArgs>? StepAdded;

    public string LearnerName { get; }

    public void AddStep(LearningStep step)
    {
        ArgumentNullException.ThrowIfNull(step);

        _steps.Add(step);
        StepAdded?.Invoke(this, new StepAddedEventArgs(step, StudyPlanDescriber.Describe(step)));
    }

    public IReadOnlyList<LearningStep> GetAllSteps()
    {
        return _steps;
    }

    public IReadOnlyList<LearningStep> GetSteps(PlanStepFilter filter)
    {
        ArgumentNullException.ThrowIfNull(filter);

        var matches = new List<LearningStep>();

        foreach (var step in _steps)
        {
            if (filter(step))
            {
                matches.Add(step);
            }
        }

        return matches;
    }

    public string GetWorkloadNote()
    {
        return _workloadAdvisor.BuildNote(_steps);
    }
}