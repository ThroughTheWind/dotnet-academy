# Dotnet Academy

Dotnet Academy is a Markdown-first learning repository for mastering modern C#, .NET, ASP.NET Core, and Blazor from beginner to senior level.

The repository is designed for iterative authoring with AI assistance, but every lesson, example, and exercise must stay runnable, reviewable, and maintainable by humans.

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
- `tests/` contains automated tests for runnable samples and later integrated solutions.
- `.ai/` contains instructions for AI-assisted authoring so changes stay consistent.
- `scripts/` and `.github/workflows/` keep the repository validated as it grows.

## Getting Started

1. Install the .NET 10 SDK.
2. Read `ROADMAP.md` for the staged learning path.
3. Read `BACKLOG.md` for the implementation order and tracking model.
4. Read `.ai/instructions.md` and `.ai/conventions.md` before authoring content.
5. Use `docs/templates/` when creating new lessons or exercises.
6. Use `./scripts/new-curriculum-topic.ps1` when creating a new topic skeleton.
7. Run `./scripts/validate-repository.ps1` before committing structural changes.

## Current Status

The repository foundation is in place. Implemented so far:

1. Git initialization and baseline repository configuration.
2. AI authoring guidance and reusable lesson and exercise templates.
3. Stage-level curriculum folders and overviews.
4. A topic scaffolding script and the first generated topic skeleton.
5. Five complete Stage 1 topics with lesson bundles, runnable samples, learner starter assets, and verification.
6. A Stage 1 console solution with runnable demos and xUnit test projects wired into repository validation.
7. Guided and micro exercises now cover the full Stage 1 topic set.
8. The first integrated Stage 1 guided lab now exists with starter assets, a runnable reference implementation, and automated tests.
9. A curriculum index now links stage overviews to implemented Stage 1 lessons, exercises, demos, tests, and lab assets.
10. A reusable review checklist now defines the baseline acceptance criteria for lessons, exercises, labs, and code samples.
11. Issue and branch naming conventions now map repository work directly back to backlog items.
12. Stage 2 is now complete with six complete topics, the first integrated domain-modeling demo, a dedicated semantics exercise pack, and a guided lab.

The next implementation steps are:

1. Start Stage 3 with LINQ fundamentals and query thinking.
2. Add markdown and metadata validation automation.
3. Define sample data and fixtures conventions.

The next useful milestone is to start Stage 3 so the course can move from core language mechanics into day-to-day data transformation and async workflow patterns.

Use `BACKLOG.md` as the source of truth for execution order and stage-level completion tracking.
