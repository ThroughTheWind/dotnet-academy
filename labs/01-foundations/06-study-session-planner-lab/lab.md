---
title: Study Session Planner Lab
stage: 01-foundations
topic: 06-study-session-planner-lab
exercise_type: guided
estimated_minutes: 90
prerequisites:
  - 01 Development Environment And CLI
  - 02 First Console Application
  - 03 Variables Types And Conversions
  - 04 Control Flow And Methods
  - 05 Nullability And Debugging Basics
success_criteria:
  - Create or update a console app that accepts a learner name from command-line arguments.
  - Convert at least one numeric value from text before using it.
  - Use helper methods, a branching decision, and a loop to build a practice plan.
  - Handle at least one optional value safely with a fallback.
---

# Study Session Planner Lab

## Scenario

You are building a small study-session planner for a learner who just finished the first Stage 1 topics. The program should print a short plan that helps the learner decide what to practice next.

## Prompt

Build a console app that prints a Stage 1 study summary and a small action plan.

Your program should:

- read the learner name from the first command-line argument
- convert numeric text into real numeric types before printing it
- use at least one method to calculate or format output
- use a condition to change the readiness message
- use a loop to build the action list
- safely display a fallback value when optional information is missing

## Milestones

1. Create a console app in the recommended workspace and confirm it runs with `dotnet run`.
2. Add variables for the weekly target, completed topics, and practice hours. Store at least one of those values as text first, then convert it.
3. Move the output-building logic into helper methods instead of keeping everything in one block.
4. Add an optional mentor name or warning value and display a safe fallback when it is missing.
5. Re-run the app after each small change and compare the structure against `starter/expected-output.md`.

## Constraints

- Target .NET 10.
- Keep the application as a console app.
- Do not hardcode the final result as one large multi-line string.
- Use explicit culture-aware parsing or formatting when converting numeric values.

## Hints

- `args[0]` is the first command-line argument when it exists.
- `int.Parse` and `decimal.Parse` can convert text into numbers.
- `??` and `string.IsNullOrWhiteSpace` are both valid beginner-friendly fallback patterns.
- A `for` loop is enough for the action list; you do not need advanced collections.

## Verification

Run your project with a learner name and compare the structure with the expected output example:

```bash
dotnet run --project ./workspace/DotnetAcademy.StudySessionPlannerLab -- Ada
```

If you get stuck, inspect the reference implementation in `solution/` only after you have tried the milestones yourself.

## Extension Ideas

- Accept the weekly topic target from a second command-line argument.
- Let the learner choose whether they practiced today.
- Add another warning rule and print a different debug tip when it appears.