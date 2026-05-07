using DotnetAcademy.FirstConsoleAppDemo;

namespace DotnetAcademy.FirstConsoleAppDemo.Tests;

public class FirstConsoleAppPresenterTests
{
    private static readonly string[] AdaArguments = ["Ada"];

    [Fact]
    public void BuildLinesUsesLearnerWhenNoArgumentsAreProvided()
    {
        var lines = FirstConsoleAppPresenter.BuildLines(Array.Empty<string>());

        Assert.Contains("Hello, learner!", lines);
    }

    [Fact]
    public void BuildLinesUsesFirstArgumentWhenProvided()
    {
        var lines = FirstConsoleAppPresenter.BuildLines(AdaArguments);

        Assert.Contains("Hello, Ada!", lines);
    }

    [Fact]
    public void BuildLinesExplainsProgramCsAndDotnetRunArguments()
    {
        var lines = FirstConsoleAppPresenter.BuildLines(Array.Empty<string>());

        Assert.Contains("Program.cs is the entry point for this project.", lines);
        Assert.Contains("Use `dotnet run -- Ada` to pass a name to the app.", lines);
    }
}

