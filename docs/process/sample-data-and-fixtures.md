# Sample Data And Fixtures Conventions

Use these rules when a sample, lab, or test needs committed input files.

This document is for contributors and maintainers. Learners should stay on the main path in [docs/README.md](../README.md).

## Goals

- Keep committed inputs small, deterministic, and easy to review.
- Make runtime sample data and test-only fixtures easy to find.
- Avoid duplicate copies of the same JSON, CSV, or text payload across projects.

## Location Rules

- Put committed runtime sample input under `seed/` inside the project that reads it.
- Keep project configuration defaults next to the project file as `appsettings.json` and optional `appsettings.<Environment>.json` overrides.
- Put committed test-only inputs under `fixtures/` inside the owning test project.
- Prefer generating temporary files inside tests when inline data or scratch directories keep the test simpler than committed fixtures.

## Naming Rules

- Use lowercase kebab-case for files under `seed/` and `fixtures/`.
- Use lowercase kebab-case for nested directories under `seed/` and `fixtures/` when nesting is needed.
- Keep extensions literal and descriptive, such as `.json`, `.csv`, or `.txt`.

## Usage Guidance

- Copy committed runtime inputs to the build output when the sample reads them through relative paths.
- Prefer one authoritative seeded file in the owning sample project instead of duplicating the same payload inside tests.
- Keep generated output files out of source control under `src/`, `labs/`, and `tests/`; show expected output in Markdown when learners need to inspect it.
- Keep committed fixtures focused on stable input data, not transient machine-specific state.

## Current Repository Examples

- Runtime seed data: [study-sessions.json](../../src/03-productivity-and-data-transformation/03-file-io-json-and-serialization/DotnetAcademy.FileIoJsonSerializationDemo/seed/study-sessions.json)
- Layered project configuration: [appsettings.json](../../src/03-productivity-and-data-transformation/04-configuration-basics/DotnetAcademy.ConfigurationBasicsDemo/appsettings.json) and [appsettings.Development.json](../../src/03-productivity-and-data-transformation/04-configuration-basics/DotnetAcademy.ConfigurationBasicsDemo/appsettings.Development.json)
- Integrated lab seed data: [study-work-items.json](../../labs/03-productivity-and-data-transformation/08-study-digest-pipeline-lab/solution/DotnetAcademy.StudyDigestPipelineLab/seed/study-work-items.json)

## Validation

Repository validation enforces these conventions for committed `.json`, `.csv`, and `.txt` files under `src/`, `labs/`, and `tests/`.