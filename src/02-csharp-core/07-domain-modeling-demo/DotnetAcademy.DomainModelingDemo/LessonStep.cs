namespace DotnetAcademy.DomainModelingDemo;

public sealed class LessonStep : LearningStep
{
    public LessonStep(string code, string title, EffortEstimate effort, string focusArea, bool includesWalkthrough)
        : base(code, title, effort)
    {
        FocusArea = string.IsNullOrWhiteSpace(focusArea)
            ? throw new ArgumentException("A focus area is required.", nameof(focusArea))
            : focusArea.Trim().ToLowerInvariant();
        IncludesWalkthrough = includesWalkthrough;
    }

    public string FocusArea { get; }

    public bool IncludesWalkthrough { get; }

    public override string BuildSummary()
    {
        var walkthroughNote = IncludesWalkthrough ? "with walkthrough" : "without walkthrough";
        return $"{Code} {Title} ({Effort} lesson on {FocusArea}, {walkthroughNote})";
    }
}