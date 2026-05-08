namespace DotnetAcademy.ClassesObjectsDemo;

public static class ClassesObjectsPresenter
{
    public static IReadOnlyList<string> BuildLines()
    {
        var learner = new LearnerProfile("Avery", 2, 4);
        learner.SetFocusArea("Object modeling");
        learner.CompleteTopic();

        return
        [
            "Dotnet Academy: Classes And Objects",
            "-----------------------------------",
            $"Learner: {learner.Name}",
            $"Focus area: {learner.FocusArea}",
            learner.GetProgressSummary(),
            $"Weekly goal reached: {learner.IsWeeklyGoalReached}"
        ];
    }
}