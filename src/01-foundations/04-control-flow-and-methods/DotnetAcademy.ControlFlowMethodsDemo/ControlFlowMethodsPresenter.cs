namespace DotnetAcademy.ControlFlowMethodsDemo;

public static class ControlFlowMethodsPresenter
{
    public static IReadOnlyList<string> BuildLines(int completedTopics, bool practicedToday)
    {
        var lines = new List<string>
        {
            "Dotnet Academy: Control Flow And Methods",
            "-----------------------------------------",
            $"Completed topics: {completedTopics}",
            $"Practiced today: {practicedToday}",
            GetReadinessMessage(completedTopics, practicedToday),
            "Suggested practice sessions:"
        };

        lines.AddRange(BuildPracticeSessions(completedTopics));
        return lines;
    }

    public static string GetReadinessMessage(int completedTopics, bool practicedToday)
    {
        if (!practicedToday)
        {
            return "Practice once today before moving to the next topic.";
        }

        if (completedTopics >= 4)
        {
            return "You are ready for a larger challenge that combines several basics.";
        }

        return "Repeat the current topic one more time to build confidence.";
    }

    public static IReadOnlyList<string> BuildPracticeSessions(int completedTopics)
    {
        var sessionCount = completedTopics >= 4 ? 2 : 3;
        var lines = new List<string>();

        for (var sessionNumber = 1; sessionNumber <= sessionCount; sessionNumber++)
        {
            lines.Add($"- Practice session {sessionNumber}: write one small method and test one decision.");
        }

        return lines;
    }
}
