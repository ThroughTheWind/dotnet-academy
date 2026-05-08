using DotnetAcademy.NullabilityDebuggingDemo;

namespace DotnetAcademy.NullabilityDebuggingDemo.Tests;

public class NullabilityDebuggingPresenterTests
{
    [Fact]
    public void GetMentorDisplayNameReturnsFallbackWhenValueMissing()
    {
        Assert.Equal("no mentor assigned", NullabilityDebuggingPresenter.GetMentorDisplayName(null));
        Assert.Equal("no mentor assigned", NullabilityDebuggingPresenter.GetMentorDisplayName("   "));
    }

    [Fact]
    public void GetMentorDisplayNameTrimsValueWhenPresent()
    {
        var display = NullabilityDebuggingPresenter.GetMentorDisplayName("  Ada  ");

        Assert.Equal("Ada", display);
    }

    [Fact]
    public void BuildDebuggingChecklistIncludesStepThroughTipWhenEnabled()
    {
        var lines = NullabilityDebuggingPresenter.BuildDebuggingChecklist(shouldDebugToday: true);

        Assert.Contains("- Step through the code or add temporary output to confirm where the value changed.", lines);
    }

    [Fact]
    public void BuildLinesIncludesRawStateFallbackAndChecklist()
    {
        var lines = NullabilityDebuggingPresenter.BuildLines(null, "possible null value detected", shouldDebugToday: true);

        Assert.Contains("mentorName raw state: <null>", lines);
        Assert.Contains("mentor display: no mentor assigned", lines);
        Assert.Contains("Debugging checklist:", lines);
    }
}

