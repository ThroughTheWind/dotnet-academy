namespace DotnetAcademy.IntegratedTransformationDemo;

public sealed record StudyDigestSummary(
    int TotalItems,
    int FocusItemCount,
    int TotalPendingSteps,
    int TotalMinutes,
    IReadOnlyList<StudyCategorySummary> Categories,
    IReadOnlyList<StudyFocusItem> FocusItems);