---
title: 05 Nullability And Debugging Basics Exercise
stage: 01-foundations
topic: 05-nullability-and-debugging-basics
exercise_type: guided
estimated_minutes: 50
prerequisites:
  - 04 Control Flow And Methods
  - 05 Nullability And Debugging Basics
success_criteria:
  - Use at least one nullable variable intentionally in a small console app.
  - Provide safe fallback text when a value is missing.
  - Include a short debugging checklist in the output or code comments.
---

# 05 Nullability And Debugging Basics Exercise

## Prompt

Create a console app named `LearnerSupportConsole` that prints a short learner support summary.

Your app must:

1. declare a nullable `string?` such as `mentorName`
2. declare another optional value such as a recent warning or last failed command
3. use a safe fallback when either value is missing
4. print a readable multi-line summary
5. include a short debugging checklist with at least three steps

Use the starter pack in `exercises/01-foundations/05-nullability-and-debugging-basics/` while working.

## Constraints

- Use top-level statements in `Program.cs`.
- Use `string?` for at least one text value.
- Use either `??` or a direct null check for the fallback behavior.
- Keep the debugging checklist short and beginner-friendly.

## Hints

- `mentorName ?? "no mentor assigned"` is a simple fallback pattern.
- `value is null` is a readable null check for beginners.
- If you are unsure where the wrong value came from, print the current variable values before changing the logic.
- The debugging checklist can be plain output text from the program.

## Verification

The exercise is complete when the learner can show all of the following:

- the project builds and runs successfully
- the output changes sensibly when an optional value is null versus present
- the program uses a safe fallback instead of assuming the optional value always exists
- the debugging checklist contains clear, concrete steps

Compare your output structure to the starter pack examples. The wording can differ.

## Extension Ideas

- Add a method that formats the optional value for display.
- Add one line that prints the raw state of the nullable value before the fallback display.
- Run the app once with a present value and once with a null value, then compare the outputs.

## Micro Exercise

For a 10-minute focused drill, use `exercises/01-foundations/05-nullability-and-debugging-basics/micro-exercise.md`.

This micro exercise isolates the smallest safe habit from the topic: acknowledge a nullable value, provide a fallback, and describe what to inspect before changing the code.

