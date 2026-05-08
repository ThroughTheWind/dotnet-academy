namespace DotnetAcademy.InterfacesCompositionDemo;

public static class InterfacesCompositionPresenter
{
    public static IReadOnlyList<string> BuildLines()
    {
        var activities = new ILearningActivity[]
        {
            new VideoLessonActivity("Interfaces for shared behavior", 20),
            new PracticeExerciseActivity("Compose a study plan from small parts", 30)
        };

        var plan = new StudyPlan("Avery", activities);
        var lines = new List<string>
        {
            "Dotnet Academy: Interfaces And Composition",
            "-------------------------------------------"
        };

        lines.AddRange(plan.BuildAgendaLines());
        lines.Add($"Boundary note: {GetBoundaryNote(plan.GetTotalEstimatedMinutes())}");
        return lines;
    }

    public static string GetBoundaryNote(int totalMinutes)
    {
        return totalMinutes > 45
            ? "Split long plans into small composable steps that can change independently."
            : "Small composable steps are easy to replace and reorder.";
    }
}