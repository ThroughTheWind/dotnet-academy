namespace DotnetAcademy.LearningTrackLab;

public sealed class LearningTrack
{
    private readonly List<TrackItem> _scheduledItems = [];

    public LearningTrack(string learnerName)
    {
        LearnerName = string.IsNullOrWhiteSpace(learnerName) ? "Learner" : learnerName.Trim();
    }

    public event EventHandler<TrackItemScheduledEventArgs>? ItemScheduled;

    public string LearnerName { get; }

    public void Schedule(TrackItem item)
    {
        ArgumentNullException.ThrowIfNull(item);

        _scheduledItems.Add(item);
        ItemScheduled?.Invoke(this, new TrackItemScheduledEventArgs(item, TrackItemDescriber.Describe(item)));
    }

    public IReadOnlyList<TrackItem> GetAgenda()
    {
        return _scheduledItems;
    }

    public IReadOnlyList<TrackItem> GetFocusItems(TrackItemFilter filter)
    {
        ArgumentNullException.ThrowIfNull(filter);

        var matches = new List<TrackItem>();

        foreach (var item in _scheduledItems)
        {
            if (filter(item))
            {
                matches.Add(item);
            }
        }

        return matches;
    }
}