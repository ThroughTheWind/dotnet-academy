using Microsoft.Extensions.Configuration;

namespace DotnetAcademy.ConfigurationBasicsDemo;

public static class ConfigurationBasicsWorkflow
{
    public static IConfigurationRoot BuildConfiguration(
        string baseDirectory,
        IEnumerable<KeyValuePair<string, string?>>? environmentOverrides = null)
    {
        if (string.IsNullOrWhiteSpace(baseDirectory))
        {
            throw new ArgumentException("A base directory is required.", nameof(baseDirectory));
        }

        if (!Directory.Exists(baseDirectory))
        {
            throw new DirectoryNotFoundException($"The base directory '{baseDirectory}' was not found.");
        }

        var builder = new ConfigurationBuilder()
            .SetBasePath(baseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: false)
            .AddEnvironmentVariables(prefix: "DOTNET_ACADEMY__");

        if (environmentOverrides is not null)
        {
            builder.AddInMemoryCollection(environmentOverrides);
        }

        return builder.Build();
    }

    public static StudyPlannerSettings LoadSettings(
        string baseDirectory,
        IEnumerable<KeyValuePair<string, string?>>? environmentOverrides = null)
    {
        var configuration = BuildConfiguration(baseDirectory, environmentOverrides);
        var settings = new StudyPlannerSettings();

        configuration.GetSection(StudyPlannerSettings.SectionName).Bind(settings);
        settings.Validate();

        return settings;
    }
}