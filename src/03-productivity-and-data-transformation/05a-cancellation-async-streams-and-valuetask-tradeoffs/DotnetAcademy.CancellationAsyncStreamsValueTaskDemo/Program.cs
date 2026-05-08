using DotnetAcademy.CancellationAsyncStreamsValueTaskDemo;

foreach (var line in await AsyncTradeoffsPresenter.BuildLinesAsync())
{
    Console.WriteLine(line);
}