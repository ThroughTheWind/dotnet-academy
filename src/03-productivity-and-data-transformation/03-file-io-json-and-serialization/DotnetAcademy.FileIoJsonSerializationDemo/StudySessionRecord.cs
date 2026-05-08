using System.Text.Json.Serialization;

namespace DotnetAcademy.FileIoJsonSerializationDemo;

public sealed class StudySessionRecord
{
    [JsonConstructor]
    public StudySessionRecord(string sessionId, string topic, string category, int minutes, bool completed)
    {
        SessionId = string.IsNullOrWhiteSpace(sessionId)
            ? throw new ArgumentException("A session identifier is required.", nameof(sessionId))
            : sessionId.Trim().ToUpperInvariant();
        Topic = string.IsNullOrWhiteSpace(topic)
            ? throw new ArgumentException("A topic is required.", nameof(topic))
            : topic.Trim();
        Category = string.IsNullOrWhiteSpace(category)
            ? throw new ArgumentException("A category is required.", nameof(category))
            : category.Trim().ToLowerInvariant();
        Minutes = minutes > 0
            ? minutes
            : throw new ArgumentOutOfRangeException(nameof(minutes), "Minutes must be greater than zero.");
        Completed = completed;
    }

    public string SessionId { get; }

    public string Topic { get; }

    public string Category { get; }

    public int Minutes { get; }

    public bool Completed { get; }
}