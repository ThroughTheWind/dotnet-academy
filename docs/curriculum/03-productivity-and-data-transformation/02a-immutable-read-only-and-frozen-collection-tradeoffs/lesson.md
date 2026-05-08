---
title: 02A Immutable Read Only And Frozen Collection Tradeoffs
stage: 03-productivity-and-data-transformation
topic: 02a-immutable-read-only-and-frozen-collection-tradeoffs
level: intermediate
estimated_hours: 2
prerequisites:
  - 02 Collections And Immutability Tradeoffs
  - 03 Generics Collections And Exceptions
learning_outcomes:
  - Distinguish between read-only wrappers, immutable snapshots, and frozen collections.
  - Choose a publication surface based on mutation and lookup behavior.
  - Explain the build-once, read-many tradeoff behind frozen collections.
---

# 02A Immutable Read Only And Frozen Collection Tradeoffs

## Why This Matters

Once a program crosses a boundary, such as returning cached data, publishing configuration, or sharing reference data across many callers, the collection surface starts affecting correctness as much as convenience.

Three options often look similar at first glance, but they make different promises:

- a read-only wrapper limits the API surface while the source may still change
- an immutable collection gives a stable snapshot
- a frozen collection trades one-time build work for efficient repeated reads

Choosing the wrong one can either leak live mutation to callers or add unnecessary construction cost where a simpler API boundary would have been enough.

## Concepts

### 1. Read-Only Does Not Mean Immutable

`IReadOnlyList<T>` and `ReadOnlyCollection<T>` are useful when a caller should not mutate a collection directly.

They do not guarantee that the underlying list will stay unchanged. If the owner adds or removes items later, the caller can still observe those changes through the read-only view.

```csharp
var view = library.CreateReadOnlyView();
library.Add(new StudyGuideEntry("GUIDE-04", "Build a frozen category index", "frozen", 12));

Console.WriteLine(view.Count); // now includes the new item
```

### 2. Immutable Collections Publish Stable Snapshots

When a caller needs a point-in-time result, immutable collections are a better fit.

```csharp
var snapshot = library.CreateImmutableSnapshot();
library.Add(new StudyGuideEntry("GUIDE-04", "Build a frozen category index", "frozen", 12));

Console.WriteLine(snapshot.Length); // unchanged
```

That stability is useful for reporting, caching, and handoff boundaries where later mutation would be surprising.

### 3. Frozen Collections Target Build Once, Read Many Scenarios

Frozen collections are designed for data that is finalized and then read frequently.

They usually make sense after validation or startup work has already finished.

```csharp
var lookup = library.CreateFrozenLookup();

if (lookup.TryGetValue("guide-02", out var card))
{
    Console.WriteLine(card.Title);
}
```

The important tradeoff is that freezing has an upfront construction cost. That cost is justified only when the data stays fixed and the reads happen often enough to benefit.

### 4. The Right Choice Follows The Boundary

Use a read-only wrapper when the owner still controls a live collection and callers only need non-mutating access.

Use an immutable collection when callers need a stable snapshot.

Use a frozen collection when the dataset is finalized and keyed or membership-based reads dominate the workload.

### 5. Prefer The Smallest Honest Promise

Do not reach for an immutable or frozen structure just because it sounds safer.

Choose the narrowest promise that matches the real behavior the caller relies on. That keeps code simpler and makes performance tradeoffs easier to justify.

## Demo

The runnable sample for this topic lives at:

`src/03-productivity-and-data-transformation/02a-immutable-read-only-and-frozen-collection-tradeoffs/DotnetAcademy.ReadOnlyImmutableFrozenCollectionsDemo/`

Run it from the repository root:

```powershell
dotnet run --project ./src/03-productivity-and-data-transformation/02a-immutable-read-only-and-frozen-collection-tradeoffs/DotnetAcademy.ReadOnlyImmutableFrozenCollectionsDemo
```

Expected result:

- a live read-only wrapper reflects a later addition
- an immutable snapshot remains fixed
- a frozen lookup continues serving the precomputed data efficiently
- the output spells out which promise each surface actually makes

## Common Mistakes

- Assuming `IReadOnlyList<T>` means the underlying source cannot change.
- Building immutable snapshots for every call when a simple read-only boundary would have been enough.
- Freezing data before validation or before the dataset has actually stabilized.
- Using frozen collections when the code does not have a read-heavy access pattern.
- Forgetting that immutable or frozen collections still require a deliberate construction step.

## Exercises

Use `exercises.md` for the guided exercise.

The starter pack for this topic lives under:

`exercises/03-productivity-and-data-transformation/02a-immutable-read-only-and-frozen-collection-tradeoffs/`

It includes a workspace folder, a challenge brief, expected output examples, and a short micro drill for comparing a live read-only view with an immutable snapshot.

## Verification

This topic is successful when the learner can do all of the following:

- show a read-only wrapper that still reflects later source changes
- publish an immutable snapshot that does not change afterward
- build a frozen lookup only after the data is finalized
- justify why each surface was chosen for its specific boundary

