namespace DotnetAcademy.GenericsCollectionsExceptionsDemo;

public sealed class StudyCatalog<TItem> where TItem : IPlannableResource
{
	private readonly List<TItem> _orderedItems = [];
	private readonly Dictionary<string, TItem> _itemsById = new(StringComparer.OrdinalIgnoreCase);
	private readonly HashSet<string> _categories = new(StringComparer.OrdinalIgnoreCase);

	public void Add(TItem item)
	{
		ArgumentNullException.ThrowIfNull(item);

		if (!_itemsById.TryAdd(item.Id, item))
		{
			throw new InvalidOperationException($"An item with id '{item.Id}' already exists.");
		}

		_orderedItems.Add(item);
		_categories.Add(item.Category);
	}

	public IReadOnlyCollection<string> GetCategories()
	{
		return _categories;
	}

	public TItem GetById(string id)
	{
		if (string.IsNullOrWhiteSpace(id))
		{
			throw new ArgumentException("An id is required.", nameof(id));
		}

		return _itemsById.TryGetValue(id.Trim(), out var item)
			? item
			: throw new KeyNotFoundException($"No item was found for id '{id.Trim()}'.");
	}

	public IReadOnlyList<TItem> GetItems()
	{
		return _orderedItems;
	}

	public int GetTotalEstimatedMinutes()
	{
		var total = 0;

		foreach (var item in _orderedItems)
		{
			total += item.EstimatedMinutes;
		}

		return total;
	}
}