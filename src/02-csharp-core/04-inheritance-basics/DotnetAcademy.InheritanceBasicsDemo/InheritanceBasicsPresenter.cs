namespace DotnetAcademy.InheritanceBasicsDemo;

public static class InheritanceBasicsPresenter
{
    public static IReadOnlyList<string> BuildLines()
    {
        LearningResource lesson = new GuidedLessonResource("Composition over inheritance", 25, "abstraction choices");
        LearningResource challenge = new CodeChallengeResource("Refactor a base type carefully", 30, 2);

        return
        [
            "Dotnet Academy: Inheritance Basics",
            "----------------------------------",
            lesson.BuildSummary(),
            $"Follow-up: {lesson.GetFollowUpAction()}",
            challenge.BuildSummary(),
            $"Follow-up: {challenge.GetFollowUpAction()}",
            "Tradeoff note: prefer inheritance only when the derived type is a true specialized version of the base type."
        ];
    }
}