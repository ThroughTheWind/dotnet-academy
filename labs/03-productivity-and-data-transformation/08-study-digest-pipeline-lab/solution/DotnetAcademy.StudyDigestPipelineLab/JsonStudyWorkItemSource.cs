using System.Text.Json;

namespace DotnetAcademy.StudyDigestPipelineLab;

public sealed class JsonStudyWorkItemSource(string filePath) : IStudyWorkItemSource
{
    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };

    private readonly string filePath = !string.IsNullOrWhiteSpace(filePath)
        ? filePath
        : throw new ArgumentException("A file path is required.", nameof(filePath));

    public async Task<IReadOnlyList<StudyWorkItem>> LoadAsync(CancellationToken cancellationToken = default)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("The input file was not found.", filePath);
        }

        var json = await File.ReadAllTextAsync(filePath, cancellationToken);
        var items = JsonSerializer.Deserialize<StudyWorkItem[]>(json, SerializerOptions)
            ?? throw new InvalidOperationException("The input file did not contain study work items.");

        if (items.Length == 0)
        {
            throw new InvalidOperationException("At least one study work item is required.");
        }

        return items;
    }
}