---
title: 06 Lambdas Delegates Events And Pattern Matching Exercise
stage: 02-csharp-core
topic: 06-lambdas-delegates-events-and-pattern-matching
exercise_type: guided
estimated_minutes: 75
prerequisites:
  - 06 Lambdas Delegates Events And Pattern Matching
success_criteria:
  - Use a delegate and a lambda to filter or format session data.
  - Raise and handle one event.
  - Use pattern matching to build readable result descriptions.
---

# 06 Lambdas Delegates Events And Pattern Matching Exercise

## Prompt

Create a console app named `SessionSignalConsole` that records study results and prints the ones that still need follow-up.

Your app must:

1. define a small set of result shapes for a learner session
2. use a delegate and a lambda to choose which results belong in a focus list
3. raise one event each time a result is recorded
4. use pattern matching to turn each result into readable text
5. print both the recorded notifications and the filtered focus list

Use the starter pack in `exercises/02-csharp-core/06-lambdas-delegates-events-and-pattern-matching/` while working.

## Constraints

- Keep the app as a console app.
- Keep the event flow synchronous and easy to follow.
- Use pattern matching instead of long chained type checks.
- Keep the lambda expressions short enough to read at the call site.

## Hints

- A custom delegate can express the filter signature clearly for this exercise.
- Store event messages in a `List<string>` so you can print them later.
- A `switch` expression often reads better than nested `if` statements here.
- One result type can represent a strong finish, another can represent more practice, and another can represent a skipped task.

## Verification

The exercise is complete when the learner can show all of the following:

- the project builds and runs successfully
- an event fires for each recorded result
- the focus list only contains the results that still need attention
- the descriptions come from pattern matching rather than manual string branching everywhere

## Extension Ideas

- Replace one lambda with a named method and compare readability.
- Add another result shape and update the pattern matching logic.
- Add a second event subscriber that logs a shorter message.

## Micro Exercise

For a 10-minute focused drill, use `exercises/02-csharp-core/06-lambdas-delegates-events-and-pattern-matching/micro-exercise.md`.

This micro exercise isolates one pattern-matching function before the full guided exercise.

