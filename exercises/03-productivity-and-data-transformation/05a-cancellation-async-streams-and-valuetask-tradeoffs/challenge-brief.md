# Challenge Brief

Build a console app named `StudyActivityStreamConsole` that streams study activity over time and prints a readable digest.

Your app must:

- expose the activity feed as `IAsyncEnumerable<T>`
- consume it with `await foreach`
- stop one preview run early with a `CancellationTokenSource`
- fetch guidance from a small cache API that may return synchronously with `ValueTask<T>`
- explain why `Task<T>` is still the default return type for most asynchronous code

Keep the design small enough that another learner can point to the streamed producer, the cancellation boundary, and the one narrow `ValueTask<T>` helper separately.