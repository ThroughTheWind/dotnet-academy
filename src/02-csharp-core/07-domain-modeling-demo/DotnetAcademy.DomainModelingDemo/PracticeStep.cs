namespace DotnetAcademy.DomainModelingDemo;

public sealed class PracticeStep : LearningStep
{
    public PracticeStep(string code, string title, EffortEstimate effort, PracticeStyle style, int suggestedRepeats)
        : base(code, title, effort)
    {
        SuggestedRepeats = suggestedRepeats > 0
            ? suggestedRepeats
            : throw new ArgumentOutOfRangeException(nameof(suggestedRepeats), "Suggested repeats must be greater than zero.");
        Style = style;
    }

    public PracticeStyle Style { get; }

    public int SuggestedRepeats { get; }

    public override string BuildSummary()
    {
        return $"{Code} {Title} ({Effort} {Style.ToString().ToLowerInvariant()} practice, repeat {SuggestedRepeats} times)";
    }
}