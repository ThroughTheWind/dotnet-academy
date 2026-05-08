namespace DotnetAcademy.StudyDigestPipelineLab;

public sealed record StudyDigestSummary(
    string LearnerName,
    int TotalItems,
    int FocusItemCount,
    int TotalMinutes,
    IReadOnlyList<StudyCategorySummary> Categories,
    IReadOnlyList<StudyWorkItem> FocusItems);