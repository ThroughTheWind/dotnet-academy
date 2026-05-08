using System.Diagnostics.CodeAnalysis;

namespace DotnetAcademy.CollectionsTradeoffsDemo;

public sealed class StudyBoard
{
    private readonly List<StudyBoardItem> _items = [];
    private readonly Dictionary<string, StudyBoardItem> _itemsByCode = new(StringComparer.OrdinalIgnoreCase);
    private readonly HashSet<string> _categories = new(StringComparer.OrdinalIgnoreCase);

    public int CategoryCount => _categories.Count;

    public int CompletedCount => _items.Count(item => item.Completed);

    public int TotalCount => _items.Count;

    public void Add(StudyBoardItem item)
    {
        ArgumentNullException.ThrowIfNull(item);

        if (!_itemsByCode.TryAdd(item.Code, item))
        {
            throw new InvalidOperationException("An item with the same code already exists.");
        }

        _items.Add(item);
        _categories.Add(item.Category);
    }

    public IReadOnlyList<string> BuildCategorySummary()
    {
        return _items
            .GroupBy(item => item.Category)
            .OrderBy(group => group.Key)
            .Select(group => $"{group.Key}: {group.Count()} items")
            .ToList();
    }

    public IReadOnlyList<string> BuildPriorityTitles()
    {
        return _items
            .Where(item => !item.Completed)
            .OrderBy(item => item.Priority)
            .ThenBy(item => item.Title)
            .Select(item => $"{item.Code}: {item.Title} [{item.Category}]")
            .ToList();
    }

    public void MarkComplete(string code)
    {
        if (!TryFindByCode(code, out var item))
        {
            throw new KeyNotFoundException($"No study board item was found for code '{code}'.");
        }

        item.MarkComplete();
    }

    public PublishedStudyBoardSnapshot PublishSnapshot()
    {
        var priorityTitles = BuildPriorityTitles().ToArray();
        var categorySummary = BuildCategorySummary().ToArray();

        return new PublishedStudyBoardSnapshot(
            TotalCount,
            CompletedCount,
            priorityTitles,
            categorySummary);
    }

    public bool TryFindByCode(string code, [NotNullWhen(true)] out StudyBoardItem? item)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            throw new ArgumentException("A code is required.", nameof(code));
        }

        return _itemsByCode.TryGetValue(code.Trim(), out item);
    }
}