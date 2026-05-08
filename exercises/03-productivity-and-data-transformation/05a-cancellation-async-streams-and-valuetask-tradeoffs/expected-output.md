# Expected Output Example

Your wording can differ, but the structure should look similar to this.

```text
Dotnet Academy: Cancellation, Async Streams, And ValueTask Tradeoffs
-------------------------------------------------------------------
Streamed updates consumed: 4
Pending steps: 8
Cancellation preview: stopped after 2 streamed updates when the time budget expired.
Focus modules:
- Cancellation: 3 pending steps from live planner (cache hit: propagate the token through each awaited boundary that can stop early)
- Async streams: 2 pending steps from mentor digest (cache hit: practice await foreach over IAsyncEnumerable<T> when results arrive gradually)
- Configuration reload: 2 pending steps from settings watcher (cache hit: cancel stale work before starting the next configuration pass)
- ValueTask: 1 pending step from cache profiler (async fallback: profile before replacing Task with ValueTask; keep the API simple until repeated synchronous completion is common)
Cancellation note: pass the same token through producers and consumers so the work can stop cleanly.
Async stream note: use await foreach when values arrive over time instead of buffering everything up front.
ValueTask note: keep Task as the default and reach for ValueTask only when profiling shows lots of synchronous completions, such as cache hits.
```

The important part is that the app treats cancellation, streaming, and `ValueTask<T>` as different tools with different costs.