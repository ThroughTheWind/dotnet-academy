using DotnetAcademy.AsyncAwaitFoundationsDemo;

foreach (var line in await AsyncAwaitFoundationsPresenter.BuildLinesAsync())
{
    Console.WriteLine(line);
}