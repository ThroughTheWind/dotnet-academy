namespace DotnetAcademy.DomainModelingDemo;

public sealed class StepAddedEventArgs : EventArgs
{
    public StepAddedEventArgs(LearningStep step, string description)
    {
        Step = step ?? throw new ArgumentNullException(nameof(step));
        Description = string.IsNullOrWhiteSpace(description)
            ? throw new ArgumentException("A description is required.", nameof(description))
            : description.Trim();
    }

    public LearningStep Step { get; }

    public string Description { get; }
}