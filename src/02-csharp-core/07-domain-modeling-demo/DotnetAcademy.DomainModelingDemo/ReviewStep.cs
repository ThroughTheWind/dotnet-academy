namespace DotnetAcademy.DomainModelingDemo;

public sealed class ReviewStep : LearningStep
{
    public ReviewStep(string code, string title, EffortEstimate effort, string trigger)
        : base(code, title, effort)
    {
        Trigger = string.IsNullOrWhiteSpace(trigger)
            ? throw new ArgumentException("A trigger is required.", nameof(trigger))
            : trigger.Trim().ToLowerInvariant();
    }

    public string Trigger { get; }

    public override string BuildSummary()
    {
        return $"{Code} {Title} ({Effort} review triggered by {Trigger})";
    }
}