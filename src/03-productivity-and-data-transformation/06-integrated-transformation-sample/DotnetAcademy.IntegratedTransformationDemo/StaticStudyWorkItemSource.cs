namespace DotnetAcademy.IntegratedTransformationDemo;

public sealed class StaticStudyWorkItemSource(IEnumerable<StudyWorkItem> items) : IStudyWorkItemSource
{
    private readonly IReadOnlyList<StudyWorkItem> items = items?.ToArray()
        ?? throw new ArgumentNullException(nameof(items));

    public Task<IReadOnlyList<StudyWorkItem>> LoadAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(items);
    }
}