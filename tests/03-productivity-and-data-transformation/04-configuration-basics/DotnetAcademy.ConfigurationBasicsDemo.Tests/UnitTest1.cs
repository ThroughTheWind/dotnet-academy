using DotnetAcademy.ConfigurationBasicsDemo;

namespace DotnetAcademy.ConfigurationBasicsDemo.Tests;

public class ConfigurationBasicsPresenterTests
{
    [Fact]
    public void LoadSettingsReadsJsonDefaultsAndDevelopmentOverrides()
    {
        var root = CreateTempRoot();

        try
        {
            WriteConfigFiles(root);

            var settings = ConfigurationBasicsWorkflow.LoadSettings(root);

            Assert.Equal("Dotnet Academy Study Planner", settings.CatalogName);
            Assert.Equal("configuration", settings.FocusCategory);
            Assert.Equal(15, settings.ReminderMinutes);
            Assert.False(settings.IncludeArchived);
        }
        finally
        {
            DeleteRoot(root);
        }
    }

    [Fact]
    public void LoadSettingsUsesLaterOverridesWhenProvided()
    {
        var root = CreateTempRoot();

        try
        {
            WriteConfigFiles(root);
            var overrides = new Dictionary<string, string?>
            {
                ["StudyPlanner:FocusCategory"] = "async",
                ["StudyPlanner:ReminderMinutes"] = "10"
            };

            var settings = ConfigurationBasicsWorkflow.LoadSettings(root, overrides);

            Assert.Equal("async", settings.FocusCategory);
            Assert.Equal(10, settings.ReminderMinutes);
        }
        finally
        {
            DeleteRoot(root);
        }
    }

    [Fact]
    public void LoadSettingsThrowsWhenReminderMinutesIsInvalid()
    {
        var root = CreateTempRoot();

        try
        {
            WriteConfigFiles(root);
            var overrides = new Dictionary<string, string?>
            {
                ["StudyPlanner:ReminderMinutes"] = "0"
            };

            var exception = Assert.Throws<InvalidOperationException>(() => ConfigurationBasicsWorkflow.LoadSettings(root, overrides));

            Assert.Equal("StudyPlanner:ReminderMinutes must be greater than zero.", exception.Message);
        }
        finally
        {
            DeleteRoot(root);
        }
    }

    [Fact]
    public void BuildLinesIncludesValuesAndProviderOrder()
    {
        var root = CreateTempRoot();

        try
        {
            WriteConfigFiles(root);

            var lines = ConfigurationBasicsPresenter.BuildLines(root);

            Assert.Contains("Catalog name: Dotnet Academy Study Planner", lines);
            Assert.Contains("Focus category: configuration", lines);
            Assert.Contains("Provider order:", lines);
            Assert.Contains("Configuration note: later providers override earlier values, so local or environment-specific settings can replace defaults without editing the base file.", lines);
        }
        finally
        {
            DeleteRoot(root);
        }
    }

    [Fact]
    public void BuildConfigurationThrowsForMissingBaseDirectory()
    {
        var missingDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));

        Assert.Throws<DirectoryNotFoundException>(() => ConfigurationBasicsWorkflow.BuildConfiguration(missingDirectory));
    }

    private static string CreateTempRoot()
    {
        var root = Path.Combine(Path.GetTempPath(), "dotnet-academy-config-tests", Guid.NewGuid().ToString("N"));
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

    private static void WriteConfigFiles(string root)
    {
        File.WriteAllText(
            Path.Combine(root, "appsettings.json"),
            """
            {
              "StudyPlanner": {
                "CatalogName": "Dotnet Academy Study Planner",
                "FocusCategory": "files",
                "ReminderMinutes": 20,
                "IncludeArchived": false
              }
            }
            """);

        File.WriteAllText(
            Path.Combine(root, "appsettings.Development.json"),
            """
            {
              "StudyPlanner": {
                "FocusCategory": "configuration",
                "ReminderMinutes": 15
              }
            }
            """);
    }
}