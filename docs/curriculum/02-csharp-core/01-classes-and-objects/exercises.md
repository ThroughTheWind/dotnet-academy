---
title: 01 Classes And Objects Exercise
stage: 02-csharp-core
topic: 01-classes-and-objects
exercise_type: guided
estimated_minutes: 60
prerequisites:
  - 01 Classes And Objects
success_criteria:
  - Create a class with a constructor, properties, and at least one instance method.
  - Create more than one object from the same class.
  - Print a readable summary that uses object state rather than loose variables.
---

# 01 Classes And Objects Exercise

## Prompt

Create a console app named `StudyGroupConsole` that models a small study group.

Your app must:

1. define a `StudyGroupMember` class
2. create at least two `StudyGroupMember` objects
3. store each member's name and completed topic count inside the object
4. include at least one method on the class that returns a readable summary
5. print a short report that uses the objects instead of loose variables

Use the starter pack in `exercises/02-csharp-core/01-classes-and-objects/` while working.

## Constraints

- Use a constructor to set the most important starting values.
- Include at least one read-only property.
- Keep the class focused on one concept.
- Do not replace the object model with a dictionary or a long list of unrelated variables.

## Hints

- A class like `StudyGroupMember` or `WorkshopParticipant` is enough for the first version.
- A method like `GetProgressSummary()` is a good way to keep formatting logic on the class.
- Create one object first, then create a second one from the same class.
- Start with fixed values before trying command-line arguments or user input.

## Verification

The exercise is complete when the learner can show all of the following:

- the project builds and runs successfully
- the app creates at least two distinct objects
- the output clearly comes from object properties and methods
- one behavior lives on the class instead of being duplicated in `Program.cs`

Compare your output structure to the starter pack examples. The exact wording can differ.

## Extension Ideas

- Add a method that updates the number of completed topics.
- Add a computed property that shows how many topics remain before a goal is reached.
- Introduce a second class later for the study group itself.

## Micro Exercise

For a 10-minute focused drill, use `exercises/02-csharp-core/01-classes-and-objects/micro-exercise.md`.

This micro exercise isolates one small class with one property and one method before the full guided exercise.