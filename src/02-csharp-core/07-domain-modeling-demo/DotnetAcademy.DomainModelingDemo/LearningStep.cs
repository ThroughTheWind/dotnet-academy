namespace DotnetAcademy.DomainModelingDemo;

public abstract class LearningStep : ILearningStep
{
    protected LearningStep(string code, string title, EffortEstimate effort)
    {
        Code = string.IsNullOrWhiteSpace(code)
            ? throw new ArgumentException("A code is required.", nameof(code))
            : code.Trim().ToUpperInvariant();
        Title = string.IsNullOrWhiteSpace(title)
            ? throw new ArgumentException("A title is required.", nameof(title))
            : title.Trim();
        Effort = effort;
    }

    public string Code { get; }

    public string Title { get; }

    public EffortEstimate Effort { get; }

    public abstract string BuildSummary();
}