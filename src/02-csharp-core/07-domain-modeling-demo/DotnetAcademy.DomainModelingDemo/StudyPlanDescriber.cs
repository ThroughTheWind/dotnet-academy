namespace DotnetAcademy.DomainModelingDemo;

public static class StudyPlanDescriber
{
    public static string Describe(LearningStep step)
    {
        ArgumentNullException.ThrowIfNull(step);

        return step switch
        {
            LessonStep { IncludesWalkthrough: true } lesson =>
                $"Lesson {lesson.Code} => {lesson.Title} ({lesson.Effort} guided lesson on {lesson.FocusArea} with walkthrough).",

            LessonStep lesson =>
                $"Lesson {lesson.Code} => {lesson.Title} ({lesson.Effort} lesson on {lesson.FocusArea}).",

            PracticeStep { Style: PracticeStyle.Pairing } practice =>
                $"Practice {practice.Code} => {practice.Title} ({practice.Effort} pair exercise, repeat {practice.SuggestedRepeats} times).",

            PracticeStep practice =>
                $"Practice {practice.Code} => {practice.Title} ({practice.Effort} {practice.Style.ToString().ToLowerInvariant()} practice, repeat {practice.SuggestedRepeats} times).",

            ReviewStep review =>
                $"Review {review.Code} => {review.Title} ({review.Effort} review because {review.Trigger}).",

            _ => throw new ArgumentOutOfRangeException(nameof(step), "The learning step shape was not recognized.")
        };
    }
}