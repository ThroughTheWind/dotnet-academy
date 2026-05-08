---
title: Imperative And LINQ Focus Drill
stage: 03-productivity-and-data-transformation
topic: 07-imperative-versus-linq-comparison
exercise_type: micro
estimated_minutes: 10
prerequisites:
  - 01 LINQ Fundamentals And Query Thinking
  - 02 Collections And Immutability Tradeoffs
success_criteria:
  - Build one filtered focus list with explicit loops.
  - Build the same filtered focus list with LINQ.
---

# Imperative And LINQ Focus Drill

## Prompt

Create a small collection of study work items with a module name, pending-step count, and minute total.

Then:

1. build a list of modules with at least two pending steps using a `foreach` loop and explicit list mutation
2. build the same list again with a LINQ pipeline using filtering, ordering, and projection
3. print both results side by side
4. explain in one sentence which version made the ordering logic easier to see

## Constraints

- Keep the drill to one small in-memory collection.
- Do not use LINQ in the imperative version.
- Do not hide the imperative logic behind helper libraries.

## Hints

- The imperative version will likely use `if`, `Add`, and an explicit sort step.
- The LINQ version will likely use `Where`, `OrderByDescending`, and `Select`.
- The point is to compare readability and mutation, not to prove one style always wins.

## Verification

The drill is complete when both outputs contain the same module names in the same order.

## Extension Ideas

- Add a tie-breaker on module name.
- Add a grouped summary and compare how much extra state the imperative version needs.