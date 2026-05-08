# Curriculum Index

This index links each stage to its overview and, when available, to the underlying lessons, exercises, demos, tests, and labs.

## How To Navigate

- Start with the stage overview to understand the learning outcomes and topic sequence.
- For implemented topics, work in this order: overview, lesson, exercises, then demo.
- Use labs after you complete the core topic sequence for a stage.
- Use the stage asset index when a stage already has authored lessons or code.
- Use `BACKLOG.md` only when you need contributor implementation order rather than learner-facing navigation.

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

Stage 3 is partially implemented today: topics 01, 02, 02A, and 03 are ready now, while configuration and async topics are still planned.

## Current Implemented Assets

- Stage 1 includes five complete topic bundles, five runnable demos, five test projects, and one guided lab.
- Stage 2 now includes six complete topic bundles, the first integrated domain-modeling demo, a dedicated semantics exercise pack, and the first guided lab.
- Stage 3 now includes four complete topic bundles covering LINQ fundamentals, collection choice, read-only versus immutable versus frozen collection tradeoffs, and file-based JSON serialization workflows.
- The first integrated lab is [06 Study Session Planner Lab](../../labs/01-foundations/06-study-session-planner-lab/README.md).
- The stage-level asset maps live in [01 Foundations](./01-foundations/README.md), [02 CSharp Core](./02-csharp-core/README.md), and [03 Productivity And Data Transformation](./03-productivity-and-data-transformation/README.md).

See `ROADMAP.md` for the full program scope and `README.md` for repository-level orientation.
