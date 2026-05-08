using DotnetAcademy.StudyDigestPipelineLab;

foreach (var line in await StudyDigestPipelinePresenter.BuildLinesAsync(args))
{
    Console.WriteLine(line);
}