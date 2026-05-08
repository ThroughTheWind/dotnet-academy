using DotnetAcademy.DotnetCliBuildPackagingDemo;

foreach (var line in DotnetCliBuildPackagingPresenter.BuildLines(AppContext.BaseDirectory))
{
    Console.WriteLine(line);
}