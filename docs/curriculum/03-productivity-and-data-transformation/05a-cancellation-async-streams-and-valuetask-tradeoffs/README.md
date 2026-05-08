# 05A Cancellation Async Streams And ValueTask Tradeoffs

## Goal

This topic teaches the learner when to stop asynchronous work with `CancellationToken`, when to stream values over time with `IAsyncEnumerable<T>`, and why `ValueTask<T>` is a narrow optimization rather than a default replacement for `Task<T>`.

By the end of the topic, the learner should be able to:

- propagate a cancellation token through asynchronous producers and consumers
- consume streamed results with `await foreach`
- explain when `ValueTask<T>` can help and why `Task<T>` is still the normal starting point

## Deliverables

- `lesson.md` contains the teaching material for cancellation, async streams, and `ValueTask` tradeoffs.
- `exercises.md` contains a guided exercise for building a streamed study activity digest with a cancellation budget.
- Runnable sample project: `src/03-productivity-and-data-transformation/05a-cancellation-async-streams-and-valuetask-tradeoffs/DotnetAcademy.CancellationAsyncStreamsValueTaskDemo/`.
- Learner starter assets: `exercises/03-productivity-and-data-transformation/05a-cancellation-async-streams-and-valuetask-tradeoffs/`.
- Automated tests: `tests/03-productivity-and-data-transformation/05a-cancellation-async-streams-and-valuetask-tradeoffs/DotnetAcademy.CancellationAsyncStreamsValueTaskDemo.Tests/`.

## Status

- Lesson bundle authored
- Runnable sample added
- Starter assets added
- Tests added
