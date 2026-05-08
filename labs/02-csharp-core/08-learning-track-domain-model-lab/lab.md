---
title: Learning Track Domain Model Lab
stage: 02-csharp-core
topic: 08-learning-track-domain-model-lab
exercise_type: guided
estimated_minutes: 110
prerequisites:
  - 01 Classes And Objects
  - 02 Records Structs And Enums
  - 03 Interfaces And Composition
  - 04 Inheritance Basics
  - 05 Generics Collections And Exceptions
  - 06 Lambdas Delegates Events And Pattern Matching
success_criteria:
  - Build a small domain model with a shared abstraction and at least two specialized item types.
  - Use one value-like type where copy semantics are useful and one reference type where shared state is intentional.
  - Add a generic catalog with one validation rule and handle one invalid lookup at the boundary.
  - Raise one event and use pattern matching to build readable output.
---

# Learning Track Domain Model Lab

## Scenario

You are building a small planning tool for a learner moving through the Stage 2 C# material. The tool should model track items clearly enough that another developer could extend it without guessing where state lives or how behavior is shared.

## Prompt

Build a console app that prints a learner track summary and a short focus list.

Your program should:

- read the learner name from the first command-line argument, with a safe fallback
- define one shared abstraction for track items
- create at least two specialized item types with different data or behavior
- use one small value-like type for an estimate or checkpoint value
- store the track items in a generic catalog or planner collection
- raise one event when a track item is scheduled
- use pattern matching to build the readable summaries
- catch one invalid lookup at the boundary and print a clear note

## Milestones

1. Create a console app in the recommended workspace and confirm it runs with `dotnet run`.
2. Add the shared abstraction, one value-like type, and the first specialized item type.
3. Add a second specialized item type and write the summary logic with pattern matching.
4. Add a generic catalog plus one validation rule that rejects a bad state, such as a duplicate code.
5. Add a scheduling class or planner that raises an event when an item is added to the learner track.
6. Re-run the app after each meaningful change and compare the structure against `starter/expected-output.md`.

## Constraints

- Target .NET 10.
- Keep the application as a console app.
- Keep the domain small enough to explain each type choice in plain language.
- Use standard exceptions for invalid input or duplicate entries.
- Do not hide the control flow inside one large method.

## Hints

- An abstract base class or an interface can both work as the shared abstraction.
- A `readonly record struct` is a reasonable fit for a small immutable estimate value.
- A generic catalog can use both a `List<T>` for order and a `Dictionary<TKey, TValue>` for lookup.
- Pattern matching reads well when different item shapes need different summary text.
- An event can record that an item was scheduled without hard-coding the output behavior into the domain type itself.

## Verification

Run your project with a learner name and compare the structure with the expected output example:

```bash
dotnet run --project ./workspace/LearningTrackPlannerConsole -- Ada
```

If you get stuck, inspect the reference implementation in `solution/` only after you have tried the milestones yourself.

## Extension Ideas

- Add a third specialized item type.
- Add a second subscriber to the scheduling event.
- Add another rule that decides which items belong in the focus list.