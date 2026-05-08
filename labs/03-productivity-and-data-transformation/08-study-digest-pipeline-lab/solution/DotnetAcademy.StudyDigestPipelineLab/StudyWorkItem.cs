namespace DotnetAcademy.StudyDigestPipelineLab;

public sealed record StudyWorkItem(string ModuleName, string Category, string SourceName, int PendingSteps, int Minutes);