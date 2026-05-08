# Contributing

Dotnet Academy is being built as a structured teaching repository. Changes should improve the learning path, preserve consistency, and keep examples runnable.

This document is for contributors and maintainers. Learners should start with [docs/README.md](./docs/README.md) instead of using the contributor workflow.

## Rules

- Read `.ai/instructions.md` and `.ai/conventions.md` before adding content.
- Update `ROADMAP.md` if the stage order or scope changes.
- Use the templates in `docs/templates/` for new lessons and exercises.
- Use `docs/process/issue-and-branch-naming.md` when naming issues and branches for backlog work.
- Use `docs/process/sample-data-and-fixtures.md` when adding seed data, configuration files, or committed test fixtures.
- Use `docs/process/integrated-learning-solution-structure.md` when adding runnable projects so solution membership stays consistent.
- Use `./scripts/new-curriculum-topic.ps1` to scaffold a new topic before editing files manually.
- Prefer small, reviewable additions over broad unstructured dumps of content.
- Keep the course targeted at .NET 10 and current platform guidance unless a lesson explicitly teaches legacy migration.

## Issue And Branch Naming

- Issue titles should use `<BACKLOG-ID>: <short imperative summary>`.
- Branch names should use `<track>/<backlog-id-lowercase>-<short-kebab-summary>`.
- Prefer one branch per backlog item so reviews map cleanly back to `BACKLOG.md`.
- See `docs/process/issue-and-branch-naming.md` for examples and edge-case guidance.

## Before You Commit

1. Run `./scripts/validate-repository.ps1` so Markdown links, curriculum metadata, sample data conventions, required scaffold files, root solution coverage, builds, and tests are checked together.
2. Check the relevant sections in `docs/templates/review-checklist.md` and confirm the asset meets them.
3. Confirm that any new code samples build or are clearly marked as placeholders.
