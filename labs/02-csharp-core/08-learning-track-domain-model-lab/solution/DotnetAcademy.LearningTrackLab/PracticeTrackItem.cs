namespace DotnetAcademy.LearningTrackLab;

public sealed class PracticeTrackItem : TrackItem
{
    public PracticeTrackItem(string code, string title, EffortEstimate effort, PracticeMode mode, int suggestedRepeats)
        : base(code, title, effort)
    {
        Mode = mode;
        SuggestedRepeats = suggestedRepeats > 0
            ? suggestedRepeats
            : throw new ArgumentOutOfRangeException(nameof(suggestedRepeats), "Suggested repeats must be greater than zero.");
    }

    public PracticeMode Mode { get; }

    public int SuggestedRepeats { get; }
}