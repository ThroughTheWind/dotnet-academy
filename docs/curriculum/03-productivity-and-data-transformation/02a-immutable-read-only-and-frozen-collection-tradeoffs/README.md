# 02A Immutable Read Only And Frozen Collection Tradeoffs

## Goal

This follow-up topic teaches the learner when a read-only collection boundary is enough, when an immutable snapshot is safer, and when a frozen collection is worth the one-time build cost for repeated lookups.

By the end of the topic, the learner should be able to:

- explain why `IReadOnlyList<T>` hides mutators without guaranteeing a stable snapshot
- use immutable collections when a published result must not change later
- use frozen collections when the dataset is fixed and lookup-heavy
- choose the simplest collection boundary that still protects the caller correctly

## Deliverables

- `lesson.md` contains the teaching material for read-only, immutable, and frozen collection tradeoffs.
- `exercises.md` contains a guided exercise for publishing multiple collection surfaces from one source.
- Runnable sample project: `src/03-productivity-and-data-transformation/02a-immutable-read-only-and-frozen-collection-tradeoffs/DotnetAcademy.ReadOnlyImmutableFrozenCollectionsDemo/`.
- Learner starter assets: `exercises/03-productivity-and-data-transformation/02a-immutable-read-only-and-frozen-collection-tradeoffs/`.
- Automated tests: `tests/03-productivity-and-data-transformation/02a-immutable-read-only-and-frozen-collection-tradeoffs/DotnetAcademy.ReadOnlyImmutableFrozenCollectionsDemo.Tests/`.

## Status

- Lesson bundle authored
- Runnable sample added
- Starter assets added
- Tests added
