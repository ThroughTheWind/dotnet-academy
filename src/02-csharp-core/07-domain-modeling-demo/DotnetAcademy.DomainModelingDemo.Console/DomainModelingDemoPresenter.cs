using DotnetAcademy.DomainModelingDemo;

namespace DotnetAcademy.DomainModelingDemo.Console;

public static class DomainModelingDemoPresenter
{
    public static IReadOnlyList<string> BuildLines()
    {
        var catalog = BuildCatalog();
        var stepNotifications = new List<string>();
        var plan = new StudyPlan("Avery", new StandardWorkloadAdvisor());

        plan.StepAdded += HandleStepAdded;
        plan.AddStep(catalog.FindByCode("S02-01"));
        plan.AddStep(catalog.FindByCode("S02-05"));
        plan.AddStep(catalog.FindByCode("S02-06"));
        plan.StepAdded -= HandleStepAdded;

        PlanStepFilter needsFollowUp = step => step is PracticeStep { Style: PracticeStyle.Pairing } or ReviewStep;

        var lines = new List<string>
        {
            "Dotnet Academy: Stage 2 Domain Modeling Demo",
            "---------------------------------------------",
            $"Learner: {plan.LearnerName}"
        };

        lines.AddRange(stepNotifications);
        lines.Add($"Workload note: {plan.GetWorkloadNote()}");
        lines.Add("Focus items:");

        foreach (var step in plan.GetSteps(needsFollowUp))
        {
            lines.Add($"- {StudyPlanDescriber.Describe(step)}");
        }

        try
        {
            _ = catalog.FindByCode("S02-99");
        }
        catch (KeyNotFoundException ex)
        {
            lines.Add($"Lookup note: {ex.Message}");
        }

        lines.Add("Abstraction note: the planner composes policies while the catalog stays generic and type-safe.");

        return lines;

        void HandleStepAdded(object? sender, StepAddedEventArgs args)
        {
            stepNotifications.Add($"Added: {args.Description}");
        }
    }

    public static PlanCatalog<LearningStep> BuildCatalog()
    {
        var catalog = new PlanCatalog<LearningStep>();

        catalog.Add(new LessonStep("S02-01", "Model a resource as a real object", new EffortEstimate(25), "domain models", true));
        catalog.Add(new PracticeStep("S02-05", "Choose the right collection boundary", new EffortEstimate(20), PracticeStyle.Pairing, 2));
        catalog.Add(new ReviewStep("S02-06", "Review behavioral hooks", new EffortEstimate(15), "event flow is still new"));

        return catalog;
    }
}