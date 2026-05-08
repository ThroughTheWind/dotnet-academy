using System.Runtime.CompilerServices;

namespace DotnetAcademy.IntegratedTransformationDemo;

public sealed class DelayedStudyWorkItemFeed(IEnumerable<ScheduledStudyWorkItem> scheduledItems)
{
    private readonly IReadOnlyList<ScheduledStudyWorkItem> scheduledItems = scheduledItems?.ToArray()
        ?? throw new ArgumentNullException(nameof(scheduledItems));

    public async IAsyncEnumerable<StudyWorkItem> ReadAllAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        foreach (var scheduledItem in scheduledItems)
        {
            if (scheduledItem.DelayMilliseconds > 0)
            {
                await Task.Delay(scheduledItem.DelayMilliseconds, cancellationToken);
            }

            cancellationToken.ThrowIfCancellationRequested();
            yield return scheduledItem.Item;
        }
    }
}