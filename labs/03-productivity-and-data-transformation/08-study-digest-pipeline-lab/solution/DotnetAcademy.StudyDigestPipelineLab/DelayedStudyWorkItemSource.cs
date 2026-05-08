namespace DotnetAcademy.StudyDigestPipelineLab;

public sealed class DelayedStudyWorkItemSource(IEnumerable<StudyWorkItem> items, int delayMilliseconds) : IStudyWorkItemSource
{
    private readonly StudyWorkItem[] items = items?.ToArray()
        ?? throw new ArgumentNullException(nameof(items));

    private readonly int delayMilliseconds = delayMilliseconds >= 0
        ? delayMilliseconds
        : throw new ArgumentOutOfRangeException(nameof(delayMilliseconds));

    public async Task<IReadOnlyList<StudyWorkItem>> LoadAsync(CancellationToken cancellationToken = default)
    {
        if (delayMilliseconds > 0)
        {
            await Task.Delay(delayMilliseconds, cancellationToken);
        }

        if (items.Length == 0)
        {
            throw new InvalidOperationException("At least one study work item is required.");
        }

        return items;
    }
}