namespace DotnetAcademy.DomainModelingDemo;

public interface IWorkloadAdvisor
{
    string BuildNote(IReadOnlyList<LearningStep> steps);
}