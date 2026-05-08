namespace DotnetAcademy.LinqQueryThinkingDemo;

public static class LinqQueryThinkingPresenter
{
    public static IReadOnlyList<string> BuildLines()
    {
        var attempts = BuildSampleAttempts();
        var lines = new List<string>
        {
            "Dotnet Academy: LINQ Fundamentals and Query Thinking",
            "---------------------------------------------------",
            "Completed items:"
        };

        lines.AddRange(BuildCompletedLines(attempts));
        lines.Add("Focus list:");
        lines.AddRange(BuildFocusLines(attempts));
        lines.Add("Category summary:");
        lines.AddRange(BuildCategorySummaryLines(attempts));
        lines.Add("Query note: start with the question you need the data to answer, then choose operators that express that question clearly.");

        return lines;
    }

    public static IReadOnlyList<StudyAttempt> BuildSampleAttempts()
    {
        return
        [
            new StudyAttempt("Filter completed sessions", "linq", 92, completed: true, 18),
            new StudyAttempt("Project study summaries", "linq", 78, completed: true, 22),
            new StudyAttempt("Sort results with intent", "query thinking", 68, completed: false, 25),
            new StudyAttempt("Group attempts by category", "query thinking", 88, completed: true, 16),
            new StudyAttempt("Spot duplicate tags", "collections", 74, completed: true, 14)
        ];
    }

    public static IReadOnlyList<string> BuildCategorySummaryLines(IEnumerable<StudyAttempt> attempts)
    {
        ArgumentNullException.ThrowIfNull(attempts);

        var summaries =
            from attempt in attempts
            group attempt by attempt.Category into categories
            orderby categories.Key
            select $"{categories.Key}: {categories.Count()} attempts, average score {Math.Round(categories.Average(attempt => attempt.Score), 1):0.#}%";

        return summaries.ToList();
    }

    public static IReadOnlyList<string> BuildCompletedLines(IEnumerable<StudyAttempt> attempts)
    {
        ArgumentNullException.ThrowIfNull(attempts);

        return attempts
            .Where(attempt => attempt.Completed)
            .OrderByDescending(attempt => attempt.Score)
            .ThenBy(attempt => attempt.Topic)
            .Select(attempt => $"- {attempt.Topic} ({attempt.Score}% in {attempt.MinutesSpent} min)")
            .ToList();
    }

    public static string BuildFocusNote(StudyAttempt attempt)
    {
        ArgumentNullException.ThrowIfNull(attempt);

        return attempt switch
        {
            { Completed: false } => $"still in progress after {attempt.MinutesSpent} minutes",
            { Score: < 70 } => $"revisit the basics because the score is {attempt.Score}%",
            _ => $"one more pass could strengthen the {attempt.Score}% result"
        };
    }

    public static IReadOnlyList<string> BuildFocusLines(IEnumerable<StudyAttempt> attempts)
    {
        ArgumentNullException.ThrowIfNull(attempts);

        return attempts
            .Where(attempt => !attempt.Completed || attempt.Score < 80)
            .OrderBy(attempt => attempt.Completed)
            .ThenBy(attempt => attempt.Score)
            .Select(attempt => $"- {attempt.Topic}: {BuildFocusNote(attempt)}")
            .ToList();
    }
}