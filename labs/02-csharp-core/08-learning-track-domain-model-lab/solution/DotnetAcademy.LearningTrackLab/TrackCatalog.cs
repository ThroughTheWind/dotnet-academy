namespace DotnetAcademy.LearningTrackLab;

public sealed class TrackCatalog<TItem> where TItem : ITrackItem
{
    private readonly List<TItem> _items = [];
    private readonly Dictionary<string, TItem> _itemsByCode = new(StringComparer.OrdinalIgnoreCase);

    public void Add(TItem item)
    {
        ArgumentNullException.ThrowIfNull(item);

        if (!_itemsByCode.TryAdd(item.Code, item))
        {
            throw new InvalidOperationException($"A track item with code '{item.Code}' already exists.");
        }

        _items.Add(item);
    }

    public TItem FindByCode(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            throw new ArgumentException("A code is required.", nameof(code));
        }

        return _itemsByCode.TryGetValue(code.Trim(), out var item)
            ? item
            : throw new KeyNotFoundException($"No track item was found for code '{code.Trim()}'.");
    }

    public IReadOnlyList<TItem> GetAll()
    {
        return _items;
    }
}