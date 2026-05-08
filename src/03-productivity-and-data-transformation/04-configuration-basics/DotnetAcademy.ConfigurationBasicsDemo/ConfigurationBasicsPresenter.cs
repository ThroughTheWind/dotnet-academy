namespace DotnetAcademy.ConfigurationBasicsDemo;

public static class ConfigurationBasicsPresenter
{
    public static IReadOnlyList<string> BuildLines(
        string? baseDirectory = null,
        IEnumerable<KeyValuePair<string, string?>>? environmentOverrides = null)
    {
        baseDirectory ??= AppContext.BaseDirectory;

        var settings = ConfigurationBasicsWorkflow.LoadSettings(baseDirectory, environmentOverrides);

        return
        [
            "Dotnet Academy: Configuration Basics",
            "------------------------------------",
            $"Catalog name: {settings.CatalogName}",
            $"Focus category: {settings.FocusCategory}",
            $"Reminder minutes: {settings.ReminderMinutes}",
            $"Include archived: {settings.IncludeArchived}",
            "Provider order:",
            "- appsettings.json",
            "- appsettings.Development.json (optional)",
            "- environment variables with prefix DOTNET_ACADEMY__",
            "Configuration note: later providers override earlier values, so local or environment-specific settings can replace defaults without editing the base file."
        ];
    }
}