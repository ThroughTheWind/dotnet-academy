using DotnetAcademy.DotnetCliBuildPackagingDemo;

namespace DotnetAcademy.DotnetCliBuildPackagingDemo.Tests;

public class DotnetCliBuildPackagingWorkflowTests
{
    [Fact]
    public void LoadPinnedSdkReadsVersionAndRollForward()
    {
        var root = CreateTempRoot();

        try
        {
            WriteSeedFiles(root);

            var sdkPin = DotnetCliBuildPackagingWorkflow.LoadPinnedSdk(Path.Combine(root, "seed", "global.json"));

            Assert.Equal("10.0.102", sdkPin.Version);
            Assert.Equal("latestFeature", sdkPin.RollForward);
        }
        finally
        {
            DeleteRoot(root);
        }
    }

    [Fact]
    public void LoadProjectProfileReadsPackableLibraryMetadata()
    {
        var root = CreateTempRoot();

        try
        {
            WriteSeedFiles(root);

            var profile = DotnetCliBuildPackagingWorkflow.LoadProjectProfile(Path.Combine(root, "seed", "study-tooling-sample.xml"));

            Assert.Equal("Microsoft.NET.Sdk", profile.SdkName);
            Assert.Equal("DotnetAcademy.ToolingSample", profile.AssemblyName);
            Assert.Equal("net10.0", profile.TargetFramework);
            Assert.Equal("Library", profile.OutputType);
            Assert.Equal("DotnetAcademy.ToolingSample", profile.PackageId);
            Assert.Equal("1.2.0", profile.Version);
            Assert.True(profile.IsPackable);
        }
        finally
        {
            DeleteRoot(root);
        }
    }

    [Fact]
    public void BuildPlanAddsPackCommandForPackableLibrary()
    {
        var plan = DotnetCliBuildPackagingWorkflow.BuildPlan(
            new DotnetSdkPin("10.0.102", "latestFeature"),
            CreateProfile(isPackable: true));

        Assert.Equal("bin/Release/net10.0", plan.BuildOutputDirectory);
        Assert.Equal("DotnetAcademy.ToolingSample.1.2.0.nupkg", plan.PackageArtifactName);
        Assert.Contains(plan.Steps, step => step.Command.StartsWith("dotnet pack", StringComparison.Ordinal));
    }

    [Fact]
    public void BuildPlanSkipsPackCommandForNonPackableExecutable()
    {
        var plan = DotnetCliBuildPackagingWorkflow.BuildPlan(
            new DotnetSdkPin("10.0.102", null),
            CreateProfile(outputType: "Exe", isPackable: false));

        Assert.Null(plan.PackageArtifactName);
        Assert.DoesNotContain(plan.Steps, step => step.Command.StartsWith("dotnet pack", StringComparison.Ordinal));
    }

    [Fact]
    public void BuildLinesUsesSeedFilesAndShowsWorkflow()
    {
        var root = CreateTempRoot();

        try
        {
            WriteSeedFiles(root);

            var lines = DotnetCliBuildPackagingPresenter.BuildLines(root);

            Assert.Contains("SDK pin: 10.0.102 (rollForward: latestFeature)", lines);
            Assert.Contains("Sample project: DotnetAcademy.ToolingSample", lines);
            Assert.Contains("Expected package artifact: DotnetAcademy.ToolingSample.1.2.0.nupkg", lines);
            Assert.Contains("- Pack the library: dotnet pack <library-project> -c Release --no-build --output ./artifacts/packages", lines);
        }
        finally
        {
            DeleteRoot(root);
        }
    }

    private static DotnetProjectProfile CreateProfile(string outputType = "Library", bool isPackable = true)
    {
        return new DotnetProjectProfile(
            "Microsoft.NET.Sdk",
            "DotnetAcademy.ToolingSample",
            "net10.0",
            outputType,
            "DotnetAcademy.ToolingSample",
            "1.2.0",
            isPackable);
    }

    private static string CreateTempRoot()
    {
        var root = Path.Combine(Path.GetTempPath(), "dotnet-academy-tooling-demo-tests", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        return root;
    }

    private static void DeleteRoot(string root)
    {
        if (Directory.Exists(root))
        {
            Directory.Delete(root, recursive: true);
        }
    }

    private static void WriteSeedFiles(string root)
    {
        var seedDirectory = Path.Combine(root, "seed");
        Directory.CreateDirectory(seedDirectory);

        File.WriteAllText(
            Path.Combine(seedDirectory, "global.json"),
            """
            {
              "sdk": {
                "version": "10.0.102",
                "rollForward": "latestFeature"
              }
            }
            """);

        File.WriteAllText(
            Path.Combine(seedDirectory, "study-tooling-sample.xml"),
            """
            <Project Sdk="Microsoft.NET.Sdk">
              <PropertyGroup>
                <AssemblyName>DotnetAcademy.ToolingSample</AssemblyName>
                <TargetFramework>net10.0</TargetFramework>
                <OutputType>Library</OutputType>
                <PackageId>DotnetAcademy.ToolingSample</PackageId>
                <Version>1.2.0</Version>
                <IsPackable>true</IsPackable>
              </PropertyGroup>
            </Project>
            """);
    }
}