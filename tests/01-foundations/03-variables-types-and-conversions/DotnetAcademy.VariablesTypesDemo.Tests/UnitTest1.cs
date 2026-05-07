using DotnetAcademy.VariablesTypesDemo;

namespace DotnetAcademy.VariablesTypesDemo.Tests;

public class VariablesTypesPresenterTests
{
    [Fact]
    public void BuildLinesIncludesExpectedTypedVariables()
    {
        var lines = VariablesTypesPresenter.BuildLines();

        Assert.Contains("learnerName (string): Ada", lines);
        Assert.Contains("completedTopics (int): 3", lines);
        Assert.Contains("practiceHours (decimal): 4.5", lines);
        Assert.Contains("isReadyForNextTopic (bool): True", lines);
    }

    [Fact]
    public void BuildLinesIncludesTextToNumberConversion()
    {
        var lines = VariablesTypesPresenter.BuildLines();

        Assert.Contains("completedExercisesText started as text: 5", lines);
        Assert.Contains("completedExercises parsed to int: 5", lines);
    }

    [Fact]
    public void BuildLinesIncludesAverageHoursPerTopic()
    {
        var lines = VariablesTypesPresenter.BuildLines();

        Assert.Contains("averageHoursPerTopic (decimal): 1.5", lines);
    }
}

