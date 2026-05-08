using System.Collections.Frozen;
using System.Collections.Immutable;

namespace DotnetAcademy.ReadOnlyImmutableFrozenCollectionsDemo;

public static class ReadOnlyImmutableFrozenPresenter
{
    public static IReadOnlyList<string> BuildLines()
    {
        var library = BuildSampleLibrary();
        var readOnlyView = library.CreateReadOnlyView();
        var immutableSnapshot = library.CreateImmutableSnapshot();
        var frozenLookup = library.CreateFrozenLookup();
        var frozenCategories = library.CreateFrozenCategorySet();

        library.Add(new StudyGuideEntry("GUIDE-04", "Build a frozen category index", "frozen", 12));

        return
        [
            "Dotnet Academy: Read-Only, Immutable, and Frozen Collection Tradeoffs",
            "--------------------------------------------------------------------",
            $"Read-only view count after live update: {readOnlyView.Count}",
            $"Immutable snapshot count: {immutableSnapshot.Length}",
            $"Frozen lookup count: {frozenLookup.Count}",
            $"Frozen category set contains 'frozen': {frozenCategories.Contains("frozen")}",
            $"Read-only latest item: {readOnlyView[^1].Code} => {readOnlyView[^1].Title}",
            $"Immutable snapshot still ends with: {immutableSnapshot[^1].Code} => {immutableSnapshot[^1].Title}",
            $"Frozen lookup contains guide-02: {frozenLookup.ContainsKey("guide-02")}",
            $"Frozen lookup contains GUIDE-04: {frozenLookup.ContainsKey("GUIDE-04")}",
            "Tradeoff note: read-only hides mutators but can still reflect live changes, immutable snapshots stay stable, and frozen collections pay build cost once for repeated lookup speed."
        ];
    }

    public static StudyGuideLibrary BuildSampleLibrary()
    {
        var library = new StudyGuideLibrary();
        library.Add(new StudyGuideEntry("GUIDE-01", "Expose a live read-only view", "read-only", 10));
        library.Add(new StudyGuideEntry("GUIDE-02", "Prefer immutable snapshots for published packs", "immutability", 18));
        library.Add(new StudyGuideEntry("GUIDE-03", "Freeze repeated lookups after configuration loads", "performance", 15));
        return library;
    }
}