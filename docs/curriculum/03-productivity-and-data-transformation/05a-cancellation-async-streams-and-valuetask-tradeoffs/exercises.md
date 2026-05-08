---
title: 05A Cancellation Async Streams And ValueTask Tradeoffs Exercise
stage: 03-productivity-and-data-transformation
topic: 05a-cancellation-async-streams-and-valuetask-tradeoffs
exercise_type: guided
estimated_minutes: 90
prerequisites:
  - 05A Cancellation Async Streams And ValueTask Tradeoffs
success_criteria:
  - Stream values with `IAsyncEnumerable<T>` and consume them with `await foreach`.
  - Propagate cancellation through the streamed workflow.
  - Use `ValueTask<T>` only for a narrow cache-oriented helper.
---

# 05A Cancellation Async Streams And ValueTask Tradeoffs Exercise

## Prompt

Create a console app named `StudyActivityStreamConsole` that prints a study activity digest from a streamed source.

Your app must:

1. expose study activity as `IAsyncEnumerable<T>`
2. consume the stream with `await foreach`
3. stop a preview run early with a `CancellationTokenSource`
4. attach a short recommendation from a cache-oriented API that may return synchronously with `ValueTask<T>`
5. explain in one note why most asynchronous APIs in the solution should still return `Task<T>`

Use the starter pack in `exercises/03-productivity-and-data-transformation/05a-cancellation-async-streams-and-valuetask-tradeoffs/` while working.

## Constraints

- Keep the main data source in-memory and delay-based rather than using external services.
- Use one shared cancellation token for the preview path.
- Use `await foreach` instead of forcing the stream into a list immediately.
- Limit `ValueTask<T>` to the recommendation cache helper.
- Do not turn every asynchronous method into `ValueTask<T>`.

## Hints

- `[EnumeratorCancellation]` helps streamed producers accept cancellation cleanly.
- `await foreach` makes sense when values arrive over time.
- A cache hit is one of the few approachable examples where `ValueTask<T>` can complete synchronously.
- If the helper almost always awaits real work, `Task<T>` is usually simpler.

## Verification

The exercise is complete when the learner can show all of the following:

- the project builds and runs successfully
- the streamed output is produced with `await foreach`
- a cancellation preview stops early without crashing the app
- the recommendation helper uses `ValueTask<T>` narrowly and the learner can explain why the rest of the code stays on `Task<T>`

## Extension Ideas

- Add a second streamed source and merge the results into one digest.
- Compare a buffered `Task<List<T>>` version with the streamed version in a short note.
- Replace the fixed cancellation budget with user input and explain what changes.

## Micro Exercise

For a 10-minute focused drill, use `exercises/03-productivity-and-data-transformation/05a-cancellation-async-streams-and-valuetask-tradeoffs/micro-exercise.md`.

This micro exercise isolates cancellation-aware streaming over a few small delayed values.

