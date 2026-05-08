namespace DotnetAcademy.GenericsCollectionsExceptionsDemo;

public sealed class PracticeResource : IPlannableResource
{
	public PracticeResource(string id, string title, int estimatedMinutes, string category, string format)
	{
		Id = string.IsNullOrWhiteSpace(id) ? throw new ArgumentException("An id is required.", nameof(id)) : id.Trim();
		Title = string.IsNullOrWhiteSpace(title) ? throw new ArgumentException("A title is required.", nameof(title)) : title.Trim();
		EstimatedMinutes = estimatedMinutes > 0 ? estimatedMinutes : throw new ArgumentOutOfRangeException(nameof(estimatedMinutes), "Estimated minutes must be greater than zero.");
		Category = string.IsNullOrWhiteSpace(category) ? throw new ArgumentException("A category is required.", nameof(category)) : category.Trim().ToLowerInvariant();
		Format = string.IsNullOrWhiteSpace(format) ? throw new ArgumentException("A format is required.", nameof(format)) : format.Trim().ToLowerInvariant();
	}

	public string Id { get; }

	public string Title { get; }

	public int EstimatedMinutes { get; }

	public string Category { get; }

	public string Format { get; }

	public string BuildSummary()
	{
		return $"{Title} ({EstimatedMinutes} min {Format} in {Category})";
	}
}