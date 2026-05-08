namespace DotnetAcademy.GenericsCollectionsExceptionsDemo;

public static class StudyCatalogFormatter
{
	public static IReadOnlyList<string> BuildSummaryLines<TItem>(IEnumerable<TItem> items) where TItem : IPlannableResource
	{
		ArgumentNullException.ThrowIfNull(items);

		var lines = new List<string>();

		foreach (var item in items)
		{
			lines.Add($"- {item.BuildSummary()}");
		}

		return lines;
	}
}