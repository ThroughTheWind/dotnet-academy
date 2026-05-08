using DotnetAcademy.IntegratedTransformationDemo;
using Microsoft.Extensions.Configuration;

namespace DotnetAcademy.IntegratedTransformationDemo.Console;

public static class TransformationDemoConfiguration
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
            .AddEnvironmentVariables(prefix: "DOTNET_ACADEMY__");

        if (environmentOverrides is not null)
        {
            builder.AddInMemoryCollection(environmentOverrides);
        }

        return builder.Build();
    }

    public static TransformationExportSettings LoadSettings(
        string baseDirectory,
        IEnumerable<KeyValuePair<string, string?>>? environmentOverrides = null)
    {
        var configuration = BuildConfiguration(baseDirectory, environmentOverrides);
        var settings = new TransformationExportSettings();

        configuration.GetSection(TransformationExportSettings.SectionName).Bind(settings);
        settings.Validate();

        return settings;
    }
}