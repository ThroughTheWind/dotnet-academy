namespace DotnetAcademy.GenericsCollectionsExceptionsDemo;

public interface IPlannableResource
{
	string Id { get; }

	string Title { get; }

	int EstimatedMinutes { get; }

	string Category { get; }

	string BuildSummary();
}