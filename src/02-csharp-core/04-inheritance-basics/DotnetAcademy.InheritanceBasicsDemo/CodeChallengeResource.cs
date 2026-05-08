namespace DotnetAcademy.InheritanceBasicsDemo;

public sealed class CodeChallengeResource : LearningResource
{
    public CodeChallengeResource(string title, int estimatedMinutes, int expectedOutputs)
        : base(title, estimatedMinutes)
    {
        ExpectedOutputs = expectedOutputs > 0 ? expectedOutputs : throw new ArgumentOutOfRangeException(nameof(expectedOutputs), "Expected outputs must be greater than zero.");
    }

    public int ExpectedOutputs { get; }

    public override string BuildSummary()
    {
        return $"{Title} ({EstimatedMinutes} min challenge, {ExpectedOutputs} expected outputs)";
    }

    public override string GetFollowUpAction()
    {
        return "Run the challenge again with a different input set.";
    }
}