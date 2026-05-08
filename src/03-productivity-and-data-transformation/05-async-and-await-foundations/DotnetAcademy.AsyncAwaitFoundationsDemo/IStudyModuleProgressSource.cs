namespace DotnetAcademy.AsyncAwaitFoundationsDemo;

public interface IStudyModuleProgressSource
{
    Task<StudyModuleProgress> LoadAsync();
}