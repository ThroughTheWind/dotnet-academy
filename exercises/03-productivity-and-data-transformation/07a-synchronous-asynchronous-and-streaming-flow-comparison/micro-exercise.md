---
title: Buffered Versus Streamed Digest Drill
stage: 03-productivity-and-data-transformation
topic: 07a-synchronous-asynchronous-and-streaming-flow-comparison
exercise_type: micro
estimated_minutes: 10
prerequisites:
  - 05 Async And Await Foundations
  - 05A Cancellation Async Streams And ValueTask Tradeoffs
success_criteria:
  - Build one digest after buffering all items first.
  - Build the same digest while consuming items from an async stream.
---

# Buffered Versus Streamed Digest Drill

## Prompt

Create a tiny set of study work items that can be exposed both as a preloaded list and as an async stream.

Then:

1. build a simple digest after buffering all items in memory first
2. build the same digest while consuming the async stream with `await foreach`
3. print both results so the matching output is obvious
4. explain in one sentence what extra control-flow concern the streamed version introduces

## Constraints

- Keep the drill to one small in-memory data set.
- Do not add cancellation in this drill.
- Use `await foreach` in the streamed version.

## Hints

- The buffered version can use a plain list and a normal loop or LINQ query.
- The streamed version still needs to decide when enough items have arrived to print the digest.
- The point is to compare flow shape, not to benchmark performance.

## Verification

The drill is complete when both outputs contain the same digest values and the learner can explain what changed in the control flow.

## Extension Ideas

- Add a delayed item and note when the streamed version can react earlier.
- Add a second asynchronous batch source and compare it to the stream.