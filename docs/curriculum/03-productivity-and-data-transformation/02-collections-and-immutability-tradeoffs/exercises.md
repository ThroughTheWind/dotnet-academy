---
title: 02 Collections And Immutability Tradeoffs Exercise
stage: 03-productivity-and-data-transformation
topic: 02-collections-and-immutability-tradeoffs
exercise_type: guided
estimated_minutes: 75
prerequisites:
  - 02 Collections And Immutability Tradeoffs
success_criteria:
  - Choose collection types that match the main operations in the program.
  - Publish a stable snapshot that does not change after later mutations.
  - Explain the tradeoff between mutable working state and published results.
---

# 02 Collections And Immutability Tradeoffs Exercise

## Prompt

Create a console app named `PlanningBoardConsole` that models a small study planning board.

Your app must:

1. store ordered work items in a mutable working structure
2. support lookup by item code
3. track unique categories
4. publish a stable snapshot for reporting
5. demonstrate that the published snapshot does not change after a later update to the live board

Use the starter pack in `exercises/03-productivity-and-data-transformation/02-collections-and-immutability-tradeoffs/` while working.

## Constraints

- Use at least three collection types across the solution.
- Keep mutation inside the working board model instead of spreading it across the console program.
- Publish a snapshot with copied data rather than returning the live mutable collections directly.
- Keep the example in memory; do not add files or databases yet.

## Hints

- `List<T>` is good for ordered work queues.
- `Dictionary<TKey, TValue>` is good for keyed lookup.
- `HashSet<T>` is good for tracking unique values.
- `ToList()`, `ToArray()`, or collection expressions can help create a stable published result when a boundary matters.

## Verification

The exercise is complete when the learner can show all of the following:

- the project builds and runs successfully
- the app can look up an item by code without scanning manually in calling code
- the report snapshot stays unchanged after the live board is updated
- the learner can explain why each collection type was chosen

## Extension Ideas

- Expose selected data through `IReadOnlyList<T>` or `IReadOnlyCollection<T>` and explain what that protects.
- Add duplicate-code validation to the board.
- Add a second published snapshot and compare it with the first one.

## Micro Exercise

For a 10-minute focused drill, use `exercises/03-productivity-and-data-transformation/02-collections-and-immutability-tradeoffs/micro-exercise.md`.

This micro exercise isolates the boundary between a live list and a published snapshot.

