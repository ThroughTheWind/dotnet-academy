using DotnetAcademy.LearningTrackLab;

namespace DotnetAcademy.LearningTrackLab.Tests;

public class LearningTrackPresenterTests
{
    private static readonly string[] EmptyArguments = [];
    private static readonly string[] AdaArguments = ["Ada"];

    [Fact]
    public void GetLearnerNameReturnsFallbackWhenArgumentsAreMissing()
    {
        var learnerName = LearningTrackPresenter.GetLearnerName(EmptyArguments);

        Assert.Equal("Learner", learnerName);
    }

    [Fact]
    public void TrackCatalogAddRejectsDuplicateCodes()
    {
        var catalog = new TrackCatalog<TrackItem>();
        catalog.Add(new LessonTrackItem("TRACK-01", "Design shared abstractions", new EffortEstimate(25), "interfaces", true));

        var exception = Assert.Throws<InvalidOperationException>(() =>
            catalog.Add(new ReviewTrackItem("TRACK-01", "Duplicate code", new EffortEstimate(10), "duplicate validation")));

        Assert.Equal("A track item with code 'TRACK-01' already exists.", exception.Message);
    }

    [Fact]
    public void LearningTrackScheduleRaisesItemScheduledEvent()
    {
        var track = new LearningTrack("Ada");
        string? capturedDescription = null;

        track.ItemScheduled += (_, args) => capturedDescription = args.Description;
        track.Schedule(new PracticeTrackItem("TRACK-02", "Compare value and reference semantics", new EffortEstimate(20), PracticeMode.Pair, 2));

        Assert.Equal("Practice TRACK-02 => Compare value and reference semantics (20 min pair exercise, repeat 2 times).", capturedDescription);
    }

    [Fact]
    public void TrackItemDescriberUsesPatternMatchingForReviewItem()
    {
        var description = TrackItemDescriber.Describe(
            new ReviewTrackItem("TRACK-03", "Revisit pattern matching summaries", new EffortEstimate(15), "the wording still feels awkward"));

        Assert.Equal("Review TRACK-03 => Revisit pattern matching summaries (15 min review because the wording still feels awkward).", description);
    }

    [Fact]
    public void BuildLinesIncludesAgendaFocusListAndLookupNote()
    {
        var lines = LearningTrackPresenter.BuildLines(AdaArguments);

        Assert.Contains("Learner: Ada", lines);
        Assert.Contains("Added: Lesson TRACK-01 => Design shared abstractions (25 min lesson on interfaces with walkthrough).", lines);
        Assert.Contains("Agenda:", lines);
        Assert.Contains("Focus list:", lines);
        Assert.Contains("- Practice TRACK-02 => Compare value and reference semantics (20 min pair exercise, repeat 2 times).", lines);
        Assert.Contains("Lookup note: No track item was found for code 'TRACK-99'.", lines);
        Assert.Contains("Design note: long-lived track items stay as reference types, while small effort estimates stay value-like and copy safely.", lines);
    }
}