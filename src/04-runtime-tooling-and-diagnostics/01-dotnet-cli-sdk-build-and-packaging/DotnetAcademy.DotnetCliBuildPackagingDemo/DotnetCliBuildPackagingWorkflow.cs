using System.Text.Json;
using System.Xml.Linq;

namespace DotnetAcademy.DotnetCliBuildPackagingDemo;

public static class DotnetCliBuildPackagingWorkflow
{
    public static DotnetSdkPin LoadPinnedSdk(string globalJsonPath)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(globalJsonPath);

        if (!File.Exists(globalJsonPath))
        {
            throw new FileNotFoundException("Could not find the global.json file.", globalJsonPath);
        }

        using var stream = File.OpenRead(globalJsonPath);
        using var document = JsonDocument.Parse(stream);

        if (!document.RootElement.TryGetProperty("sdk", out var sdkElement))
        {
            throw new InvalidOperationException("global.json must contain an sdk object.");
        }

        if (!sdkElement.TryGetProperty("version", out var versionElement))
        {
            throw new InvalidOperationException("global.json must contain sdk.version.");
        }

        var version = versionElement.GetString();
        if (string.IsNullOrWhiteSpace(version))
        {
            throw new InvalidOperationException("global.json must contain a non-empty sdk.version value.");
        }

        string? rollForward = null;
        if (sdkElement.TryGetProperty("rollForward", out var rollForwardElement))
        {
            rollForward = rollForwardElement.GetString();
        }

        return new DotnetSdkPin(version, string.IsNullOrWhiteSpace(rollForward) ? null : rollForward);
    }

    public static DotnetProjectProfile LoadProjectProfile(string projectXmlPath)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(projectXmlPath);

        if (!File.Exists(projectXmlPath))
        {
            throw new FileNotFoundException("Could not find the project metadata file.", projectXmlPath);
        }

        var document = XDocument.Load(projectXmlPath);
        var projectElement = document.Root;

        if (projectElement is null || !string.Equals(projectElement.Name.LocalName, "Project", StringComparison.Ordinal))
        {
            throw new InvalidOperationException("The project metadata file must contain a Project root element.");
        }

        var sdkName = projectElement.Attribute("Sdk")?.Value?.Trim();
        if (string.IsNullOrWhiteSpace(sdkName))
        {
            throw new InvalidOperationException("The project metadata file must declare a Project Sdk attribute.");
        }

        var assemblyName = GetRequiredPropertyValue(document, "AssemblyName");
        var targetFramework = GetRequiredPropertyValue(document, "TargetFramework");
        var outputType = GetOptionalPropertyValue(document, "OutputType") ?? "Library";
        var packageId = GetOptionalPropertyValue(document, "PackageId") ?? assemblyName;
        var version = GetOptionalPropertyValue(document, "Version") ?? "1.0.0";
        var isPackableText = GetOptionalPropertyValue(document, "IsPackable");
        var isPackable = !string.IsNullOrWhiteSpace(isPackableText)
            ? bool.Parse(isPackableText)
            : !string.Equals(outputType, "Exe", StringComparison.OrdinalIgnoreCase);

        return new DotnetProjectProfile(sdkName, assemblyName, targetFramework, outputType, packageId, version, isPackable);
    }

    public static DotnetCliBuildPlan BuildPlan(DotnetSdkPin sdkPin, DotnetProjectProfile profile, string configuration = "Release")
    {
        ArgumentNullException.ThrowIfNull(sdkPin);
        ArgumentNullException.ThrowIfNull(profile);
        ArgumentException.ThrowIfNullOrWhiteSpace(configuration);

        var normalizedConfiguration = configuration.Trim();
        var buildOutputDirectory = $"bin/{normalizedConfiguration}/{profile.TargetFramework}";
        var steps = new List<DotnetCliCommandStep>
        {
            new(
                "Verify SDK",
                "dotnet --version",
                "Confirm the active SDK matches global.json before the build starts."),
            new(
                "Restore dependencies",
                "dotnet restore <project-or-solution>",
                "Resolve NuGet packages and project references."),
            new(
                "Build Release output",
                $"dotnet build <project-or-solution> -c {normalizedConfiguration}",
                "Compile the project and generate Release artifacts."),
            new(
                "Run automated tests",
                $"dotnet test <test-project-or-solution> -c {normalizedConfiguration} --no-build",
                "Verify behavior without rebuilding the same artifacts.")
        };

        string? packageArtifactName = null;
        if (profile.IsPackable)
        {
            packageArtifactName = $"{profile.PackageId}.{profile.Version}.nupkg";
            steps.Add(
                new(
                    "Pack the library",
                    $"dotnet pack <library-project> -c {normalizedConfiguration} --no-build --output ./artifacts/packages",
                    "Create a distributable NuGet package from the already-built library."));
        }

        return new DotnetCliBuildPlan(sdkPin, profile, normalizedConfiguration, buildOutputDirectory, packageArtifactName, steps);
    }

    private static string GetRequiredPropertyValue(XDocument document, string propertyName)
    {
        var value = GetOptionalPropertyValue(document, propertyName);
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidOperationException($"The project metadata file must contain a non-empty {propertyName} property.");
        }

        return value;
    }

    private static string? GetOptionalPropertyValue(XDocument document, string propertyName)
    {
        return document
            .Descendants()
            .FirstOrDefault(element => string.Equals(element.Name.LocalName, propertyName, StringComparison.Ordinal))
            ?.Value
            .Trim();
    }
}