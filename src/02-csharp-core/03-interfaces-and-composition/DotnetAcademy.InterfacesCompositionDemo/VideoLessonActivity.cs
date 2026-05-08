namespace DotnetAcademy.InterfacesCompositionDemo;

public sealed class VideoLessonActivity : ILearningActivity
{
    public VideoLessonActivity(string title, int estimatedMinutes)
    {
        Title = string.IsNullOrWhiteSpace(title) ? throw new ArgumentException("A title is required.", nameof(title)) : title.Trim();
        EstimatedMinutes = estimatedMinutes > 0 ? estimatedMinutes : throw new ArgumentOutOfRangeException(nameof(estimatedMinutes), "Estimated minutes must be greater than zero.");
    }

    public string Title { get; }

    public int EstimatedMinutes { get; }

    public string BuildSummary()
    {
        return $"{Title} ({EstimatedMinutes} min video lesson)";
    }
}