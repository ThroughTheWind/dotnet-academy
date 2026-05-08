# Challenge Brief

Build a console app named `StudyFlowComparisonConsole` that produces the same study digest three ways: synchronous, asynchronous, and streaming.

Your app must:

- start from one common study-work-item shape so the output can be compared fairly
- build one digest after loading data synchronously into memory
- build the same digest after loading data asynchronously with `Task`-based APIs
- build the same digest while consuming a stream with `IAsyncEnumerable<T>`
- show that all three approaches can produce the same final summary while using different control-flow shapes
- print a short note explaining when synchronous code felt simplest, when asynchronous batching made sense, and when streaming gave the clearest model

The key requirement is not only to make all three versions run, but to compare their tradeoffs in plain language.