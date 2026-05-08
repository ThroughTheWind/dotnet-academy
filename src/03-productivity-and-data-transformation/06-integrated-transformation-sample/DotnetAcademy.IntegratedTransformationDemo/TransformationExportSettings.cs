namespace DotnetAcademy.IntegratedTransformationDemo;

public sealed class TransformationExportSettings
{
    public const string SectionName = "IntegratedTransformation";

    public string OutputFolderName { get; set; } = "generated-output";

    public int MinimumPendingSteps { get; set; } = 2;

    public string[] FocusCategories { get; set; } = [];

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

        FocusCategories ??= [];

        if (FocusCategories.Any(string.IsNullOrWhiteSpace))
        {
            throw new InvalidOperationException("FocusCategories cannot contain blank values.");
        }
    }
}