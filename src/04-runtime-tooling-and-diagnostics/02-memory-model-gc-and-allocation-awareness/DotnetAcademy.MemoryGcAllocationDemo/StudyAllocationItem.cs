namespace DotnetAcademy.MemoryGcAllocationDemo;

public sealed class StudyAllocationItem
{
    public StudyAllocationItem(string category, int minutes, string notes)
    {
        Category = category;
        Minutes = minutes;
        Notes = notes;
    }

    public string Category { get; }

    public int Minutes { get; }

    public string Notes { get; }
}