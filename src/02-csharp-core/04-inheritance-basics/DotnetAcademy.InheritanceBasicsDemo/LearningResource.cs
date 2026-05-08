namespace DotnetAcademy.InheritanceBasicsDemo;

public abstract class LearningResource
{
    protected LearningResource(string title, int estimatedMinutes)
    {
        Title = string.IsNullOrWhiteSpace(title) ? throw new ArgumentException("A title is required.", nameof(title)) : title.Trim();
        EstimatedMinutes = estimatedMinutes > 0 ? estimatedMinutes : throw new ArgumentOutOfRangeException(nameof(estimatedMinutes), "Estimated minutes must be greater than zero.");
    }

    public string Title { get; }

    public int EstimatedMinutes { get; }

    public abstract string BuildSummary();

    public virtual string GetFollowUpAction()
    {
        return "Review the key idea once before moving on.";
    }
}