namespace DotnetAcademy.FileIoJsonSerializationDemo;

public sealed record StudySessionExportSummary(
    int TotalSessions,
    int CompletedSessions,
    int TotalMinutes,
    IReadOnlyList<StudySessionCategorySummary> Categories);