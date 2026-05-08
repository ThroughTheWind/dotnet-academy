---
title: Snapshot Boundary Drill
stage: 03-productivity-and-data-transformation
topic: 02-collections-and-immutability-tradeoffs
exercise_type: micro
estimated_minutes: 10
prerequisites:
  - 02 Collections And Immutability Tradeoffs
success_criteria:
  - Copy a live list into a published snapshot.
  - Show that later mutations do not change the copied result.
---

# Snapshot Boundary Drill

## Prompt

Create a small list of open work-item titles.

Then:

1. create a copied snapshot from that list
2. change the original list
3. print both collections
4. explain why the copied snapshot stayed stable

## Constraints

- Keep the drill to one live list and one copied snapshot.
- Use a copied collection for the published result instead of reusing the same instance.
- Print both values after the mutation.

## Hints

- `ToList()` or `ToArray()` can create a copied collection.
- Mutating the original list after the copy should not change the copied result.
- Focus on the boundary between working state and published state.

## Verification

The drill is complete when the copied snapshot prints the original values even after the live list has been changed.

## Extension Ideas

- Repeat the drill with a second mutation.
- Wrap the copied result in a small immutable record.