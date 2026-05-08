namespace DotnetAcademy.CollectionsTradeoffsDemo;

public sealed class StudyBoardItem
{
    public StudyBoardItem(string code, string title, string category, int priority, bool completed = false)
    {
        Code = string.IsNullOrWhiteSpace(code)
            ? throw new ArgumentException("A code is required.", nameof(code))
            : code.Trim().ToUpperInvariant();
        Title = string.IsNullOrWhiteSpace(title)
            ? throw new ArgumentException("A title is required.", nameof(title))
            : title.Trim();
        Category = string.IsNullOrWhiteSpace(category)
            ? throw new ArgumentException("A category is required.", nameof(category))
            : category.Trim().ToLowerInvariant();
        Priority = priority > 0
            ? priority
            : throw new ArgumentOutOfRangeException(nameof(priority), "Priority must be greater than zero.");
        Completed = completed;
    }

    public string Code { get; }

    public string Title { get; }

    public string Category { get; }

    public int Priority { get; }

    public bool Completed { get; private set; }

    public void MarkComplete()
    {
        Completed = true;
    }
}