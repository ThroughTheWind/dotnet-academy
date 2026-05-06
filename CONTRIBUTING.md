# Contributing

Dotnet Academy is being built as a structured teaching repository. Changes should improve the learning path, preserve consistency, and keep examples runnable.

## Rules

- Read `.ai/instructions.md` and `.ai/conventions.md` before adding content.
- Update `ROADMAP.md` if the stage order or scope changes.
- Use the templates in `docs/templates/` for new lessons and exercises.
- Use `./scripts/new-curriculum-topic.ps1` to scaffold a new topic before editing files manually.
- Prefer small, reviewable additions over broad unstructured dumps of content.
- Keep the course targeted at .NET 10 and current platform guidance unless a lesson explicitly teaches legacy migration.

## Before You Commit

1. Run `./scripts/validate-repository.ps1`.
2. Check that new content declares prerequisites, outcomes, and verification steps.
3. Confirm that any new code samples build or are clearly marked as placeholders.
