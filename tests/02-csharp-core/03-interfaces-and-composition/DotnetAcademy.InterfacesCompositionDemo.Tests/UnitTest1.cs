using DotnetAcademy.InterfacesCompositionDemo;

namespace DotnetAcademy.InterfacesCompositionDemo.Tests;

public class InterfacesCompositionPresenterTests
{
    [Fact]
    public void VideoLessonActivityBuildSummaryIncludesVideoLabel()
    {
        var activity = new VideoLessonActivity("Interfaces for shared behavior", 20);

        Assert.Equal("Interfaces for shared behavior (20 min video lesson)", activity.BuildSummary());
    }

    [Fact]
    public void StudyPlanGetTotalEstimatedMinutesAddsAllActivities()
    {
        var activities = new ILearningActivity[]
        {
            new VideoLessonActivity("Video", 20),
            new PracticeExerciseActivity("Exercise", 30)
        };

        var plan = new StudyPlan("Avery", activities);

        Assert.Equal(50, plan.GetTotalEstimatedMinutes());
    }

    [Fact]
    public void GetBoundaryNoteReturnsSplitGuidanceForLongerPlans()
    {
        Assert.Equal(
            "Split long plans into small composable steps that can change independently.",
            InterfacesCompositionPresenter.GetBoundaryNote(50));
    }

    [Fact]
    public void BuildLinesIncludesComposedAgendaAndBoundaryNote()
    {
        var lines = InterfacesCompositionPresenter.BuildLines();

        Assert.Contains("Learner: Avery", lines);
        Assert.Contains("Total estimate: 50 minutes", lines);
        Assert.Contains("- Interfaces for shared behavior (20 min video lesson)", lines);
        Assert.Contains("- Compose a study plan from small parts (30 min practice exercise)", lines);
        Assert.Contains("Boundary note: Split long plans into small composable steps that can change independently.", lines);
    }
}