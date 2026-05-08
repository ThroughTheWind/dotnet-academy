---
title: 03 Interfaces And Composition Exercise
stage: 02-csharp-core
topic: 03-interfaces-and-composition
exercise_type: guided
estimated_minutes: 70
prerequisites:
  - 03 Interfaces And Composition
success_criteria:
  - Define an interface and implement it in at least two classes.
  - Compose those implementations into a higher-level type.
  - Print output that comes from the composed abstraction rather than one concrete class.
---

# 03 Interfaces And Composition Exercise

## Prompt

Create a console app named `LearningPlanConsole` that builds a short learning plan.

Your app must:

1. define an interface for one learning step
2. create at least two classes that implement that interface differently
3. define a `LearningPlan` class that composes the interface implementations
4. print a readable agenda using the composed plan
5. calculate a total estimated time from the composed steps

Use the starter pack in `exercises/02-csharp-core/03-interfaces-and-composition/` while working.

## Constraints

- Keep the interface focused on behavior shared by all learning steps.
- Use composition instead of inheritance for the plan object.
- Include at least one method on the composed plan that summarizes all steps.
- Keep the program as a console app.

## Hints

- A property such as `EstimatedMinutes` works well in the interface.
- One implementation can represent a video lesson and another a coding task.
- Let the plan depend on `IReadOnlyList<ILearningStep>` or a similar abstraction.
- Build the total time by summing values from the composed steps.

## Verification

The exercise is complete when the learner can show all of the following:

- the project builds and runs successfully
- the plan works with more than one interface implementation
- the plan object does not depend on one concrete activity type
- the output includes both the agenda and the total estimated time

Compare your output structure to the starter pack examples. The exact wording can differ.

## Extension Ideas

- Add a third implementation type such as a quiz or review step.
- Let the plan reorder steps without changing the interface.
- Add another method that filters steps by estimated length.

## Micro Exercise

For a 10-minute focused drill, use `exercises/02-csharp-core/03-interfaces-and-composition/micro-exercise.md`.

This micro exercise isolates one small interface and two tiny implementations before the full guided exercise.