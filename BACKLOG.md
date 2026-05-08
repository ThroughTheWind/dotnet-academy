# Implementation Backlog

This backlog translates the roadmap into trackable implementation work for the repository.

Use it as the main execution view for building the course end to end. The roadmap explains what the course teaches. This backlog explains what needs to be produced, in what order, and how to tell when a slice is done.

## How To Use This Backlog

- Track work at the epic and slice level, not at the vague topic-idea level.
- Keep statuses current: `todo`, `next`, `in-progress`, `blocked`, `done`.
- Treat each stage as incomplete until docs, code, exercises, labs, and validation all exist where appropriate.
- Prefer vertical slices that end in learner-visible value over broad unfinished drafts across many stages.
- Create topic folders with `./scripts/new-curriculum-topic.ps1` before authoring by hand.

## Program Milestones

| Milestone | Purpose | Exit Criteria | Status |
| --- | --- | --- | --- |
| M0 Foundation | Establish repository structure and authoring workflow | Repo initialized, templates exist, validation exists, first topic can be scaffolded | done |
| M1 First Teaching Slice | Prove the content model with one complete beginner topic | One complete Stage 1 topic with lesson, exercise, runnable sample, and verification | done |
| M2 Core Language Path | Deliver the first end-to-end C# learning path | Stages 1-3 complete with progressive exercises and working demos | todo |
| M3 Platform And Backend Path | Deliver runtime, data, ASP.NET Core, and API tracks | Stages 4-7 complete with at least one integrated sample solution | todo |
| M4 Frontend And Quality Path | Deliver Blazor and testing tracks | Stages 8-9 complete with integrated UI and test coverage | todo |
| M5 Senior Depth Path | Deliver performance and architecture tracks | Stages 10-11 complete with profiling, optimization, and architecture labs | todo |
| M6 Capstone Delivery | Deliver the end-to-end final learning experience | Stage 12 complete with milestone-based capstone and review criteria | todo |

## Cross-Cutting Backlog

| ID | Title | Depends On | Done When | Status |
| --- | --- | --- | --- | --- |
| PLAT-01 | Establish the first runnable .NET solution layout | M0 | The repo has at least one solution, one sample project, one test project, and shared conventions apply cleanly | done |
| PLAT-02 | Expand repository validation beyond scaffold checks | PLAT-01 | Validation script restores, builds, and tests authored projects and fails clearly on missing assets | done |
| PLAT-03 | Add lesson navigation and docs index pages | M0 | Learners can discover stages, topics, and associated code from a consistent index | done |
| PLAT-04 | Define content review rubric and completion checklist | M0 | A reusable review checklist exists for lessons, exercises, labs, and code samples | done |
| PLAT-05 | Define issue and branch naming conventions for content work | M0 | Contributors can map backlog items to implementation branches and issues consistently | done |
| PLAT-06 | Add automation for markdown and metadata validation | PLAT-02 | Frontmatter and required lesson files are validated in CI | todo |
| PLAT-07 | Add sample data, assets, and fixtures conventions | PLAT-01 | Data and fixtures live in predictable locations with naming rules | todo |
| PLAT-08 | Create the integrated learning solution structure | PLAT-01 | Shared solution strategy exists for demos, exercises, and labs across stages | todo |

## Immediate Next Slice

These are the highest-value items to execute next because they unlock the rest of the repository.

- [x] S01-05 Create `05-nullability-and-debugging-basics`.
- [x] S01-06 Add a Stage 1 console solution with runnable demos.
- [x] S01-07 Add micro and guided exercises for every Stage 1 topic.
- [x] S01-08 Add the first Stage 1 guided lab.
- [x] PLAT-03 Create a curriculum index page linking stages to topic folders and code assets.
- [x] PLAT-04 Define a reusable review checklist for lesson and code quality.
- [x] PLAT-05 Define issue and branch naming conventions for content work.
- [x] S02-01 Create object modeling topics: classes, records, structs, enums.
- [x] S02-02 Create abstraction topics: interfaces, inheritance, composition.
- [ ] S02-03 Create reusable code topics: generics, collections, exceptions.
- [ ] PLAT-06 Add automation for markdown and metadata validation.

## Stage Backlog

Each stage below maps directly to the roadmap and defines the implementation work needed before that stage can be marked complete.

### S01 Foundations

Goal: get a new learner from zero to writing small C# programs confidently.

Backlog:

- [x] S01-01 Complete `01-development-environment-and-cli` end to end, including sub-slices `S01-01A` through `S01-01C`.
- [x] S01-02 Create `02-first-console-application`.
- [x] S01-03 Create `03-variables-types-and-conversions`.
- [x] S01-04 Create `04-control-flow-and-methods`.
- [x] S01-05 Create `05-nullability-and-debugging-basics`.
- [x] S01-06 Add a Stage 1 console solution with runnable demos.
- [x] S01-07 Add micro and guided exercises for every Stage 1 topic.
- [x] S01-08 Add the first learner lab that combines multiple Stage 1 topics.

Done when:

- All planned Stage 1 topics have lesson bundles.
- Each topic has code or a deliberate placeholder tracked in the backlog.
- Stage 1 has at least one runnable lab and clear verification steps.

### S02 Core CSharp

Goal: teach the language features needed for maintainable application code.

Backlog:

- [x] S02-01 Create object modeling topics: classes, records, structs, enums.
- [x] S02-02 Create abstraction topics: interfaces, inheritance, composition.
- [ ] S02-03 Create reusable code topics: generics, collections, exceptions.
- [ ] S02-04 Create behavior topics: delegates, events, lambdas, pattern matching.
- [ ] S02-05 Add a demo solution showing domain modeling and clean abstractions.
- [ ] S02-06 Add exercises that force learners to choose between reference and value semantics appropriately.
- [ ] S02-07 Add one guided lab centered on designing a small domain model.

Done when:

- Stage 2 topics progress cleanly from Stage 1 prerequisites.
- Demos and exercises use realistic but still teachable examples.

### S03 Productivity And Data Transformation

Goal: teach day-to-day .NET productivity patterns and data shaping.

Backlog:

- [ ] S03-01 Create LINQ fundamentals and query thinking topics.
- [ ] S03-02 Create collections and immutability tradeoffs topics.
- [ ] S03-02A Create immutable, read-only, and frozen collection tradeoffs topic.
- [ ] S03-03 Create file I/O, JSON, and serialization topics.
- [ ] S03-04 Create configuration basics topic.
- [ ] S03-05 Create async and await foundations topic.
- [ ] S03-05A Create cancellation, async streams, and `ValueTask` tradeoffs topic.
- [ ] S03-06 Add a sample app that transforms and persists data from multiple sources.
- [ ] S03-07 Add exercises that compare imperative and LINQ-based implementations.
- [ ] S03-07A Add exercises that compare synchronous, asynchronous, and streaming data flows.
- [ ] S03-08 Add a lab that combines collections, LINQ, files, and async operations.

Done when:

- Learners can move data through a small application using modern .NET APIs.

### S04 Runtime Tooling And Diagnostics

Goal: teach how .NET actually runs and how to inspect behavior.

Backlog:

- [ ] S04-01 Create .NET CLI, SDK, build, and packaging topics.
- [ ] S04-02 Create memory model, GC, and allocation awareness topics.
- [ ] S04-02A Create stack versus heap, LOH and POH, pooling, and ref-safety topic.
- [ ] S04-03 Create spans, buffers, and memory-sensitive API topics.
- [ ] S04-04 Create logging, tracing, metrics, debugging, and profiling topics.
- [ ] S04-04A Create `dotnet-counters`, `dotnet-trace`, `dotnet-dump`, and EventPipe workflow topic.
- [ ] S04-05 Create concurrency, cancellation, and resilience foundations.
- [ ] S04-05A Create channels, backpressure, concurrent collections, and producer-consumer pipeline topic.
- [ ] S04-05B Create threading primitives, async coordination, and synchronization pitfalls topic.
- [ ] S04-06 Add benchmark and diagnostics sample projects.
- [ ] S04-07 Add exercises that require using tools to observe program behavior.
- [ ] S04-07A Add exercises that diagnose allocations, deadlocks, cancellation bugs, and channel pressure.
- [ ] S04-08 Add a lab focused on investigating and fixing a slow or allocation-heavy application.

Done when:

- Diagnostics lessons are evidence-driven and backed by runnable samples or traces.

### S05 Data And Persistence

Goal: teach application data design, storage, and access patterns.

Backlog:

- [ ] S05-01 Create SQL fundamentals for application developers topic.
- [ ] S05-02 Create EF Core basics topic.
- [ ] S05-03 Create migrations, query performance, and transaction topics.
- [ ] S05-03A Create query-shape analysis, N+1 detection, and compiled query tradeoffs topic.
- [ ] S05-04 Create caching strategies and invalidation tradeoffs topic.
- [ ] S05-05 Add a sample data access solution using EF Core and a relational store.
- [ ] S05-06 Add exercises for modeling, querying, and performance troubleshooting.
- [ ] S05-06A Add exercises for transaction boundaries, query plans, and cache invalidation failures.
- [ ] S05-07 Add a lab that evolves a small app from simple persistence to optimized queries and caching.

Done when:

- Learners can reason about correctness and performance together in data access code.

### S06 AspNetCore Foundations

Goal: teach the web host, request pipeline, and platform defaults behind ASP.NET Core.

Backlog:

- [ ] S06-01 Create hosting and startup topic.
- [ ] S06-02 Create middleware and routing topic.
- [ ] S06-03 Create dependency injection and configuration topic.
- [ ] S06-04 Create options, logging, validation, and error handling topics.
- [ ] S06-05 Create secure defaults and environment-aware behavior topic.
- [ ] S06-05A Create host lifecycle, background services, and graceful shutdown topic.
- [ ] S06-06 Add a sample web host project showing the request pipeline clearly.
- [ ] S06-07 Add exercises around middleware ordering and service registration.
- [ ] S06-07A Add exercises around service lifetimes, cancellation flow, and startup diagnostics.
- [ ] S06-08 Add a lab that hardens a simple ASP.NET Core application.

Done when:

- Learners can explain how a request flows through an ASP.NET Core app and can change that flow safely.

### S07 Api Development

Goal: teach production-grade service development with modern .NET APIs.

Backlog:

- [ ] S07-01 Create REST design and HTTP semantics topic.
- [ ] S07-02 Create minimal APIs and controllers comparison topic.
- [ ] S07-03 Create authentication and authorization topics.
- [ ] S07-04 Create OpenAPI, pagination, filtering, and versioning topics.
- [ ] S07-04A Create contract evolution, compatibility testing, and API review topic.
- [ ] S07-05 Create gRPC topic.
- [ ] S07-06 Create SignalR topic.
- [ ] S07-07 Add an integrated API solution with REST, gRPC, and real-time examples where appropriate.
- [ ] S07-08 Add tests, exercises, and a lab around evolving an API from basic CRUD to production-ready behavior.
- [ ] S07-08A Add exercises around concurrency limits, backpressure, retries, and idempotency.

Done when:

- Stage 7 contains at least one integrated service sample with tests and contract documentation.

### S08 Blazor

Goal: teach modern Blazor application development on the current stack.

Backlog:

- [ ] S08-01 Create components and rendering model topic.
- [ ] S08-01A Create render modes, lifecycle timing, diffing, and render-control topic.
- [ ] S08-02 Create parameters, events, forms, and validation topics.
- [ ] S08-03 Create state management and data loading topics.
- [ ] S08-03A Create virtualization, streaming rendering, circuit lifetime, and disposal topic.
- [ ] S08-04 Create security and API integration topics.
- [ ] S08-05 Create production-ready Blazor structure topic.
- [ ] S08-05A Create Blazor performance, JS interop boundaries, and memory leak prevention topic.
- [ ] S08-06 Add a Blazor Web App sample connected to prior API work.
- [ ] S08-07 Add exercises around forms, rendering, and state flow.
- [ ] S08-07A Add exercises that diagnose over-rendering, stale state, and component cleanup bugs.
- [ ] S08-08 Add a lab that builds a usable feature end to end in Blazor.

Done when:

- Learners can build and reason about a Blazor front end that integrates with the Stage 7 backend work.

### S09 Testing And Quality

Goal: teach verification strategy instead of just test syntax.

Backlog:

- [ ] S09-01 Create xUnit fundamentals topic.
- [ ] S09-01A Create theories, property-based tests, and data-driven test design topic.
- [ ] S09-02 Create integration testing topic for ASP.NET Core.
- [ ] S09-02A Create EF Core, container-backed database, and environment-aware integration testing topic.
- [ ] S09-03 Create fixtures, test data, and maintainable suite patterns topic.
- [ ] S09-03A Create mocks, fakes, async testing, and concurrency testing topic.
- [ ] S09-03B Create Blazor component and UI testing topic.
- [ ] S09-04 Create analyzer and quality gate topic.
- [ ] S09-04A Create API contract verification and snapshot testing topic.
- [ ] S09-05 Add tests to representative Stage 1, 7, and 8 projects.
- [ ] S09-05A Add representative data, API, and UI test suites that demonstrate layered strategies.
- [ ] S09-06 Add exercises that ask learners to improve weak test suites.
- [ ] S09-06A Add exercises that expose race conditions, flaky tests, and hidden integration dependencies.
- [ ] S09-07 Add a lab focused on test strategy for a small feature set.

Done when:

- Testing content covers code, APIs, and application behavior rather than isolated units only.

### S10 Performance And Memory

Goal: teach measurement-driven optimization and memory-aware engineering.

Backlog:

- [ ] S10-01 Create benchmarking and measurement topic.
- [ ] S10-02 Create allocation analysis and hot path topic.
- [ ] S10-02A Create memory layout, pooling, cache locality, and object lifetime topic.
- [ ] S10-02B Create SIMD, vectorization, and hardware intrinsics topic.
- [ ] S10-03 Create async throughput and backpressure topic.
- [ ] S10-03A Create bounded concurrency, channels, and pipeline tuning topic.
- [ ] S10-04 Create API, database, and caching performance topic.
- [ ] S10-04A Create JIT, tiered compilation, PGO, trimming, ReadyToRun, and Native AOT tradeoffs topic.
- [ ] S10-05 Add benchmark projects and trace captures tied to earlier stages.
- [ ] S10-06 Add exercises where learners must diagnose before optimizing.
- [ ] S10-06A Add exercises that compare scalar versus vectorized code and validate gains with benchmarks.
- [ ] S10-07 Add a lab centered on improving throughput or latency with proof.

Done when:

- Optimization lessons include baseline measurements, changes, and verified outcomes.

### S11 Architecture And Delivery

Goal: teach system structure, tradeoffs, and operational thinking.

Backlog:

- [ ] S11-01 Create layered architecture, vertical slices, and modular monolith topics.
- [ ] S11-02 Create SOLID in practice and tradeoffs topic.
- [ ] S11-03 Create domain boundaries, messaging, and background processing topics.
- [ ] S11-03A Create hosted services, worker services, and channel-backed background queue topic.
- [ ] S11-03B Create retries, idempotency, outbox, and delivery reliability topic.
- [ ] S11-04 Create deployment, configuration, and observability topics.
- [ ] S11-04A Create OpenTelemetry, health checks, and operational diagnostics topic.
- [ ] S11-04B Create publish models, containers, trimming, and Native AOT delivery tradeoffs topic.
- [ ] S11-05 Add a reference architecture sample or decision record set tied to earlier solutions.
- [ ] S11-06 Add exercises that force tradeoff decisions instead of one right answer.
- [ ] S11-06A Add exercises that connect architecture choices to tracing, scaling limits, and runtime constraints.
- [ ] S11-07 Add a lab that evolves an existing application architecture under new requirements.

Done when:

- Senior-level guidance connects architectural choices to testing, performance, deployment, and operations.

### S12 Capstone

Goal: deliver the final integrated learning experience.

Backlog:

- [ ] S12-01 Define the capstone problem statement and milestones.
- [ ] S12-02 Define architecture, quality gates, and review rubric.
- [ ] S12-03 Build the backend milestones using prior API and data patterns.
- [ ] S12-04 Build the frontend milestones using prior Blazor patterns.
- [ ] S12-05 Add caching, background work, observability, and security milestones.
- [ ] S12-06 Add testing, performance review, and hardening milestones.
- [ ] S12-07 Publish the capstone learner guide, facilitator guide, and verification checklist.

Done when:

- The capstone feels like a real project, not a disconnected exercise set.

## End-To-End Completion Rules

Do not mark a major backlog slice done unless the related work includes all relevant repository surfaces:

- `docs/curriculum/` contains the learner-facing lesson bundle.
- `src/` contains runnable examples or reference implementations.
- `exercises/` contains learner tasks or starter assets.
- `labs/` contains a lab when the stage calls for one.
- `scripts/` and CI still validate the repository cleanly.

## Backlog Maintenance Rules

- When a new topic is added to the roadmap, add it here in the matching stage before authoring begins.
- When work starts, change the status here or split the item into smaller slices if it is too large.
- When a stage item is blocked, record the dependency explicitly rather than leaving it stale.
- When a stage completes, update both this backlog and `README.md` current status if the repo milestone changed.
