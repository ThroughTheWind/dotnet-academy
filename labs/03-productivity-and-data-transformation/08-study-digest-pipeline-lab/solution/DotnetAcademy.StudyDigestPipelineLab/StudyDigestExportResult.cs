namespace DotnetAcademy.StudyDigestPipelineLab;

public sealed record StudyDigestExportResult(StudyDigestSummary Summary, string SummaryFilePath, string ReportFilePath);