namespace DotnetAcademy.ReadOnlyImmutableFrozenCollectionsDemo;

public sealed class StudyGuideEntry
{
    public StudyGuideEntry(string code, string title, string category, int estimatedMinutes)
    {
        Code = string.IsNullOrWhiteSpace(code)
            ? throw new ArgumentException("A code is required.", nameof(code))
            : code.Trim().ToUpperInvariant();
        Title = string.IsNullOrWhiteSpace(title)
            ? throw new ArgumentException("A title is required.", nameof(title))
            : title.Trim();
        Category = string.IsNullOrWhiteSpace(category)
            ? throw new ArgumentException("A category is required.", nameof(category))
            : category.Trim().ToLowerInvariant();
        EstimatedMinutes = estimatedMinutes > 0
            ? estimatedMinutes
            : throw new ArgumentOutOfRangeException(nameof(estimatedMinutes), "Estimated minutes must be greater than zero.");
    }

    public string Code { get; }

    public string Title { get; }

    public string Category { get; }

    public int EstimatedMinutes { get; }
}