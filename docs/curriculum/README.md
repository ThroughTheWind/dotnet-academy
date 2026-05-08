# Curriculum Index

This index links each stage to its overview and, when available, to the underlying lessons, exercises, demos, tests, and labs.

## Fastest Routes

- Start the course: [01 Foundations](./01-foundations/README.md#how-to-use-this-stage)
- Jump directly to Stage 1 assets: [Stage 1 Topic And Asset Index](./01-foundations/README.md#topic-and-asset-index)
- Jump directly to Stage 2 assets: [Stage 2 Topic And Asset Index](./02-csharp-core/README.md#topic-and-asset-index)
- Jump directly to Stage 3 assets: [Stage 3 Topic And Asset Index](./03-productivity-and-data-transformation/README.md#topic-and-asset-index)
- Open the first lesson: [01 Development Environment And CLI Lesson](./01-foundations/01-development-environment-and-cli/lesson.md)
- Open the first exercises: [01 Development Environment And CLI Exercises](./01-foundations/01-development-environment-and-cli/exercises.md)
- Open the first demo: [DotnetAcademy.CliBasicsDemo](../../src/01-foundations/01-development-environment-and-cli/DotnetAcademy.CliBasicsDemo/)
- Open the first lab: [06 Study Session Planner Lab](../../labs/01-foundations/06-study-session-planner-lab/README.md)

## How To Navigate

- Start with the stage overview to understand the learning outcomes and topic sequence.
- If you want direct access to lessons, exercises, demos, or tests, use the stage's `Topic And Asset Index` or the `Asset Index` link in the table below.
- For implemented topics, work in this order: overview, lesson, exercises, then demo.
- Use labs after you complete the core topic sequence for a stage.
- Use the stage asset index when a stage already has authored lessons or code.
- Use `BACKLOG.md` only when you need contributor implementation order rather than learner-facing navigation.

## Status Guide

- `implemented` means the stage overview and linked topic assets are ready for learners now.
- `in progress` means some topics are ready now, but the stage is not fully authored yet.
- `planned` means you should expect the stage overview only, not a complete asset map.

## Asset Types

- Lessons explain the concepts and the intended reasoning behind the stage.
- Exercises are learner practice tasks and may include starter or workspace materials.
- Demos are runnable reference implementations under `src/`.
- Labs are multi-topic learner projects under `labs/` and usually separate `starter/` from `solution/` assets.
- Tests verify the runnable reference implementations and integrated solutions.

## Stage Map

| Stage | Focus | Status | Overview | Asset Index |
| --- | --- | --- | --- | --- |
| 01 Foundations | CLI basics, console apps, types, control flow, nullability | implemented | [01 Foundations](./01-foundations/README.md) | [Stage 1 asset index](./01-foundations/README.md#topic-and-asset-index) |
| 02 CSharp Core | object modeling, abstractions, generics, behavior | implemented | [02 CSharp Core](./02-csharp-core/README.md) | [Stage 2 asset index](./02-csharp-core/README.md#topic-and-asset-index) |
| 03 Productivity And Data Transformation | LINQ, collections, files, config, async, streaming | in progress | [03 Productivity And Data Transformation](./03-productivity-and-data-transformation/README.md) | [Stage 3 asset index](./03-productivity-and-data-transformation/README.md#topic-and-asset-index) |
| 04 Runtime Tooling And Diagnostics | CLI internals, GC, diagnostics, memory, channels | planned | [04 Runtime Tooling And Diagnostics](./04-runtime-tooling-and-diagnostics/README.md) | overview only |
| 05 Data And Persistence | SQL, EF Core, performance, caching | planned | [05 Data And Persistence](./05-data-and-persistence/README.md) | overview only |
| 06 AspNetCore Foundations | hosting, middleware, DI, config, lifecycle, errors | planned | [06 AspNetCore Foundations](./06-aspnetcore-foundations/README.md) | overview only |
| 07 Api Development | REST, minimal APIs, auth, contracts, gRPC, SignalR | planned | [07 Api Development](./07-api-development/README.md) | overview only |
| 08 Blazor | components, render modes, state, perf, security, integration | planned | [08 Blazor](./08-blazor/README.md) | overview only |
| 09 Testing And Quality | xUnit, integration, async and UI tests, quality gates | planned | [09 Testing And Quality](./09-testing-and-quality/README.md) | overview only |
| 10 Performance And Memory | profiling, allocations, vectorization, throughput, AOT | planned | [10 Performance And Memory](./10-performance-and-memory/README.md) | overview only |
| 11 Architecture And Delivery | architecture, messaging, background work, observability, delivery | planned | [11 Architecture And Delivery](./11-architecture-and-delivery/README.md) | overview only |
| 12 Capstone | end-to-end production-style delivery | planned | [12 Capstone](./12-capstone/README.md) | overview only |

Stage 3 is partially implemented today: topics 01, 02, 02A, 03, 04, 05, and 05A are ready now, while the integrated multi-topic assets are still planned.

## Current Implemented Assets

- Stage 1 includes five complete topic bundles, five runnable demos, five test projects, and one guided lab.
- Stage 2 now includes six complete topic bundles, the first integrated domain-modeling demo, a dedicated semantics exercise pack, and the first guided lab.
- Stage 3 now includes seven complete topic bundles covering LINQ fundamentals, collections, configuration layering, async foundations, and advanced async tradeoffs.
- The first integrated lab is [06 Study Session Planner Lab](../../labs/01-foundations/06-study-session-planner-lab/README.md).
- The stage-level asset maps live in [01 Foundations](./01-foundations/README.md#topic-and-asset-index), [02 CSharp Core](./02-csharp-core/README.md#topic-and-asset-index), and [03 Productivity And Data Transformation](./03-productivity-and-data-transformation/README.md#topic-and-asset-index).

See `ROADMAP.md` for the full program scope and `README.md` for repository-level orientation.
