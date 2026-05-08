using DotnetAcademy.ReadOnlyImmutableFrozenCollectionsDemo;

namespace DotnetAcademy.ReadOnlyImmutableFrozenCollectionsDemo.Tests;

public class ReadOnlyImmutableFrozenPresenterTests
{
    [Fact]
    public void CreateReadOnlyViewReflectsLaterAdditions()
    {
        var library = ReadOnlyImmutableFrozenPresenter.BuildSampleLibrary();
        var view = library.CreateReadOnlyView();

        library.Add(new StudyGuideEntry("GUIDE-04", "Build a frozen category index", "frozen", 12));

        Assert.Equal(4, view.Count);
        Assert.Equal("GUIDE-04", view[^1].Code);
    }

    [Fact]
    public void CreateImmutableSnapshotKeepsOriginalCardsAfterLaterAddition()
    {
        var library = ReadOnlyImmutableFrozenPresenter.BuildSampleLibrary();
        var snapshot = library.CreateImmutableSnapshot();

        library.Add(new StudyGuideEntry("GUIDE-04", "Build a frozen category index", "frozen", 12));

        Assert.Equal(3, snapshot.Length);
        Assert.Equal("GUIDE-03", snapshot[^1].Code);
    }

    [Fact]
    public void CreateFrozenLookupSupportsCaseInsensitiveReadsAndStaysFixed()
    {
        var library = ReadOnlyImmutableFrozenPresenter.BuildSampleLibrary();
        var lookup = library.CreateFrozenLookup();

        library.Add(new StudyGuideEntry("GUIDE-04", "Build a frozen category index", "frozen", 12));

        Assert.True(lookup.TryGetValue("guide-02", out var card));
        Assert.NotNull(card);
        Assert.Equal("Prefer immutable snapshots for published packs", card.Title);
        Assert.False(lookup.ContainsKey("GUIDE-04"));
    }

    [Fact]
    public void CreateFrozenCategorySetCapturesOriginalCategoriesOnly()
    {
        var library = ReadOnlyImmutableFrozenPresenter.BuildSampleLibrary();
        var categories = library.CreateFrozenCategorySet();

        library.Add(new StudyGuideEntry("GUIDE-04", "Build a frozen category index", "frozen", 12));

        Assert.Equal(3, categories.Count);
        Assert.DoesNotContain("frozen", categories.ToArray());
    }

    [Fact]
    public void BuildLinesIncludesTradeoffComparison()
    {
        var lines = ReadOnlyImmutableFrozenPresenter.BuildLines();

        Assert.Contains("Read-only view count after live update: 4", lines);
        Assert.Contains("Immutable snapshot count: 3", lines);
        Assert.Contains("Frozen lookup contains GUIDE-04: False", lines);
        Assert.Contains("Tradeoff note: read-only hides mutators but can still reflect live changes, immutable snapshots stay stable, and frozen collections pay build cost once for repeated lookup speed.", lines);
    }
}