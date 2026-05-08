# Dotnet Academy

Dotnet Academy is a Markdown-first learning repository for mastering modern C#, .NET, ASP.NET Core, and Blazor from beginner to senior level.

The repository is designed for iterative authoring with AI assistance, but every lesson, example, and exercise must stay runnable, reviewable, and maintainable by humans.

If you are here to learn, do not start with the backlog or contributor workflow documents. Use this route instead:

1. Open the [Learner Start Guide](./docs/README.md#start-path).
2. Use the [Curriculum Stage Map](./docs/curriculum/README.md#stage-map) to pick an implemented stage.
3. Start with [01 Foundations](./docs/curriculum/01-foundations/README.md#how-to-use-this-stage) and use the [Stage 1 Topic And Asset Index](./docs/curriculum/01-foundations/README.md#topic-and-asset-index) to jump directly to lessons, exercises, demos, and tests.
4. Use the [Stage 1 Guided Lab](./labs/01-foundations/06-study-session-planner-lab/README.md) after you finish the five core topics.

If you are editing the repository rather than learning from it, jump to [For Contributors And Maintainers](#for-contributors-and-maintainers).

## Target Stack

- .NET 10 LTS
- C# 14
- ASP.NET Core 10
- Blazor Web App on .NET 10
- Supporting libraries aligned with the latest stable .NET 10 ecosystem

## What This Repository Will Teach

- C# language fundamentals through advanced language design and practical usage
- .NET runtime basics, tooling, diagnostics, performance, and memory behavior
- LINQ, collections, asynchronous programming, and concurrency
- ASP.NET Core web development fundamentals and API architecture
- REST, gRPC, and SignalR application development
- Data access, caching, testing, security, and delivery concerns
- Blazor UI development from fundamentals to production-ready patterns
- Senior-level architecture, optimization, and capstone delivery

## Learner Quick Links

- Start here: [Learner Start Guide](./docs/README.md#start-path)
- Understand the learner workflow: [How To Use This Repository Effectively](./docs/README.md#how-to-use-this-repository-effectively)
- Browse all stages: [Curriculum Stage Map](./docs/curriculum/README.md#stage-map)
- Jump straight to implemented assets: [Stage 1 asset index](./docs/curriculum/01-foundations/README.md#topic-and-asset-index), [Stage 2 asset index](./docs/curriculum/02-csharp-core/README.md#topic-and-asset-index), [Stage 3 asset index](./docs/curriculum/03-productivity-and-data-transformation/README.md#topic-and-asset-index)
- Open the first lesson now: [Stage 1 Topic 01 Lesson](./docs/curriculum/01-foundations/01-development-environment-and-cli/lesson.md)
- Open the first exercises now: [Stage 1 Topic 01 Exercises](./docs/curriculum/01-foundations/01-development-environment-and-cli/exercises.md)
- Open the first runnable demo now: [DotnetAcademy.CliBasicsDemo](./src/01-foundations/01-development-environment-and-cli/DotnetAcademy.CliBasicsDemo/)
- Open the first lab now: [06 Study Session Planner Lab](./labs/01-foundations/06-study-session-planner-lab/README.md)

## Repository Layout

```text
.
|-- .ai/
|   |-- conventions.md
|   `-- instructions.md
|-- .github/
|   `-- workflows/
|-- docs/
|   |-- curriculum/
|   |-- process/
|   `-- templates/
|-- exercises/
|-- labs/
|-- scripts/
|-- tests/
`-- src/
```

## Working Model

- `docs/` contains the learning path, templates, and contributor process docs.
- `src/` contains runnable demos and reference implementations.
- `exercises/` contains learner tasks and starter projects.
- `labs/` contains guided labs and capstone projects.
- `tests/` contains automated tests for runnable demos and later integrated solutions.
- `.ai/` contains instructions for AI-assisted authoring so changes stay consistent.
- `scripts/` and `.github/workflows/` keep the repository validated as it grows.

## Learner Flow

Use the repository in this order when a stage is implemented:

1. Start from [docs/README.md](./docs/README.md#start-path) so you stay on the learner path.
2. Open the stage overview in `docs/curriculum/` and use the stage asset index when you want direct links.
3. For a topic, work in this order: overview, lesson, exercises, then demo.
4. Use tests when you want to confirm how the reference implementation behaves.
5. Complete integrated demos, stage exercise packs, and labs after you finish the core topic sequence for a stage.

Use the assets this way:

- Lessons explain the concepts and the intended mental model.
- Exercises give you practice work and starter material.
- Demos in `src/` show a runnable reference implementation for one topic or one integrated sample, and they are most useful after you attempt the exercise first.
- Labs in `labs/` are learner projects that combine multiple topics and usually separate `starter/` from `solution/` assets.
- Tests verify the reference implementations and integrated solutions, and are optional support material for learners.

## Start Here

### For Learners

1. Install the .NET 10 SDK.
2. Open the [Learner Start Guide](./docs/README.md#start-path).
3. Use the [Curriculum Stage Map](./docs/curriculum/README.md#stage-map) and start with [Stage 1 Foundations](./docs/curriculum/01-foundations/README.md#how-to-use-this-stage) unless you already know the prerequisites.
4. Use the [Stage 1 Topic And Asset Index](./docs/curriculum/01-foundations/README.md#topic-and-asset-index) when you want direct access to lessons, exercises, demos, or tests.
5. Use the [Stage 1 Guided Lab](./labs/01-foundations/06-study-session-planner-lab/README.md) after you finish the topic sequence for that stage.

### For Contributors And Maintainers

1. Read [ROADMAP.md](./ROADMAP.md) for the full program scope.
2. Read [BACKLOG.md](./BACKLOG.md) for implementation order and status tracking.
3. Read [CONTRIBUTING.md](./CONTRIBUTING.md), [.ai/instructions.md](./.ai/instructions.md), and [.ai/conventions.md](./.ai/conventions.md) before authoring content.
4. Use [docs/templates/](./docs/templates/) when creating new lessons or exercises.
5. Use `./scripts/new-curriculum-topic.ps1` when creating a new topic skeleton.
6. Run `./scripts/validate-repository.ps1` before committing structural changes.

## Current Status

The repository foundation is in place. Implemented so far:

1. Git initialization and baseline repository configuration.
2. AI authoring guidance and reusable lesson and exercise templates.
3. Stage-level curriculum folders and overviews.
4. A topic scaffolding script and the first generated topic skeleton.
5. Five complete Stage 1 topics with lesson bundles, runnable demos, learner starter assets, and verification.
6. A Stage 1 console solution with runnable demos and xUnit test projects wired into repository validation.
7. Guided and micro exercises now cover the full Stage 1 topic set.
8. The first integrated Stage 1 guided lab now exists with starter assets, a runnable reference implementation, and automated tests.
9. A curriculum index now links stage overviews to implemented Stage 1 lessons, exercises, demos, tests, and lab assets.
10. A reusable review checklist now defines the baseline acceptance criteria for lessons, exercises, labs, and code samples.
11. Issue and branch naming conventions now map repository work directly back to backlog items.
12. Stage 2 is now complete with six complete topics, the first integrated domain-modeling demo, a dedicated semantics exercise pack, and a guided lab.
13. Stage 3 now includes seven complete topics covering LINQ fundamentals, collection choice, read-only versus immutable versus frozen collection tradeoffs, file-based JSON serialization workflows, configuration basics, async foundations, and advanced async tradeoffs.

The next implementation steps are:

1. Continue Stage 3 with the integrated sample app that transforms and persists data from multiple sources.
2. Add markdown and metadata validation automation.
3. Define sample data and fixtures conventions.

The next useful milestone is to carry Stage 3 from advanced async tradeoffs into the integrated transformation sample before moving on to the comparison exercise packs.

Use [docs/README.md](./docs/README.md) for learner navigation and [BACKLOG.md](./BACKLOG.md) for contributor execution order and stage-level completion tracking.
