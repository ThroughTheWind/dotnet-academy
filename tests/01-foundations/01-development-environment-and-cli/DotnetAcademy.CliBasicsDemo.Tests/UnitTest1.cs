using DotnetAcademy.CliBasicsDemo;

namespace DotnetAcademy.CliBasicsDemo.Tests;

public class CliBasicsPresenterTests
{
    [Fact]
    public void BuildLinesIncludesExpectedTitleRuntimeAndCommands()
    {
        var lines = CliBasicsPresenter.BuildLines(new Version(10, 0, 2));

        Assert.Equal("Dotnet Academy: Development Environment And CLI", lines[0]);
        Assert.Equal(new string('-', lines[0].Length), lines[1]);
        Assert.Contains("Runtime version from the running app: 10.0.2", lines);
        Assert.Contains("Core files and folders in this sample:", lines);
        Assert.Contains("dotnet build", lines);
        Assert.Contains("dotnet run", lines);
        Assert.Contains("dotnet --info", lines);
    }
}
