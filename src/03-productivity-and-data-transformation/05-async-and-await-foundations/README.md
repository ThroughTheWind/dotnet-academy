# Async And Await Foundations Sample

This folder contains the runnable sample for the `05-async-and-await-foundations` topic.

## Project

- `DotnetAcademy.AsyncAwaitFoundationsDemo/` demonstrates `Task<T>`, `await`, and `Task.WhenAll` over a small set of independent asynchronous sources.

## Run The Sample

From the repository root:

```powershell
dotnet run --project ./src/03-productivity-and-data-transformation/05-async-and-await-foundations/DotnetAcademy.AsyncAwaitFoundationsDemo
```

## What To Observe

- the sample starts multiple asynchronous loads first
- it awaits them together rather than blocking on each source one by one
- the final formatting happens after the awaited work completes