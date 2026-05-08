namespace DotnetAcademy.InterfacesCompositionDemo;

public interface ILearningActivity
{
    string Title { get; }

    int EstimatedMinutes { get; }

    string BuildSummary();
}