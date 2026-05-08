using System.Text.Json;
using DotnetAcademy.IntegratedTransformationDemo;
using DotnetAcademy.IntegratedTransformationDemo.Console;

namespace DotnetAcademy.IntegratedTransformationDemo.Tests;

public class IntegratedTransformationDemoTests
{
    [Fact]
    public async Task JsonFileStudyWorkItemSourceLoadsItemsFromFile()
    {
        var filePath = CreateTempFilePath();

        try
        {
            var fileItems = new[]
            {
                new StudyWorkItem("JSON exports", "data", "seed archive", 2, 45)
            };

            await File.WriteAllTextAsync(filePath, JsonSerializer.Serialize(fileItems));

            var source = new JsonFileStudyWorkItemSource(filePath);
            var loadedItems = await source.LoadAsync();

            Assert.Single(loadedItems);
            Assert.Equal("JSON exports", loadedItems[0].ModuleName);
        }
        finally
        {
            DeleteIfExists(filePath);
        }
    }

    [Fact]
    public async Task LoadAllAsyncAggregatesItemsFromMultipleSources()
    {
        var filePath = CreateTempFilePath();

        try
        {
            var items = new[]
            {
                new StudyWorkItem("JSON exports", "data", "seed archive", 2, 45)
            };

            await File.WriteAllTextAsync(filePath, JsonSerializer.Serialize(items));

            var sources = new IStudyWorkItemSource[]
            {
                new JsonFileStudyWorkItemSource(filePath),
                new StaticStudyWorkItemSource(
                [
                    new StudyWorkItem("Configuration layering", "platform", "planner board", 2, 35)
                ]),
                new StreamingStudyWorkItemSource(
                    new DelayedStudyWorkItemFeed(
                    [
                        new ScheduledStudyWorkItem(new StudyWorkItem("Async digest", "async", "mentor digest", 3, 30), 0)
                    ]).ReadAllAsync())
            };

            var loadedItems = await IntegratedTransformationWorkflow.LoadAllAsync(sources);

            Assert.Equal(3, loadedItems.Count);
            Assert.Contains(loadedItems, item => item.ModuleName == "JSON exports");
            Assert.Contains(loadedItems, item => item.Category == "platform");
            Assert.Contains(loadedItems, item => item.SourceName == "mentor digest");
        }
        finally
        {
            DeleteIfExists(filePath);
        }
    }

    [Fact]
    public void BuildSummaryAppliesThresholdAndConfiguredCategories()
    {
        var items = new[]
        {
            new StudyWorkItem("JSON exports", "data", "seed archive", 2, 45),
            new StudyWorkItem("LINQ cleanup", "analysis", "seed archive", 1, 25),
            new StudyWorkItem("Async digest", "async", "mentor digest", 3, 30),
            new StudyWorkItem("Configuration layering", "platform", "planner board", 2, 35)
        };

        var settings = new TransformationExportSettings
        {
            MinimumPendingSteps = 2,
            FocusCategories = ["async", "data"]
        };

        var summary = IntegratedTransformationWorkflow.BuildSummary(items, settings);

        Assert.Equal(4, summary.TotalItems);
        Assert.Equal(8, summary.TotalPendingSteps);
        Assert.Equal(2, summary.FocusItemCount);
        Assert.Equal("Async digest", summary.FocusItems[0].ModuleName);
        Assert.Equal("JSON exports", summary.FocusItems[1].ModuleName);
    }

    [Fact]
    public async Task RunExportAsyncWritesSummaryAndReportFiles()
    {
        var outputDirectory = CreateTempDirectory();

        try
        {
            var sources = new IStudyWorkItemSource[]
            {
                new StaticStudyWorkItemSource(
                [
                    new StudyWorkItem("JSON exports", "data", "seed archive", 2, 45),
                    new StudyWorkItem("Async digest", "async", "mentor digest", 3, 30)
                ])
            };

            var settings = new TransformationExportSettings
            {
                OutputFolderName = "ignored-by-direct-output-path",
                MinimumPendingSteps = 2,
                FocusCategories = ["async", "data"]
            };

            var result = await IntegratedTransformationWorkflow.RunExportAsync(sources, settings, outputDirectory);

            Assert.True(File.Exists(result.SummaryFilePath));
            Assert.True(File.Exists(result.ReportFilePath));
            Assert.Contains("integrated-study-digest.json", result.SummaryFilePath);

            var report = await File.ReadAllLinesAsync(result.ReportFilePath);

            Assert.Contains("Focus modules:", report);
            Assert.Contains("- Async digest [async] from mentor digest: 3 pending steps, 30 min", report);
        }
        finally
        {
            DeleteDirectoryIfExists(outputDirectory);
        }
    }

    [Fact]
    public async Task BuildLinesAsyncUsesConfigurationAndPersistsOutput()
    {
        var baseDirectory = CreateTempDirectory();

        try
        {
            Directory.CreateDirectory(Path.Combine(baseDirectory, "seed"));

            await File.WriteAllTextAsync(Path.Combine(baseDirectory, "appsettings.json"), """
{
  "IntegratedTransformation": {
    "OutputFolderName": "custom-output",
    "MinimumPendingSteps": 2,
    "FocusCategories": [ "async", "data", "platform" ]
  }
}
""");

            var seedItems = new[]
            {
                new StudyWorkItem("JSON exports", "data", "seed archive", 2, 45),
                new StudyWorkItem("LINQ cleanup", "analysis", "seed archive", 1, 25)
            };

            await File.WriteAllTextAsync(Path.Combine(baseDirectory, "seed", "study-work-items.json"), JsonSerializer.Serialize(seedItems));

            var lines = await TransformationDemoPresenter.BuildLinesAsync(baseDirectory, baseDirectory);

            Assert.Contains("Items loaded: 6", lines);
            Assert.Contains("Focus items: 4", lines);
            Assert.Contains("Output summary: integrated-study-digest.json", lines);
            Assert.True(File.Exists(Path.Combine(baseDirectory, "custom-output", "integrated-study-digest.json")));
            Assert.True(File.Exists(Path.Combine(baseDirectory, "custom-output", "integrated-study-report.txt")));
        }
        finally
        {
            DeleteDirectoryIfExists(baseDirectory);
        }
    }

    private static string CreateTempDirectory()
    {
        var directory = Path.Combine(Path.GetTempPath(), $"dotnet-academy-{Guid.NewGuid():N}");
        Directory.CreateDirectory(directory);
        return directory;
    }

    private static string CreateTempFilePath()
    {
        return Path.Combine(Path.GetTempPath(), $"dotnet-academy-{Guid.NewGuid():N}.json");
    }

    private static void DeleteDirectoryIfExists(string directory)
    {
        if (Directory.Exists(directory))
        {
            Directory.Delete(directory, recursive: true);
        }
    }

    private static void DeleteIfExists(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}