using System.Globalization;

namespace DotnetAcademy.StudySessionPlannerLab;

public static class StudySessionPlannerPresenter
{
    public static IReadOnlyList<string> BuildLines(string[] args)
    {
        const string weeklyTargetText = "5";
        const string completedTopicsText = "3";
        const string practiceHoursText = "7.5";

        var culture = CultureInfo.InvariantCulture;
        var learnerName = GetLearnerName(args);
        var weeklyTarget = int.Parse(weeklyTargetText, culture);
        var completedTopics = int.Parse(completedTopicsText, culture);
        var practiceHours = decimal.Parse(practiceHoursText, culture);
        var mentorName = GetOptionalArgument(args, 1);
        var recentWarning = GetOptionalArgument(args, 2);
        var remainingTopics = Math.Max(weeklyTarget - completedTopics, 0);
        var averageHoursPerTopic = completedTopics == 0 ? 0m : practiceHours / completedTopics;
        var practicedToday = practiceHours >= 1m;

        var lines = new List<string>
        {
            "Dotnet Academy: Study Session Planner Lab",
            "-----------------------------------------",
            $"Learner: {learnerName}",
            $"Weekly topic target: {weeklyTarget}",
            $"Completed topics: {completedTopics}",
            $"Practice hours logged: {practiceHours.ToString(culture)}",
            $"Average hours per completed topic: {averageHoursPerTopic.ToString("0.0", culture)}",
            $"Mentor: {GetOptionalDisplay(mentorName, "Unassigned")}",
            $"Recent warning: {GetOptionalDisplay(recentWarning, "None")}",
            GetReadinessMessage(remainingTopics, practicedToday),
            "Next actions:"
        };

        lines.AddRange(BuildActionSteps(remainingTopics, practicedToday));
        lines.Add($"Debug tip: {GetDebugTip(recentWarning)}");
        return lines;
    }

    public static string GetLearnerName(string[] args)
    {
        if (args.Length == 0 || string.IsNullOrWhiteSpace(args[0]))
        {
            return "Learner";
        }

        return args[0].Trim();
    }

    public static string? GetOptionalArgument(string[] args, int index)
    {
        if (index >= args.Length || string.IsNullOrWhiteSpace(args[index]))
        {
            return null;
        }

        return args[index].Trim();
    }

    public static string GetOptionalDisplay(string? value, string fallback)
    {
        return string.IsNullOrWhiteSpace(value) ? fallback : value;
    }

    public static string GetReadinessMessage(int remainingTopics, bool practicedToday)
    {
        if (!practicedToday)
        {
            return "Readiness: add one short practice session today before moving forward.";
        }

        if (remainingTopics == 0)
        {
            return "Readiness: weekly target reached, so you can try the extension section.";
        }

        var topicLabel = remainingTopics == 1 ? "topic" : "topics";
        return $"Readiness: {remainingTopics} {topicLabel} left before the weekly target is complete.";
    }

    public static IReadOnlyList<string> BuildActionSteps(int remainingTopics, bool practicedToday)
    {
        var actionItems = new List<string>
        {
            "Review one CLI command you have already used successfully.",
            "Run the console app again with your learner name."
        };

        if (remainingTopics > 0)
        {
            actionItems.Add("Finish one more focused Stage 1 topic practice block.");
        }
        else
        {
            actionItems.Add("Add one stretch goal, such as custom study hours or another warning rule.");
        }

        if (!practicedToday)
        {
            actionItems.Add("Schedule a 15-minute practice session before ending the day.");
        }

        var lines = new List<string>();

        for (var stepIndex = 0; stepIndex < actionItems.Count; stepIndex++)
        {
            lines.Add($"{stepIndex + 1}. {actionItems[stepIndex]}");
        }

        return lines;
    }

    public static string GetDebugTip(string? recentWarning)
    {
        return recentWarning is null
            ? "Re-run after each small change and confirm the parsed values still look correct."
            : "Start with the warning text, then confirm the variables feeding that branch.";
    }
}