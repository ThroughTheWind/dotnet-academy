using DotnetAcademy.DomainModelingDemo;
using DotnetAcademy.DomainModelingDemo.Console;

namespace DotnetAcademy.DomainModelingDemo.Tests;

public class DomainModelingDemoTests
{
    [Fact]
    public void PlanCatalogAddRejectsDuplicateCodes()
    {
        var catalog = new PlanCatalog<LearningStep>();
        catalog.Add(new LessonStep("S02-01", "Model a resource as a real object", new EffortEstimate(25), "domain models", true));

        var exception = Assert.Throws<InvalidOperationException>(() =>
            catalog.Add(new PracticeStep("S02-01", "Duplicate code", new EffortEstimate(20), PracticeStyle.Solo, 1)));

        Assert.Equal("A learning step with code 'S02-01' already exists.", exception.Message);
    }

    [Fact]
    public void StudyPlanAddStepRaisesStepAddedEvent()
    {
        var plan = new StudyPlan("Avery", new StandardWorkloadAdvisor());
        string? capturedDescription = null;

        plan.StepAdded += (_, args) => capturedDescription = args.Description;
        plan.AddStep(new ReviewStep("S02-06", "Review behavioral hooks", new EffortEstimate(15), "event flow is still new"));

        Assert.Equal("Review S02-06 => Review behavioral hooks (15 min review because event flow is still new).", capturedDescription);
    }

    [Fact]
    public void StudyPlanGetStepsUsesDelegateFilter()
    {
        var plan = new StudyPlan("Avery", new StandardWorkloadAdvisor());
        plan.AddStep(new LessonStep("S02-01", "Model a resource as a real object", new EffortEstimate(25), "domain models", true));
        plan.AddStep(new PracticeStep("S02-05", "Choose the right collection boundary", new EffortEstimate(20), PracticeStyle.Pairing, 2));
        plan.AddStep(new ReviewStep("S02-06", "Review behavioral hooks", new EffortEstimate(15), "event flow is still new"));

        PlanStepFilter needsFollowUp = step => step is PracticeStep { Style: PracticeStyle.Pairing } or ReviewStep;
        var stepsNeedingFollowUp = plan.GetSteps(needsFollowUp);

        Assert.Equal(2, stepsNeedingFollowUp.Count);
        Assert.Contains(stepsNeedingFollowUp, step => step.Code == "S02-05");
        Assert.Contains(stepsNeedingFollowUp, step => step.Code == "S02-06");
    }

    [Fact]
    public void StudyPlanDescriberUsesPatternMatchingForPairPractice()
    {
        var description = StudyPlanDescriber.Describe(
            new PracticeStep("S02-05", "Choose the right collection boundary", new EffortEstimate(20), PracticeStyle.Pairing, 2));

        Assert.Equal("Practice S02-05 => Choose the right collection boundary (20 min pair exercise, repeat 2 times).", description);
    }

    [Fact]
    public void DomainModelingDemoPresenterBuildLinesIncludesNotificationsAndLookupNote()
    {
        var lines = DomainModelingDemoPresenter.BuildLines();

        Assert.Contains("Learner: Avery", lines);
        Assert.Contains("Added: Lesson S02-01 => Model a resource as a real object (25 min guided lesson on domain models with walkthrough).", lines);
        Assert.Contains("Added: Practice S02-05 => Choose the right collection boundary (20 min pair exercise, repeat 2 times).", lines);
        Assert.Contains("Workload note: This plan fits into one focused session.", lines);
        Assert.Contains("Lookup note: No learning step was found for code 'S02-99'.", lines);
        Assert.Contains("Abstraction note: the planner composes policies while the catalog stays generic and type-safe.", lines);
    }
}