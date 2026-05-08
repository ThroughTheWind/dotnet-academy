namespace DotnetAcademy.LearningTrackLab;

public interface ITrackItem
{
    string Code { get; }

    string Title { get; }

    EffortEstimate Effort { get; }
}