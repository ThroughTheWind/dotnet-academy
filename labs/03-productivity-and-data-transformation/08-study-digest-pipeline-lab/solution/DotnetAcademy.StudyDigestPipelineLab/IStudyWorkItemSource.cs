namespace DotnetAcademy.StudyDigestPipelineLab;

public interface IStudyWorkItemSource
{
    Task<IReadOnlyList<StudyWorkItem>> LoadAsync(CancellationToken cancellationToken = default);
}