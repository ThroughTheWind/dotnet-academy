namespace DotnetAcademy.GenericsCollectionsExceptionsDemo;

public static class GenericsCollectionsExceptionsPresenter
{
	public static IReadOnlyList<string> BuildLines()
	{
		var catalog = BuildSampleCatalog();
		var lines = new List<string>
		{
			"Dotnet Academy: Generics, Collections, and Exceptions",
			"------------------------------------------------------",
			$"Items planned: {catalog.GetItems().Count}",
			$"Unique categories: {catalog.GetCategories().Count}",
			$"Total estimate: {catalog.GetTotalEstimatedMinutes()} minutes",
			"Catalog entries:"
		};

		lines.AddRange(StudyCatalogFormatter.BuildSummaryLines(catalog.GetItems()));
		lines.Add($"Lookup: {catalog.GetById("collections-checkpoint").BuildSummary()}");
		lines.Add($"Lookup note: {BuildMissingItemNote(catalog, "missing-item")}");

		return lines;
	}

	public static StudyCatalog<PracticeResource> BuildSampleCatalog()
	{
		var catalog = new StudyCatalog<PracticeResource>();

		catalog.Add(new PracticeResource("generics-lesson", "Reuse one generic catalog safely", 20, "generics", "guided lesson"));
		catalog.Add(new PracticeResource("collections-checkpoint", "Compare collection choices with intent", 15, "collections", "code drill"));
		catalog.Add(new PracticeResource("exceptions-checkpoint", "Guard invalid operations with exceptions", 10, "exceptions", "checkpoint"));

		return catalog;
	}

	public static string BuildMissingItemNote<TItem>(StudyCatalog<TItem> catalog, string id) where TItem : IPlannableResource
	{
		ArgumentNullException.ThrowIfNull(catalog);

		try
		{
			_ = catalog.GetById(id);
			return "The requested item existed, so no exception note was needed.";
		}
		catch (KeyNotFoundException ex)
		{
			return $"{ex.Message} Guard invalid lookups at the boundary.";
		}
	}
}