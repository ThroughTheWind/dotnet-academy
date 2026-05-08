namespace DotnetAcademy.InheritanceBasicsDemo;

public sealed class GuidedLessonResource : LearningResource
{
    public GuidedLessonResource(string title, int estimatedMinutes, string focusArea)
        : base(title, estimatedMinutes)
    {
        FocusArea = string.IsNullOrWhiteSpace(focusArea) ? throw new ArgumentException("A focus area is required.", nameof(focusArea)) : focusArea.Trim();
    }

    public string FocusArea { get; }

    public override string BuildSummary()
    {
        return $"{Title} ({EstimatedMinutes} min guided lesson on {FocusArea})";
    }
}