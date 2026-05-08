namespace DotnetAcademy.LinqQueryThinkingDemo;

public sealed class StudyAttempt
{
    public StudyAttempt(string topic, string category, int score, bool completed, int minutesSpent)
    {
        Topic = string.IsNullOrWhiteSpace(topic)
            ? throw new ArgumentException("A topic is required.", nameof(topic))
            : topic.Trim();
        Category = string.IsNullOrWhiteSpace(category)
            ? throw new ArgumentException("A category is required.", nameof(category))
            : category.Trim().ToLowerInvariant();
        Score = score is >= 0 and <= 100
            ? score
            : throw new ArgumentOutOfRangeException(nameof(score), "Score must stay between 0 and 100.");
        Completed = completed;
        MinutesSpent = minutesSpent > 0
            ? minutesSpent
            : throw new ArgumentOutOfRangeException(nameof(minutesSpent), "Minutes spent must be greater than zero.");
    }

    public string Topic { get; }

    public string Category { get; }

    public int Score { get; }

    public bool Completed { get; }

    public int MinutesSpent { get; }
}