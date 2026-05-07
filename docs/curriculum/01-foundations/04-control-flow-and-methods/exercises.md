---
title: 04 Control Flow And Methods Exercise
stage: 01-foundations
topic: 04-control-flow-and-methods
exercise_type: guided
estimated_minutes: 55
prerequisites:
  - 03 Variables Types And Conversions
  - 04 Control Flow And Methods
success_criteria:
  - Use control flow to choose between at least two study recommendations.
  - Write and call at least one method with parameters and a return value.
  - Use a loop to print a short sequence of suggested practice steps.
---

# 04 Control Flow And Methods Exercise

## Prompt

Create a console app named `StudyDecisionConsole` that prints a small study recommendation.

Your app must:

1. store `completedTopics` in an `int`
2. store `practicedToday` in a `bool`
3. use a method to calculate a readiness message
4. use `if` and `else` to choose between at least two outcomes
5. use a `for` loop to print a short list of suggested practice sessions
6. print a readable multi-line summary

Use the starter pack in `exercises/01-foundations/04-control-flow-and-methods/` while working.

## Constraints

- Use top-level statements in `Program.cs`.
- Include at least one method that returns a `string`.
- Include at least one `if` and `else` branch.
- Include one `for` loop.
- Keep the app focused on control flow and methods rather than user input parsing.

## Hints

- A method like `GetReadinessMessage(int completedTopics, bool practicedToday)` is a good starting point.
- A `for` loop can print `Practice session 1`, `Practice session 2`, and so on.
- Use clear method names so the program reads like a set of instructions.
- Start with fixed values before you try to make the program more dynamic.

## Verification

The exercise is complete when the learner can show all of the following:

- the project builds and runs successfully
- the output changes when the values driving the condition change
- at least one method is called from the main flow of the app
- a short repeated sequence is printed by a loop

Compare your output structure to the starter pack examples. The exact wording can differ.

## Extension Ideas

- Add a second method that returns the number of suggested practice sessions.
- Replace one `if`/`else if` chain with a `switch` expression after the main version works.
- Accept command-line arguments later and pass them into the same methods.

