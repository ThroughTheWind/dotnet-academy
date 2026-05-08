using System.Text.Json;
using DotnetAcademy.StudyDigestPipelineLab;

namespace DotnetAcademy.StudyDigestPipelineLab.Tests;

public class StudyDigestPipelinePresenterTests
{
    private static readonly string[] EmptyArguments = [];
    private static readonly string[] AdaArguments = ["Ada"];

    [Fact]
    public void GetLearnerNameReturnsFallbackWhenArgumentsAreMissing()
    {
        var learnerName = StudyDigestPipelinePresenter.GetLearnerName(EmptyArguments);

        Assert.Equal("Learner", learnerName);
    }

    [Fact]
    public void StudyDigestSettingsValidateRejectsInvalidMinimumPendingSteps()
    {
        var settings = new StudyDigestSettings
        {
            MinimumPendingSteps = 0
        };

        var exception = Assert.Throws<InvalidOperationException>(() => settings.Validate());

        Assert.Equal("MinimumPendingSteps must be at least 1.", exception.Message);
    }

    [Fact]
    public async Task LoadAllAsyncAggregatesFileAndDelayedSources()
    {
        var filePath = CreateTempFilePath();

        try
        {
            var fileItems = new[]
            {
                new StudyWorkItem("JSON exports", "data", "seed archive", 2, 45),
                new StudyWorkItem("Configuration layering", "platform", "seed archive", 2, 35)
            };

            await File.WriteAllTextAsync(filePath, JsonSerializer.Serialize(fileItems));

            var sources = new IStudyWorkItemSource[]
            {
                new JsonStudyWorkItemSource(filePath),
                new DelayedStudyWorkItemSource(
                [
                    new StudyWorkItem("Async digest", "async", "mentor queue", 3, 30),
                    new StudyWorkItem("Cancellation review", "async", "mentor queue", 2, 25)
                ], 0)
            };

            var items = await StudyDigestPipelineWorkflow.LoadAllAsync(sources);

            Assert.Equal(4, items.Count);
            Assert.Contains(items, item => item.ModuleName == "JSON exports");
            Assert.Contains(items, item => item.Category == "async");
        }
        finally
        {
            DeleteIfExists(filePath);
        }
    }

    [Fact]
    public void BuildSummaryGroupsCategoriesAndFiltersFocusItems()
    {
        var items = new[]
        {
            new StudyWorkItem("JSON exports", "data", "seed archive", 2, 45),
            new StudyWorkItem("LINQ cleanup", "data", "seed archive", 1, 20),
            new StudyWorkItem("Configuration layering", "platform", "seed archive", 2, 35),
            new StudyWorkItem("Async digest", "async", "mentor queue", 3, 30),
            new StudyWorkItem("Cancellation review", "async", "mentor queue", 2, 25)
        };

        var settings = new StudyDigestSettings
        {
            MinimumPendingSteps = 2
        };

        var summary = StudyDigestPipelineWorkflow.BuildSummary("Ada", items, settings);

        Assert.Equal(5, summary.TotalItems);
        Assert.Equal(4, summary.FocusItemCount);
        Assert.Equal(155, summary.TotalMinutes);
        Assert.Equal("async", summary.Categories[0].Category);
        Assert.Equal("Async digest", summary.FocusItems[0].ModuleName);
    }

    [Fact]
    public async Task BuildLinesAsyncCreatesOutputFilesAndPrintsDigest()
    {
        var baseDirectory = CreateTempDirectory();

        try
        {
            Directory.CreateDirectory(Path.Combine(baseDirectory, "seed"));

            await File.WriteAllTextAsync(Path.Combine(baseDirectory, "appsettings.json"), """
{
  "StudyDigest": {
    "OutputFolderName": "custom-output",
    "MinimumPendingSteps": 2
  }
}
""");

            var seedItems = new[]
            {
                new StudyWorkItem("JSON exports", "data", "seed archive", 2, 45),
                new StudyWorkItem("LINQ cleanup", "data", "seed archive", 1, 20),
                new StudyWorkItem("Configuration layering", "platform", "seed archive", 2, 35)
            };

            await File.WriteAllTextAsync(Path.Combine(baseDirectory, "seed", "study-work-items.json"), JsonSerializer.Serialize(seedItems));

            var lines = await StudyDigestPipelinePresenter.BuildLinesAsync(AdaArguments, baseDirectory);

            Assert.Contains("Learner: Ada", lines);
            Assert.Contains("Items loaded: 5", lines);
            Assert.Contains("Focus items: 4", lines);
            Assert.Contains("- Async digest [async] from mentor queue: 3 pending steps, 30 min", lines);
            Assert.Contains("Output note: wrote study-digest-summary.json and study-digest-report.txt.", lines);
            Assert.True(File.Exists(Path.Combine(baseDirectory, "custom-output", "study-digest-summary.json")));
            Assert.True(File.Exists(Path.Combine(baseDirectory, "custom-output", "study-digest-report.txt")));
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