using System.Collections.Frozen;
using System.Collections.Immutable;

namespace DotnetAcademy.ReadOnlyImmutableFrozenCollectionsDemo;

public sealed class StudyGuideLibrary
{
    private readonly HashSet<string> _codes = new(StringComparer.OrdinalIgnoreCase);
    private readonly List<StudyGuideEntry> _entries = [];

    public int Count => _entries.Count;

    public void Add(StudyGuideEntry entry)
    {
        ArgumentNullException.ThrowIfNull(entry);

        if (!_codes.Add(entry.Code))
        {
            throw new InvalidOperationException("An entry with the same code already exists.");
        }

        _entries.Add(entry);
    }

    public FrozenSet<string> CreateFrozenCategorySet()
    {
        return _entries
            .Select(entry => entry.Category)
            .ToFrozenSet(StringComparer.OrdinalIgnoreCase);
    }

    public FrozenDictionary<string, PublishedGuideCard> CreateFrozenLookup()
    {
        return _entries
            .Select(PublishedGuideCard.FromEntry)
            .ToFrozenDictionary(card => card.Code, StringComparer.OrdinalIgnoreCase);
    }

    public ImmutableArray<PublishedGuideCard> CreateImmutableSnapshot()
    {
        return _entries
            .Select(PublishedGuideCard.FromEntry)
            .ToImmutableArray();
    }

    public IReadOnlyList<StudyGuideEntry> CreateReadOnlyView()
    {
        return _entries.AsReadOnly();
    }
}