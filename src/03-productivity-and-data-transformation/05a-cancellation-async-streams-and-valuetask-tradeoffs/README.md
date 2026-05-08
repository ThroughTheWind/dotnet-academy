# Cancellation Async Streams ValueTask Sample

This folder contains the runnable sample for the `05a-cancellation-async-streams-and-valuetask-tradeoffs` topic.

## Project

- `DotnetAcademy.CancellationAsyncStreamsValueTaskDemo/` demonstrates cooperative cancellation, `await foreach` over `IAsyncEnumerable<T>`, and a cache-oriented `ValueTask<T>` helper.

## Run The Sample

From the repository root:

```powershell
dotnet run --project ./src/03-productivity-and-data-transformation/05a-cancellation-async-streams-and-valuetask-tradeoffs/DotnetAcademy.CancellationAsyncStreamsValueTaskDemo
```

## What To Observe

- the sample consumes streamed updates as they arrive instead of buffering them first
- it uses a cancellation budget to stop a preview stream partway through
- cache hits complete synchronously through a `ValueTask<T>` API, while misses fall back to asynchronous work
- the output explains why `Task<T>` is still the default outside narrow hot-path cases