namespace DotnetAcademy.AsyncAwaitFoundationsDemo;

public sealed class DelayedStudyModuleProgressSource : IStudyModuleProgressSource
{
    private readonly int _delayMilliseconds;
    private readonly StudyModuleProgress _progress;

    public DelayedStudyModuleProgressSource(StudyModuleProgress progress, int delayMilliseconds)
    {
        _progress = progress ?? throw new ArgumentNullException(nameof(progress));
        _delayMilliseconds = delayMilliseconds >= 0
            ? delayMilliseconds
            : throw new ArgumentOutOfRangeException(nameof(delayMilliseconds), "Delay must be zero or greater.");
    }

    public async Task<StudyModuleProgress> LoadAsync()
    {
        await Task.Delay(_delayMilliseconds);
        return _progress;
    }
}