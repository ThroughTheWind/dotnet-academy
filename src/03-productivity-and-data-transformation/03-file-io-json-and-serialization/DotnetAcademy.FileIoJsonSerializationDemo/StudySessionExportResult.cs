namespace DotnetAcademy.FileIoJsonSerializationDemo;

public sealed record StudySessionExportResult(
    string InputFilePath,
    IReadOnlyList<StudySessionRecord> Sessions,
    StudySessionExportSummary Summary,
    string SummaryFilePath,
    string ReportFilePath);