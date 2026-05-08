namespace DotnetAcademy.IntegratedTransformationDemo;

public sealed class StreamingStudyWorkItemSource(IAsyncEnumerable<StudyWorkItem> feed) : IStudyWorkItemSource
{
    private readonly IAsyncEnumerable<StudyWorkItem> feed = feed ?? throw new ArgumentNullException(nameof(feed));

    public async Task<IReadOnlyList<StudyWorkItem>> LoadAsync(CancellationToken cancellationToken = default)
    {
        var items = new List<StudyWorkItem>();

        await foreach (var item in feed.WithCancellation(cancellationToken))
        {
            items.Add(item);
        }

        if (items.Count == 0)
        {
            throw new InvalidOperationException("At least one streamed study work item is required.");
        }

        return items;
    }
}