namespace DotnetAcademy.DomainModelingDemo;

public sealed class PlanCatalog<TStep> where TStep : ILearningStep
{
    private readonly List<TStep> _orderedSteps = [];
    private readonly Dictionary<string, TStep> _stepsByCode = new(StringComparer.OrdinalIgnoreCase);

    public int Count => _orderedSteps.Count;

    public void Add(TStep step)
    {
        ArgumentNullException.ThrowIfNull(step);

        if (!_stepsByCode.TryAdd(step.Code, step))
        {
            throw new InvalidOperationException($"A learning step with code '{step.Code}' already exists.");
        }

        _orderedSteps.Add(step);
    }

    public TStep FindByCode(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            throw new ArgumentException("A code is required.", nameof(code));
        }

        return _stepsByCode.TryGetValue(code.Trim(), out var step)
            ? step
            : throw new KeyNotFoundException($"No learning step was found for code '{code.Trim()}'.");
    }

    public IReadOnlyList<TStep> GetAll()
    {
        return _orderedSteps;
    }
}