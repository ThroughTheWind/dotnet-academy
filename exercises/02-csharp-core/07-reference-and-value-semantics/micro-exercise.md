---
title: Copy Behavior Drill
stage: 02-csharp-core
topic: 07-reference-and-value-semantics
exercise_type: micro
estimated_minutes: 10
prerequisites:
  - 02 Records Structs And Enums
  - 05 Generics Collections And Exceptions
success_criteria:
  - Show one shared reference-type update.
  - Show one copied value-type update that leaves the original unchanged.
---

# Copy Behavior Drill

## Prompt

Create two tiny types:

- a class named `StudyTemplate`
- a `readonly record struct` named `StudySlot`

Then:

1. copy a `StudyTemplate` reference into a second variable and update the title through one variable
2. copy a `StudySlot` value into a second variable and create an adjusted version with a different minute count
3. print both results so the behavioral difference is visible

## Constraints

- Keep the drill to one class and one value-like type.
- Do not add inheritance.
- Print the original and adjusted values explicitly.

## Hints

- A class copy shares the same object reference.
- A `readonly record struct` copy produces a separate value.
- `with` expressions work well for record-like updates.

## Verification

The drill is complete when one output proves the shared reference changed and another proves the copied value did not mutate the original.

## Extension Ideas

- Add a mutable struct and explain why it is riskier.
- Add a record class and compare its usage to the struct.