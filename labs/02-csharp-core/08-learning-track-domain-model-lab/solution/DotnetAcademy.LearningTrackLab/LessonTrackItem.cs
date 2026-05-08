namespace DotnetAcademy.LearningTrackLab;

public sealed class LessonTrackItem : TrackItem
{
    public LessonTrackItem(string code, string title, EffortEstimate effort, string focusArea, bool includesWalkthrough)
        : base(code, title, effort)
    {
        FocusArea = string.IsNullOrWhiteSpace(focusArea)
            ? throw new ArgumentException("A focus area is required.", nameof(focusArea))
            : focusArea.Trim().ToLowerInvariant();
        IncludesWalkthrough = includesWalkthrough;
    }

    public string FocusArea { get; }

    public bool IncludesWalkthrough { get; }
}