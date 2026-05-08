---
title: Read Only Versus Immutable Drill
stage: 03-productivity-and-data-transformation
topic: 02a-immutable-read-only-and-frozen-collection-tradeoffs
exercise_type: micro
estimated_minutes: 10
prerequisites:
  - 02A Immutable Read Only And Frozen Collection Tradeoffs
success_criteria:
  - Show that a read-only wrapper can still reflect later changes.
  - Show that an immutable copy stays fixed.
---

# Read Only Versus Immutable Drill

## Prompt

Create a list of three guide titles.

Then:

1. capture a read-only wrapper over the list
2. capture an immutable copy of the titles
3. add a fourth item to the original list
4. print both results and explain why they differ

## Constraints

- Use one original mutable list.
- Use one read-only wrapper and one immutable copy.
- Print both after the mutation.

## Hints

- `AsReadOnly()` creates a read-only wrapper over the original list.
- `ToImmutableArray()` creates a stable copy.
- The difference is about whether the later source mutation can still be observed.

## Verification

The drill is complete when the read-only wrapper shows the new item and the immutable copy does not.

## Extension Ideas

- Repeat the drill with item removal.
- Compare `IReadOnlyList<T>` with `ImmutableArray<T>` in one short note.