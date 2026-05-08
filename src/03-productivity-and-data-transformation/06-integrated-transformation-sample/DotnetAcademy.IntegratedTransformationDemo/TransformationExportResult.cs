namespace DotnetAcademy.IntegratedTransformationDemo;

public sealed record TransformationExportResult(
    IReadOnlyList<StudyWorkItem> Items,
    StudyDigestSummary Summary,
    string SummaryFilePath,
    string ReportFilePath);