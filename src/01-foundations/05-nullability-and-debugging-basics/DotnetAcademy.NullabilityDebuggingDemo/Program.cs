foreach (var line in DotnetAcademy.NullabilityDebuggingDemo.NullabilityDebuggingPresenter.BuildLines(
			 mentorName: null,
			 recentWarning: "possible null value detected",
			 shouldDebugToday: true))
{
	Console.WriteLine(line);
}

