# 04 Runtime Tooling And Diagnostics

This stage teaches how .NET programs are built, executed, observed, and optimized.

Stage 4 is in progress today. Topic 01 is ready now, while the remaining runtime, memory, diagnostics, and concurrency topics are still planned.

## Fastest Routes

- Learner start guide: [Start Learning](../../README.md#start-path)
- Curriculum stage map: [Curriculum Index](../README.md#stage-map)
- Review the previous stage: [03 Productivity And Data Transformation](../03-productivity-and-data-transformation/README.md#how-to-use-this-stage)
- Jump to this stage assets: [Topic And Asset Index](#topic-and-asset-index)
- Open the first lesson: [01 Dotnet CLI SDK Build And Packaging Lesson](./01-dotnet-cli-sdk-build-and-packaging/lesson.md)
- Open the first exercises: [01 Dotnet CLI SDK Build And Packaging Exercises](./01-dotnet-cli-sdk-build-and-packaging/exercises.md)
- Open the first demo: [DotnetAcademy.DotnetCliBuildPackagingDemo](../../../src/04-runtime-tooling-and-diagnostics/01-dotnet-cli-sdk-build-and-packaging/DotnetAcademy.DotnetCliBuildPackagingDemo/)
- Continue to the next stage: [05 Data And Persistence](../05-data-and-persistence/README.md)

## Outcomes

- Explain the .NET SDK, build pipeline, package flow, and diagnostics toolchain.
- Understand garbage collection, allocations, memory layout, spans, pooling, and runtime tradeoffs.
- Use logs, metrics, tracing, counters, dumps, profilers, and debugger tooling to investigate behavior.
- Diagnose cancellation, synchronization, backpressure, and channel-based concurrency behavior.

## How To Use This Stage

- Work through the implemented topics in order.
- Use the runnable demos after the lesson and exercises so the command flow, artifacts, and diagnostics notes have concrete examples.
- Treat the remaining planned topics as upcoming content rather than required next steps today.

## Topic Sequence

- 01 .NET CLI, SDK, build, and packaging
- 02 Memory model, GC, and allocation awareness
- 02A Stack versus heap, LOH and POH, pooling, and ref safety
- 03 Spans, buffers, and memory-sensitive APIs
- 04 Logging, tracing, metrics, debugging, and profiling
- 04A `dotnet-counters`, `dotnet-trace`, `dotnet-dump`, and EventPipe workflow
- 05 Concurrency, cancellation, and resilience foundations
- 05A Channels, backpressure, concurrent collections, and producer-consumer pipelines
- 05B Threading primitives, async coordination, and synchronization pitfalls

## Topic And Asset Index

Each Demo link opens a runnable reference implementation under `src/`.

| Topic | Overview | Lesson | Exercises | Demo | Tests |
| --- | --- | --- | --- | --- | --- |
| 01 Dotnet CLI SDK Build And Packaging | [Overview](./01-dotnet-cli-sdk-build-and-packaging/README.md) | [Lesson](./01-dotnet-cli-sdk-build-and-packaging/lesson.md) | [Exercises](./01-dotnet-cli-sdk-build-and-packaging/exercises.md) | [Demo](../../../src/04-runtime-tooling-and-diagnostics/01-dotnet-cli-sdk-build-and-packaging/DotnetAcademy.DotnetCliBuildPackagingDemo/) | [Tests](../../../tests/04-runtime-tooling-and-diagnostics/01-dotnet-cli-sdk-build-and-packaging/DotnetAcademy.DotnetCliBuildPackagingDemo.Tests/) |

## Remaining Planned Topics

- 02 Memory model, GC, and allocation awareness
- 02A Stack versus heap, LOH and POH, pooling, and ref safety
- 03 Spans, buffers, and memory-sensitive APIs
- 04 Logging, tracing, metrics, debugging, and profiling
- 04A `dotnet-counters`, `dotnet-trace`, `dotnet-dump`, and EventPipe workflow
- 05 Concurrency, cancellation, and resilience foundations
- 05A Channels, backpressure, concurrent collections, and producer-consumer pipelines
- 05B Threading primitives, async coordination, and synchronization pitfalls
