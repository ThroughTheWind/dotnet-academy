---
title: 05A Cancellation Async Streams And ValueTask Tradeoffs
stage: 03-productivity-and-data-transformation
topic: 05a-cancellation-async-streams-and-valuetask-tradeoffs
level: intermediate
estimated_hours: 2
prerequisites:
  - 05 Async And Await Foundations
learning_outcomes:
  - Propagate `CancellationToken` through asynchronous boundaries that can stop early.
  - Consume streamed data with `await foreach` over `IAsyncEnumerable<T>`.
  - Explain why `ValueTask<T>` is useful only for narrow high-frequency cases.
---

# 05A Cancellation Async Streams And ValueTask Tradeoffs

## Why This Matters

Once basic `async` and `await` code works, the next problems are not about adding more `Task` objects. They are about controlling work that should stop, processing values as they arrive, and avoiding premature micro-optimizations.

Real .NET code often needs all three:

- a web request or UI action should be cancelable when the caller no longer cares
- data from files, sockets, services, or background processes may arrive gradually rather than all at once
- some hot-path APIs may complete synchronously so often that returning `ValueTask<T>` can reduce allocation pressure

These are useful tools, but each one adds constraints. The goal of this slice is to teach the tradeoffs instead of presenting them as automatic upgrades.

## Concepts

### 1. Cancellation Is Cooperative, Not Magical

`CancellationToken` does not kill work by force. It gives your code a shared signal that says the caller wants to stop.

That means both sides matter:

- the caller creates or forwards the token
- the asynchronous work passes that token into operations that support cancellation

```csharp
public async Task RefreshAsync(CancellationToken cancellationToken)
{
    await Task.Delay(50, cancellationToken);
}
```

If the token never reaches the awaited work, cancellation becomes a no-op in practice.

### 2. `IAsyncEnumerable<T>` Models Results That Arrive Over Time

Sometimes waiting for one big `List<T>` is the wrong shape. If results are naturally produced one item at a time, `IAsyncEnumerable<T>` lets the consumer handle them progressively.

```csharp
await foreach (var update in stream.ReadAllAsync(cancellationToken))
{
    Console.WriteLine(update.ModuleName);
}
```

That pattern is helpful when you want early processing, incremental progress, or lower buffering overhead.

### 3. `await foreach` Still Needs A Cancellation Story

Streaming code should not ignore stop requests.

In producers, use `[EnumeratorCancellation]` on the token parameter and pass that token into awaited operations.

In consumers, keep the same token flowing through the enumeration so the producer and consumer agree about when to stop.

### 4. `ValueTask<T>` Is A Specific Optimization

Use `Task<T>` by default.

`ValueTask<T>` becomes interesting only when all of the following are true:

- the method is called frequently enough for allocations to matter
- many calls complete synchronously
- profiling shows the extra complexity is justified

Examples include cache hits or pooled resources that often have an answer immediately.

### 5. `ValueTask<T>` Has More Rules Than `Task<T>`

Unlike `Task<T>`, a `ValueTask<T>` should not casually be stored, awaited multiple times, or treated like a drop-in replacement everywhere.

That is why most application code should stay on `Task` unless there is a measured reason to do otherwise.

### 6. Combine The Three Concepts Carefully

One reasonable composition looks like this:

- stream updates from an `IAsyncEnumerable<T>` source
- stop early with a shared cancellation token when the caller runs out of time
- fetch optional cached metadata with a `ValueTask<T>` API that often completes synchronously

That is the shape used in the runnable sample for this topic.

## Demo

The runnable sample for this topic lives at:

`src/03-productivity-and-data-transformation/05a-cancellation-async-streams-and-valuetask-tradeoffs/DotnetAcademy.CancellationAsyncStreamsValueTaskDemo/`

Run it from the repository root:

```powershell
dotnet run --project ./src/03-productivity-and-data-transformation/05a-cancellation-async-streams-and-valuetask-tradeoffs/DotnetAcademy.CancellationAsyncStreamsValueTaskDemo
```

Expected result:

- the sample streams study updates with `await foreach`
- it shows a cancellation preview that stops partway through a second stream
- it uses a cache-backed `ValueTask<T>` API so cache hits complete synchronously and misses fall back to asynchronous work
- the output explains why `Task<T>` remains the default choice

## Common Mistakes

- Creating a `CancellationTokenSource` but never passing the token into awaited operations.
- Returning `Task<List<T>>` when the data is naturally produced one item at a time.
- Forgetting that streamed consumers also need cancellation awareness.
- Replacing `Task<T>` with `ValueTask<T>` everywhere without profiling.
- Awaiting or storing `ValueTask<T>` the same way as `Task<T>` without understanding the extra constraints.

## Exercises

Use `exercises.md` for the guided exercise.

The starter pack for this topic lives under:

`exercises/03-productivity-and-data-transformation/05a-cancellation-async-streams-and-valuetask-tradeoffs/`

It includes a workspace folder, a challenge brief, expected output examples, and a short micro drill focused on cancellation-aware async streams.

## Verification

This topic is successful when the learner can do all of the following:

- pass a cancellation token from the caller into asynchronous producers and consumers
- use `await foreach` over an `IAsyncEnumerable<T>` source
- explain why the stream can stop early without pretending the work completed successfully
- identify a narrow case where `ValueTask<T>` makes sense and explain why `Task<T>` is still the default elsewhere

