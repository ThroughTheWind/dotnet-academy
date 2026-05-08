namespace DotnetAcademy.StudyDigestPipelineLab;

public sealed class StudyDigestSettings
{
    public const string SectionName = "StudyDigest";

    public string OutputFolderName { get; set; } = "generated-output";

    public int MinimumPendingSteps { get; set; } = 2;

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(OutputFolderName))
        {
            throw new InvalidOperationException("The output folder name is required.");
        }

        if (MinimumPendingSteps < 1)
        {
            throw new InvalidOperationException("MinimumPendingSteps must be at least 1.");
        }
    }
}