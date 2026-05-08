---
title: 04 Inheritance Basics Exercise
stage: 02-csharp-core
topic: 04-inheritance-basics
exercise_type: guided
estimated_minutes: 65
prerequisites:
  - 04 Inheritance Basics
success_criteria:
  - Define an abstract base class with shared members.
  - Create at least two derived classes that specialize the base type.
  - Override behavior in at least one derived class.
---

# 04 Inheritance Basics Exercise

## Prompt

Create a console app named `ResourcePlannerConsole` that models two kinds of learning resources.

Your app must:

1. define an abstract base class for a learning resource
2. create at least two derived resource types
3. share at least one property through the base class
4. override at least one member in a derived type
5. print a readable summary through base-type references

Use the starter pack in `exercises/02-csharp-core/04-inheritance-basics/` while working.

## Constraints

- Keep the base class focused on a true shared concept.
- Use inheritance only for the resource hierarchy itself.
- Include at least one abstract or virtual member.
- Keep the program as a console app.

## Hints

- An abstract `LearningResource` base class is enough for the first version.
- One derived type can represent a lesson and another can represent a coding challenge.
- Store the derived objects in a collection of the base type when printing the output.
- Add a short note to explain why the relationship is a true specialization.

## Verification

The exercise is complete when the learner can show all of the following:

- the project builds and runs successfully
- the base class cannot be instantiated directly
- one derived type overrides behavior from the base class
- the output is produced through base-type references

Compare your output structure to the starter pack examples. The exact wording can differ.

## Extension Ideas

- Add a third derived resource type.
- Move one behavior back to composition and compare the design.
- Add another shared base member that all derived types can use.

## Micro Exercise

For a 10-minute focused drill, use `exercises/02-csharp-core/04-inheritance-basics/micro-exercise.md`.

This micro exercise isolates one base type and one derived type before the full guided exercise.