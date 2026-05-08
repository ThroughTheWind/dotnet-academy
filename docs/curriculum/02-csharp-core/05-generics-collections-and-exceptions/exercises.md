---
title: 05 Generics Collections And Exceptions Exercise
stage: 02-csharp-core
topic: 05-generics-collections-and-exceptions
exercise_type: guided
estimated_minutes: 70
prerequisites:
  - 05 Generics Collections And Exceptions
success_criteria:
  - Build a generic catalog class with a meaningful type constraint.
  - Use more than one collection to support different operations.
  - Throw and handle at least one standard exception correctly.
---

# 05 Generics Collections And Exceptions Exercise

## Prompt

Create a console app named `PracticeCatalogConsole` that tracks small study resources for a learner.

Your app must:

1. define one contract for a plannable study resource
2. create a generic catalog type that stores those resources safely
3. use at least two collections with different roles
4. reject one invalid operation by throwing a standard exception
5. catch a specific exception in the top-level flow and print a readable note

Use the starter pack in `exercises/02-csharp-core/05-generics-collections-and-exceptions/` while working.

## Constraints

- Keep the app as a console app.
- Use a generic class, not a non-generic `object` container.
- Use standard exceptions such as `ArgumentException`, `InvalidOperationException`, or `KeyNotFoundException`.
- Return read-only views when exposing stored items.

## Hints

- A `List<T>` can preserve output order while a `Dictionary<string, T>` can support lookup.
- A `HashSet<string>` is a simple way to track unique categories or tags.
- Catch the exception near `Main` or a presenter method instead of deep inside the catalog.
- Keep the resource model small so the design stays focused on generics and collections.

## Verification

The exercise is complete when the learner can show all of the following:

- the project builds and runs successfully
- the generic catalog rejects at least one invalid operation
- the output includes both the catalog contents and the handled error note
- the collection choices are explainable in plain language

## Extension Ideas

- Add a second resource type that still fits the same generic catalog.
- Replace one collection with a worse fit and explain what becomes harder.
- Add another lookup path and choose whether it should return a fallback or throw.

## Micro Exercise

For a 10-minute focused drill, use `exercises/02-csharp-core/05-generics-collections-and-exceptions/micro-exercise.md`.

This micro exercise isolates one small generic collection and one invalid operation before the full guided exercise.

