---
title: 02 Collections And Immutability Tradeoffs
stage: 03-productivity-and-data-transformation
topic: 02-collections-and-immutability-tradeoffs
level: intermediate
estimated_hours: 2
prerequisites:
  - 03 Generics Collections And Exceptions
  - 01 LINQ Fundamentals And Query Thinking
learning_outcomes:
  - Choose collection types from the access pattern the code needs.
  - Explain the tradeoff between mutable working state and stable published snapshots.
  - Use read-only boundaries without confusing them with deep immutability.
---

# 02 Collections And Immutability Tradeoffs

## Why This Matters

Most application code spends more time moving data through collections than inventing new algorithms.

If the collection choice is wrong, the code becomes noisy, lookup paths become awkward, and accidental mutation starts leaking across boundaries. If the mutation boundary is unclear, reports and APIs can start changing underneath their readers.

This topic focuses on two practical questions:

- which collection best matches the way the code reads and updates data
- when should the code stop mutating live state and publish a stable snapshot instead

## Concepts

### 1. Collection Choice Starts With Access Patterns

Before reaching for a type, ask what the code needs most often.

- Use `List<T>` when order matters or when you append and iterate frequently.
- Use `Dictionary<TKey, TValue>` when fast lookup by key matters.
- Use `HashSet<T>` when uniqueness matters more than ordering.

The best collection is usually the one that makes the main operation obvious.

### 2. One Model Can Serve The Working State, Another Can Serve The Published Result

Many applications build data in a mutable structure and then publish a stable read model.

That split is useful because the working structure can stay convenient for updates, while the published structure can stay safe for readers.

```csharp
var board = new StudyBoard();
board.Add(new StudyBoardItem("BOARD-02", "Contrast dictionary lookups", "collections", priority: 1));

var snapshot = board.PublishSnapshot();
board.MarkComplete("BOARD-02");
```

After the mutation, the live board has changed, but the earlier snapshot should still describe the older state.

### 3. Read-Only APIs Help Boundaries, But They Do Not Automatically Make Data Deeply Immutable

Interfaces like `IReadOnlyList<T>` or `IReadOnlyCollection<T>` are useful because they communicate intent at an API boundary.

They do not, by themselves, guarantee that the underlying object graph will never change. That matters when the reader expects a stable historical view rather than just a restricted API surface.

### 4. Copy When A Stable Snapshot Matters

When a caller needs a point-in-time result, create a new collection for the published data.

```csharp
var priorityTitles = items
    .Where(item => !item.Completed)
    .OrderBy(item => item.Priority)
    .Select(item => item.Title)
    .ToArray();
```

The copy creates separation between later mutations and the earlier published output.

### 5. Keep The Deeper Immutable-Collection Discussion Separate

This topic establishes the habit of protecting boundaries.

The next follow-up slice, `S03-02A`, will go deeper into immutable, read-only, and frozen collection types and their more specific runtime tradeoffs.

## Demo

The runnable sample for this topic lives at:

`src/03-productivity-and-data-transformation/02-collections-and-immutability-tradeoffs/DotnetAcademy.CollectionsTradeoffsDemo/`

Run it from the repository root:

```powershell
dotnet run --project ./src/03-productivity-and-data-transformation/02-collections-and-immutability-tradeoffs/DotnetAcademy.CollectionsTradeoffsDemo
```

Expected result:

- a mutable planning board tracks ordered items, keyed lookup, and unique categories
- a published snapshot stays stable after the live board changes
- the output shows why collection choice and mutation boundaries are tied together

## Common Mistakes

- Using `List<T>` for every problem even when keyed lookup or uniqueness is the real concern.
- Returning live mutable collections from APIs that should publish stable results.
- Assuming `IReadOnlyList<T>` means the underlying data can never change.
- Copying data everywhere without a boundary-driven reason.
- Mixing working-state behavior and published-report behavior into one unclear model.

## Exercises

Use `exercises.md` for the guided exercise.

The starter pack for this topic lives under:

`exercises/03-productivity-and-data-transformation/02-collections-and-immutability-tradeoffs/`

It includes a workspace folder, a challenge brief, expected output examples, and a short micro drill about snapshot boundaries.

## Verification

This topic is successful when the learner can do all of the following:

- explain why each collection in a small program was chosen
- use at least one mutable working structure and one stable published result
- demonstrate that a published snapshot does not change after later updates
- describe the difference between a read-only API surface and a deeply immutable structure

