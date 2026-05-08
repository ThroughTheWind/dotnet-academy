---
title: Cancellation Aware Async Stream Drill
stage: 03-productivity-and-data-transformation
topic: 05a-cancellation-async-streams-and-valuetask-tradeoffs
exercise_type: micro
estimated_minutes: 10
prerequisites:
  - 05A Cancellation Async Streams And ValueTask Tradeoffs
success_criteria:
  - Yield delayed values from an `IAsyncEnumerable<int>`.
  - Stop the enumeration early with a cancellation token.
---

# Cancellation Aware Async Stream Drill

## Prompt

Create an async stream that yields five integers with a short delay before each value.

Then:

1. consume it with `await foreach`
2. cancel the enumeration before all values arrive
3. print how many values were processed before the stop request
4. explain why the token has to reach the producer as well as the consumer

## Constraints

- Use `IAsyncEnumerable<int>`.
- Pass the cancellation token into the delayed work.
- Keep the drill focused on streaming and cancellation, not `ValueTask<T>`.

## Hints

- `[EnumeratorCancellation]` is useful on the token parameter for async iterators.
- `Task.Delay(..., cancellationToken)` makes the stop request observable during waiting.
- The stream should stop because cancellation was requested, not because of a fake success path.

## Verification

The drill is complete when the enumeration stops early and the learner can explain how the producer noticed the cancellation request.

## Extension Ideas

- Change the delay and cancellation budget to see how many values finish.
- Add one log line inside the producer and one inside the consumer to visualize the flow.