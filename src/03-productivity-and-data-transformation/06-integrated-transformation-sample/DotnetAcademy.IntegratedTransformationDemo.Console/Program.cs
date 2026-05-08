foreach (var line in await DotnetAcademy.IntegratedTransformationDemo.Console.TransformationDemoPresenter.BuildLinesAsync())
{
    Console.WriteLine(line);
}