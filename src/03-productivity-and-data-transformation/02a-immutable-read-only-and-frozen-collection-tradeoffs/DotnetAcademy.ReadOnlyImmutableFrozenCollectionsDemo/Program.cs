using DotnetAcademy.ReadOnlyImmutableFrozenCollectionsDemo;

foreach (var line in ReadOnlyImmutableFrozenPresenter.BuildLines())
{
    Console.WriteLine(line);
}