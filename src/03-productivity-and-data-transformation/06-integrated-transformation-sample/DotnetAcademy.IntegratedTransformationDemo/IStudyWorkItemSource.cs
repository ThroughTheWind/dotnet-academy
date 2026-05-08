namespace DotnetAcademy.IntegratedTransformationDemo;

public interface IStudyWorkItemSource
{
    Task<IReadOnlyList<StudyWorkItem>> LoadAsync(CancellationToken cancellationToken = default);
}