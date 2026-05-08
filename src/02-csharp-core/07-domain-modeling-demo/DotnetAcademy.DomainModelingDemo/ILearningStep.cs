namespace DotnetAcademy.DomainModelingDemo;

public interface ILearningStep
{
    string Code { get; }

    string Title { get; }

    EffortEstimate Effort { get; }

    string BuildSummary();
}