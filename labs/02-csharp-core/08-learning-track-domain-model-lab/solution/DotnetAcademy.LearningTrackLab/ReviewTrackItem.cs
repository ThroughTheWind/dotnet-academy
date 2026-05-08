namespace DotnetAcademy.LearningTrackLab;

public sealed class ReviewTrackItem : TrackItem
{
    public ReviewTrackItem(string code, string title, EffortEstimate effort, string reason)
        : base(code, title, effort)
    {
        Reason = string.IsNullOrWhiteSpace(reason)
            ? throw new ArgumentException("A reason is required.", nameof(reason))
            : reason.Trim().ToLowerInvariant();
    }

    public string Reason { get; }
}