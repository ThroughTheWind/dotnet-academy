using System.Globalization;

namespace DotnetAcademy.VariablesTypesDemo;

public static class VariablesTypesPresenter
{
    public static IReadOnlyList<string> BuildLines()
    {
        string learnerName = "Ada";
        int completedTopics = 3;
        decimal practiceHours = 4.5m;
        bool isReadyForNextTopic = true;
        string completedExercisesText = "5";
        int completedExercises = int.Parse(completedExercisesText, CultureInfo.InvariantCulture);
        decimal averageHoursPerTopic = practiceHours / completedTopics;
        var culture = CultureInfo.InvariantCulture;

        return new[]
        {
            "Dotnet Academy: Variables, Types, And Conversions",
            "-------------------------------------------------",
            $"learnerName (string): {learnerName}",
            $"completedTopics (int): {completedTopics}",
            $"practiceHours (decimal): {practiceHours.ToString(culture)}",
            $"isReadyForNextTopic (bool): {isReadyForNextTopic}",
            $"completedExercisesText started as text: {completedExercisesText}",
            $"completedExercises parsed to int: {completedExercises}",
            $"averageHoursPerTopic (decimal): {averageHoursPerTopic.ToString(culture)}",
            "This sample shows that the type controls how a value is stored and used."
        };
    }
}
