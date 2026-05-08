namespace DotnetAcademy.LearningTrackLab;

public readonly record struct EffortEstimate
{
    public EffortEstimate(int minutes)
    {
        Minutes = minutes > 0
            ? minutes
            : throw new ArgumentOutOfRangeException(nameof(minutes), "Minutes must be greater than zero.");
    }

    public int Minutes { get; }

    public override string ToString()
    {
        return $"{Minutes} min";
    }
}