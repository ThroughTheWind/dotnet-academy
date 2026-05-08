namespace DotnetAcademy.LearningTrackLab;

public sealed class TrackItemScheduledEventArgs : EventArgs
{
    public TrackItemScheduledEventArgs(TrackItem item, string description)
    {
        Item = item ?? throw new ArgumentNullException(nameof(item));
        Description = string.IsNullOrWhiteSpace(description)
            ? throw new ArgumentException("A description is required.", nameof(description))
            : description.Trim();
    }

    public TrackItem Item { get; }

    public string Description { get; }
}