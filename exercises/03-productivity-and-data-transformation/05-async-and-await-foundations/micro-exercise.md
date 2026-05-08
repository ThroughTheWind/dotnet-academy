---
title: Task WhenAll Drill
stage: 03-productivity-and-data-transformation
topic: 05-async-and-await-foundations
exercise_type: micro
estimated_minutes: 10
prerequisites:
  - 05 Async And Await Foundations
success_criteria:
  - Start multiple independent tasks.
  - Await them together with `Task.WhenAll`.
---

# Task WhenAll Drill

## Prompt

Create three small asynchronous methods that each delay briefly and then return an integer.

Then:

1. start all three methods
2. await them together with `Task.WhenAll`
3. print the combined results
4. explain why the code did not use `.Result`

## Constraints

- Keep the drill to a few small delayed methods.
- Use `Task.WhenAll`.
- Do not add cancellation or streaming yet.

## Hints

- `Task.Delay` is enough to simulate async work.
- `Task.WhenAll` waits for all supplied tasks to finish.
- The point is to compose independent operations cleanly.

## Verification

The drill is complete when all results print after a single await over the combined task set.

## Extension Ideas

- Add a fourth task.
- Sort the finished results before printing them.