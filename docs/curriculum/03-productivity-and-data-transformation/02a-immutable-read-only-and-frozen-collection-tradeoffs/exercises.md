---
title: 02A Immutable Read Only And Frozen Collection Tradeoffs Exercise
stage: 03-productivity-and-data-transformation
topic: 02a-immutable-read-only-and-frozen-collection-tradeoffs
exercise_type: guided
estimated_minutes: 80
prerequisites:
  - 02A Immutable Read Only And Frozen Collection Tradeoffs
success_criteria:
  - Publish a live read-only view, an immutable snapshot, and a frozen lookup from one source.
  - Demonstrate the behavioral difference between those surfaces after a later mutation.
  - Explain the tradeoff behind freezing data only after finalization.
---

# 02A Immutable Read Only And Frozen Collection Tradeoffs Exercise

## Prompt

Create a console app named `PublishedGuideCatalogConsole` that manages a small guide catalog and publishes three collection surfaces from it.

Your app must:

1. keep a mutable source collection inside a catalog class
2. expose a live read-only view for callers that should not mutate it directly
3. publish an immutable snapshot for reporting
4. publish a frozen lookup for repeated keyed access after finalization
5. show how the three surfaces behave after the live catalog changes

Use the starter pack in `exercises/03-productivity-and-data-transformation/02a-immutable-read-only-and-frozen-collection-tradeoffs/` while working.

## Constraints

- Keep the mutable source hidden inside the catalog type.
- Use a read-only wrapper for the live view instead of returning the raw list.
- Use an immutable collection for the snapshot instead of another wrapper over the live list.
- Build the frozen lookup from finalized data, not directly from a collection that still changes.

## Hints

- `AsReadOnly()` can expose a live read-only wrapper around a list.
- `ToImmutableArray()` or `ToImmutableDictionary()` can publish a stable snapshot.
- `ToFrozenDictionary()` or `ToFrozenSet()` fits a build-once, read-many lookup surface.
- Mutate the source after creating the three surfaces so the behavioral differences are visible.

## Verification

The exercise is complete when the learner can show all of the following:

- the project builds and runs successfully
- the read-only view reflects a later mutation to the source
- the immutable snapshot does not reflect that later mutation
- the frozen lookup still represents the finalized data that existed when it was built
- the learner can explain when each surface is the right choice

## Extension Ideas

- Add a frozen set for categories or tags and compare it with the frozen dictionary.
- Add a second immutable snapshot taken after the mutation and compare it with the first snapshot.
- Add a measurement note about why freezing too often could waste work.

## Micro Exercise

For a 10-minute focused drill, use `exercises/03-productivity-and-data-transformation/02a-immutable-read-only-and-frozen-collection-tradeoffs/micro-exercise.md`.

This micro exercise isolates the difference between a read-only wrapper and an immutable copy.

