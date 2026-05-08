---
title: 05 Async And Await Foundations Exercise
stage: 03-productivity-and-data-transformation
topic: 05-async-and-await-foundations
exercise_type: guided
estimated_minutes: 80
prerequisites:
  - 05 Async And Await Foundations
success_criteria:
  - Write at least one method returning `Task<T>`.
  - Await multiple independent operations together.
  - Explain why the solution does not block with `.Result` or `.Wait()`.
---

# 05 Async And Await Foundations Exercise

## Prompt

Create a console app named `StudyDigestAsyncConsole` that gathers module progress from multiple asynchronous sources and prints a summary.

Your app must:

1. model each source as an asynchronous method returning `Task<T>`
2. start multiple independent operations
3. await the combined result with `Task.WhenAll`
4. shape the completed results into a readable report
5. explain in one note why the solution uses `await` instead of blocking

Use the starter pack in `exercises/03-productivity-and-data-transformation/05-async-and-await-foundations/` while working.

## Constraints

- Keep the first version focused on `Task`, `await`, and `Task.WhenAll`.
- Do not add cancellation, async streams, or `ValueTask` in this slice.
- Keep the asynchronous work separate from the final formatting logic.
- Use fake delayed sources instead of external services for the first version.

## Hints

- `Task.Delay` is enough to simulate asynchronous work in a beginner-friendly sample.
- Start independent tasks first, then await them together.
- `async Task<T>` is the usual starting point when an asynchronous method returns a value.
- Shape the finished results after the await instead of mixing formatting into each source method.

## Verification

The exercise is complete when the learner can show all of the following:

- the project builds and runs successfully
- the code uses `async` and `await` rather than `.Result` or `.Wait()`
- multiple independent operations are awaited together with `Task.WhenAll`
- the final report is produced after the asynchronous results complete

## Extension Ideas

- Add one more asynchronous source and confirm the summary still composes cleanly.
- Compare sequential awaiting with `Task.WhenAll` in a short note.
- Prepare a follow-up list of places where cancellation would matter, without implementing it yet.

## Micro Exercise

For a 10-minute focused drill, use `exercises/03-productivity-and-data-transformation/05-async-and-await-foundations/micro-exercise.md`.

This micro exercise isolates `Task.WhenAll` over a few small delayed operations.

