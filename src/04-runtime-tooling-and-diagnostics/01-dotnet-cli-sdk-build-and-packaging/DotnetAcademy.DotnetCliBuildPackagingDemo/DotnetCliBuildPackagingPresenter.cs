namespace DotnetAcademy.DotnetCliBuildPackagingDemo;

public static class DotnetCliBuildPackagingPresenter
{
    public static IReadOnlyList<string> BuildLines(string baseDirectory)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(baseDirectory);

        var sdkPin = DotnetCliBuildPackagingWorkflow.LoadPinnedSdk(Path.Combine(baseDirectory, "seed", "global.json"));
        var profile = DotnetCliBuildPackagingWorkflow.LoadProjectProfile(Path.Combine(baseDirectory, "seed", "study-tooling-sample.xml"));
        var plan = DotnetCliBuildPackagingWorkflow.BuildPlan(sdkPin, profile);

        var lines = new List<string>
        {
            ".NET CLI, SDK, Build, And Packaging Demo",
            "----------------------------------------",
            $"SDK pin: {sdkPin.Version}{FormatRollForward(sdkPin.RollForward)}",
            $"Sample project: {profile.AssemblyName}",
            $"Target framework: {profile.TargetFramework}",
            $"Output type: {profile.OutputType}",
            $"Package ID: {profile.PackageId}",
            $"Packable: {profile.IsPackable}",
            $"Release output: {plan.BuildOutputDirectory}"
        };

        lines.Add(plan.PackageArtifactName is not null
            ? $"Expected package artifact: {plan.PackageArtifactName}"
            : "Expected package artifact: none (the sample project is not packable)");

        lines.Add("Command flow:");
        foreach (var step in plan.Steps)
        {
            lines.Add($"- {step.Title}: {step.Command}");
        }

        lines.Add(plan.PackageArtifactName is not null
            ? "Packaging note: pack is appropriate here because the sample project is a reusable library with a PackageId, a Version, and IsPackable set to true."
            : "Packaging note: pack is skipped here because the project is not intended to produce a NuGet package.");

        return lines;
    }

    private static string FormatRollForward(string? rollForward)
    {
        return string.IsNullOrWhiteSpace(rollForward)
            ? string.Empty
            : $" (rollForward: {rollForward})";
    }
}