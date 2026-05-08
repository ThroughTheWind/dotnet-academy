namespace DotnetAcademy.ReadOnlyImmutableFrozenCollectionsDemo;

public sealed record PublishedGuideCard(string Code, string Title, string Category, int EstimatedMinutes)
{
    public static PublishedGuideCard FromEntry(StudyGuideEntry entry)
    {
        ArgumentNullException.ThrowIfNull(entry);

        return new PublishedGuideCard(entry.Code, entry.Title, entry.Category, entry.EstimatedMinutes);
    }
}