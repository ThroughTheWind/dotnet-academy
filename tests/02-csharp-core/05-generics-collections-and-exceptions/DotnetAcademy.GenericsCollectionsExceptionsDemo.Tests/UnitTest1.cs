using DotnetAcademy.GenericsCollectionsExceptionsDemo;

namespace DotnetAcademy.GenericsCollectionsExceptionsDemo.Tests;

public class GenericsCollectionsExceptionsPresenterTests
{
	[Fact]
	public void PracticeResourceBuildSummaryIncludesFormatAndCategory()
	{
		var resource = new PracticeResource("generics-lesson", "Reuse one generic catalog safely", 20, "Generics", "Guided Lesson");

		Assert.Equal("Reuse one generic catalog safely (20 min guided lesson in generics)", resource.BuildSummary());
	}

	[Fact]
	public void StudyCatalogAddRejectsDuplicateIds()
	{
		var catalog = new StudyCatalog<PracticeResource>();
		var firstResource = new PracticeResource("shared-id", "First item", 10, "generics", "checkpoint");
		var duplicateResource = new PracticeResource("shared-id", "Second item", 15, "collections", "checkpoint");

		catalog.Add(firstResource);

		var exception = Assert.Throws<InvalidOperationException>(() => catalog.Add(duplicateResource));

		Assert.Equal("An item with id 'shared-id' already exists.", exception.Message);
	}

	[Fact]
	public void StudyCatalogGetByIdThrowsForMissingId()
	{
		var catalog = GenericsCollectionsExceptionsPresenter.BuildSampleCatalog();

		var exception = Assert.Throws<KeyNotFoundException>(() => catalog.GetById("missing-item"));

		Assert.Equal("No item was found for id 'missing-item'.", exception.Message);
	}

	[Fact]
	public void StudyCatalogFormatterBuildSummaryLinesUsesTypedResources()
	{
		var resources = new List<PracticeResource>
		{
			new("generics-lesson", "Reuse one generic catalog safely", 20, "generics", "guided lesson"),
			new("collections-checkpoint", "Compare collection choices with intent", 15, "collections", "code drill")
		};

		var lines = StudyCatalogFormatter.BuildSummaryLines(resources);

		Assert.Equal(2, lines.Count);
		Assert.Equal("- Reuse one generic catalog safely (20 min guided lesson in generics)", lines[0]);
		Assert.Equal("- Compare collection choices with intent (15 min code drill in collections)", lines[1]);
	}

	[Fact]
	public void BuildLinesIncludesCollectionCountsAndLookupNote()
	{
		var lines = GenericsCollectionsExceptionsPresenter.BuildLines();

		Assert.Contains("Items planned: 3", lines);
		Assert.Contains("Unique categories: 3", lines);
		Assert.Contains("Total estimate: 45 minutes", lines);
		Assert.Contains("- Guard invalid operations with exceptions (10 min checkpoint in exceptions)", lines);
		Assert.Contains("Lookup: Compare collection choices with intent (15 min code drill in collections)", lines);
		Assert.Contains("Lookup note: No item was found for id 'missing-item'. Guard invalid lookups at the boundary.", lines);
	}
}