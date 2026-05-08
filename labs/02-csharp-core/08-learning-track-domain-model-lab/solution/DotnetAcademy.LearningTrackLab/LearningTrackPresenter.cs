namespace DotnetAcademy.LearningTrackLab;

public static class LearningTrackPresenter
{
    public static IReadOnlyList<string> BuildLines(string[] args)
    {
        var catalog = BuildCatalog();
        var notifications = new List<string>();
        var track = new LearningTrack(GetLearnerName(args));

        track.ItemScheduled += HandleItemScheduled;
        track.Schedule(catalog.FindByCode("TRACK-01"));
        track.Schedule(catalog.FindByCode("TRACK-02"));
        track.Schedule(catalog.FindByCode("TRACK-03"));
        track.ItemScheduled -= HandleItemScheduled;

        TrackItemFilter focusFilter = item => item is PracticeTrackItem { Mode: PracticeMode.Pair } or ReviewTrackItem;

        var lines = new List<string>
        {
            "Learning Track Planner",
            "----------------------",
            $"Learner: {track.LearnerName}"
        };

        lines.AddRange(notifications);
        lines.Add("Agenda:");

        foreach (var item in track.GetAgenda())
        {
            lines.Add($"- {TrackItemDescriber.Describe(item)}");
        }

        lines.Add("Focus list:");

        foreach (var item in track.GetFocusItems(focusFilter))
        {
            lines.Add($"- {TrackItemDescriber.Describe(item)}");
        }

        try
        {
            _ = catalog.FindByCode("TRACK-99");
        }
        catch (KeyNotFoundException ex)
        {
            lines.Add($"Lookup note: {ex.Message}");
        }

        lines.Add("Design note: long-lived track items stay as reference types, while small effort estimates stay value-like and copy safely.");

        return lines;

        void HandleItemScheduled(object? sender, TrackItemScheduledEventArgs args)
        {
            notifications.Add($"Added: {args.Description}");
        }
    }

    public static TrackCatalog<TrackItem> BuildCatalog()
    {
        var catalog = new TrackCatalog<TrackItem>();

        catalog.Add(new LessonTrackItem("TRACK-01", "Design shared abstractions", new EffortEstimate(25), "interfaces", true));
        catalog.Add(new PracticeTrackItem("TRACK-02", "Compare value and reference semantics", new EffortEstimate(20), PracticeMode.Pair, 2));
        catalog.Add(new ReviewTrackItem("TRACK-03", "Revisit pattern matching summaries", new EffortEstimate(15), "the wording still feels awkward"));

        return catalog;
    }

    public static string GetLearnerName(string[] args)
    {
        return args.Length > 0 && !string.IsNullOrWhiteSpace(args[0])
            ? args[0].Trim()
            : "Learner";
    }
}