using System.Runtime.CompilerServices;

namespace DotnetAcademy.CancellationAsyncStreamsValueTaskDemo;

public sealed class DelayedStudyUpdateFeed(IEnumerable<ScheduledStudyUpdate> scheduledUpdates)
{
    private readonly IReadOnlyList<ScheduledStudyUpdate> scheduledUpdates = scheduledUpdates?.ToArray()
        ?? throw new ArgumentNullException(nameof(scheduledUpdates));

    public async IAsyncEnumerable<StudyUpdate> ReadAllAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        foreach (var scheduledUpdate in scheduledUpdates)
        {
            if (scheduledUpdate.DelayMilliseconds > 0)
            {
                await Task.Delay(scheduledUpdate.DelayMilliseconds, cancellationToken);
            }

            cancellationToken.ThrowIfCancellationRequested();
            yield return scheduledUpdate.Update;
        }
    }
}