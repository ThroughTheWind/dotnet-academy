namespace DotnetAcademy.LambdasDelegatesEventsPatternMatchingDemo;

public sealed class StudyProgressTracker
{
	private readonly List<StudyResult> _results = [];

	public event EventHandler<StudyResultRecordedEventArgs>? ResultRecorded;

	public IReadOnlyList<string> BuildLines(StudyResultFilter filter, StudyResultFormatter formatter)
	{
		ArgumentNullException.ThrowIfNull(filter);
		ArgumentNullException.ThrowIfNull(formatter);

		var lines = new List<string>();

		foreach (var result in _results)
		{
			if (filter(result))
			{
				lines.Add(formatter(result));
			}
		}

		return lines;
	}

	public IReadOnlyList<StudyResult> GetResults()
	{
		return _results;
	}

	public void Record(StudyResult result)
	{
		ArgumentNullException.ThrowIfNull(result);

		_results.Add(result);
		OnResultRecorded(new StudyResultRecordedEventArgs(result, StudyResultDescriber.Describe(result)));
	}

	private void OnResultRecorded(StudyResultRecordedEventArgs args)
	{
		ResultRecorded?.Invoke(this, args);
	}
}