# Integrated Learning Solution Structure

Use this document when you add or reorganize runnable projects in Dotnet Academy.

This document is for contributors and maintainers. Learners should stay on the main path in [docs/README.md](../README.md).

## Goals

- Keep one authoritative solution entry point for repository-wide restore, build, test, and CI validation.
- Make demos, integrated samples, and lab reference implementations discoverable in the same structure across stages.
- Keep learner-facing exercise assets separate from maintainer-owned runnable reference projects.

## Authoritative Solution

- `dotnet-academy.sln` at the repository root is the shared integration solution.
- CI and local repository validation run against that root solution.
- Every runnable reference project under `src/`, every runnable reference project under `labs/**/solution/`, and every automated test project under `tests/` must be added to `dotnet-academy.sln`.

## Placement Rules

- Topic demos live under `src/<stage>/<topic>/` and their projects belong in `dotnet-academy.sln`.
- Integrated demos may contain multiple collaborating projects under one topic folder in `src/`; add each of those projects to `dotnet-academy.sln`.
- Lab reference implementations live under `labs/<stage>/<topic>/solution/`; add each runnable project there to `dotnet-academy.sln`.
- Automated verification projects live under `tests/<stage>/<topic>/`; add each test project to `dotnet-academy.sln`.

## Exercise Guidance

- `exercises/` is learner-first by default and usually contains Markdown, starter assets, and optional `workspace/` guidance only.
- Do not add exercise-only content to `dotnet-academy.sln` when it has no runnable project.
- If a future exercise needs a runnable maintainer-owned reference implementation or automated tests, keep the learner-facing exercise materials in `exercises/` and place the runnable reference or verification project in the normal `src/`, `labs/`, or `tests/` structure.

## Folder Mirroring Inside The Solution

- Keep the solution folders aligned to the repository layout: top-level `src`, `labs`, and `tests`, then stage folders, then topic folders.
- When a lab has a `solution/` subtree, keep that `solution` segment visible in the solution folder hierarchy.
- Prefer mirroring the on-disk structure instead of inventing alternate grouping names.

## Contributor Workflow

1. Create or update the project in its stage/topic folder.
2. Add the project to `dotnet-academy.sln`.
3. Keep the matching test project under `tests/` and add it to `dotnet-academy.sln` when it exists.
4. Run `./scripts/validate-repository.ps1` to confirm the root solution still covers every runnable project.

## Validation

Repository validation enforces that every committed `.csproj` under `src/`, `labs/`, and `tests/` is present in `dotnet-academy.sln`.