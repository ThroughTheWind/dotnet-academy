namespace DotnetAcademy.LearningTrackLab;

public static class TrackItemDescriber
{
    public static string Describe(TrackItem item)
    {
        ArgumentNullException.ThrowIfNull(item);

        return item switch
        {
            LessonTrackItem { IncludesWalkthrough: true } lesson =>
                $"Lesson {lesson.Code} => {lesson.Title} ({lesson.Effort} lesson on {lesson.FocusArea} with walkthrough).",

            LessonTrackItem lesson =>
                $"Lesson {lesson.Code} => {lesson.Title} ({lesson.Effort} lesson on {lesson.FocusArea}).",

            PracticeTrackItem { Mode: PracticeMode.Pair } practice =>
                $"Practice {practice.Code} => {practice.Title} ({practice.Effort} pair exercise, repeat {practice.SuggestedRepeats} times).",

            PracticeTrackItem practice =>
                $"Practice {practice.Code} => {practice.Title} ({practice.Effort} {practice.Mode.ToString().ToLowerInvariant()} practice, repeat {practice.SuggestedRepeats} times).",

            ReviewTrackItem review =>
                $"Review {review.Code} => {review.Title} ({review.Effort} review because {review.Reason}).",

            _ => throw new ArgumentOutOfRangeException(nameof(item), "The track item shape was not recognized.")
        };
    }
}