---
title: Record Copy Drill
stage: 02-csharp-core
topic: 02-records-structs-and-enums
exercise_type: micro
estimated_minutes: 10
prerequisites:
  - 02 Records Structs And Enums
success_criteria:
  - Define one enum and one record.
  - Create a copied record with one changed value using `with`.
---

# Record Copy Drill

## Prompt

Create:

- an enum named `CardState` with at least three values
- a record named `TopicCard` with `Title` and `State`

Create one `TopicCard`, then create a second version with a changed state using `with`.

## Constraints

- Keep the drill to one enum and one record.
- Print both the original and copied record values.

## Hints

- `with` creates a copy instead of mutating the original record.
- One title string is enough for the drill.

## Verification

The drill is complete when the original and copied values print different states while sharing the same title.

## Extension Ideas

- Add a helper that formats the enum value more clearly.
- Compare two records with equal values.