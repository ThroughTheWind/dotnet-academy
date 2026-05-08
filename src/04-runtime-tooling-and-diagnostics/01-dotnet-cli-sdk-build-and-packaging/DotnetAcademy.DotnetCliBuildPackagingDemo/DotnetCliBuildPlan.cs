namespace DotnetAcademy.DotnetCliBuildPackagingDemo;

public sealed record DotnetCliBuildPlan(
    DotnetSdkPin SdkPin,
    DotnetProjectProfile Project,
    string Configuration,
    string BuildOutputDirectory,
    string? PackageArtifactName,
    IReadOnlyList<DotnetCliCommandStep> Steps);