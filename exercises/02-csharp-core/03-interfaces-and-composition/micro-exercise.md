---
title: Interface Pair Drill
stage: 02-csharp-core
topic: 03-interfaces-and-composition
exercise_type: micro
estimated_minutes: 10
prerequisites:
  - 03 Interfaces And Composition
success_criteria:
  - Define one interface and implement it in two small classes.
  - Call the shared contract from the main flow.
---

# Interface Pair Drill

## Prompt

Create an interface named `IStatusLine` with one method: `BuildLine()`.

Create two small classes that implement the interface and return different text. Then print both results.

## Constraints

- Keep the drill to one interface and two tiny implementations.
- Do not add inheritance.

## Hints

- The method can return a `string`.
- Store the implementations in an array of `IStatusLine`.

## Verification

The drill is complete when the program prints two different lines by calling the same interface method on both objects.

## Extension Ideas

- Add a third implementation.
- Let one implementation include a number or time value.