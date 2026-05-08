# Dotnet Academy Conventions

## Naming

- Use zero-padded numeric prefixes for stages and ordered topic folders.
- Use lowercase kebab-case for folder names.
- Use descriptive project names rather than generic names like `SampleApp`.

## Curriculum Folder Pattern

Use this structure for a topic once it becomes real content:

```text
docs/curriculum/<stage>/<topic>/
|-- README.md
|-- lesson.md
|-- exercises.md
`-- checklist.md
```

## Code Folder Pattern

- `src/<stage>/<topic>/` for demos and reference implementations
- `exercises/<stage>/<topic>/` for learner starter code and exercise assets
- `labs/<stage>/<topic>/` for guided labs and capstone milestones

## Sample Data And Fixtures

- Put committed runtime sample input under `seed/` inside the owning project.
- Keep configuration files next to the project file as `appsettings.json` and optional `appsettings.<Environment>.json` overrides.
- Prefer generating test data in temporary directories. When committed test-only assets are necessary, keep them under `fixtures/` in the owning test project.
- Use lowercase kebab-case for files and nested directories under `seed/` and `fixtures/`.
- Do not commit generated output files under `src/`, `labs/`, or `tests/`.

## Lesson Metadata

Lessons should start with YAML frontmatter shaped like this:

```yaml
---
title: Example Lesson
stage: 01-foundations
topic: 01-variables-and-types
level: beginner
estimated_hours: 2
prerequisites:
  - none
learning_outcomes:
  - Explain the difference between value and reference semantics at a beginner-friendly level.
  - Use core types and nullability correctly in simple programs.
---
```

## Exercise Levels

- `micro` for short focused drills
- `guided` for scaffolded coding work
- `independent` for less guided implementation practice
- `capstone` for larger milestone-based delivery

## Solutions Policy

- Prefer progressive hints before full solutions.
- Keep starter and solution code clearly separated.
- Do not hide critical explanation only inside solution code.

## Review Checklist

Use `docs/templates/review-checklist.md` as the reusable completion rubric for lessons, exercises, labs, and code samples.

Minimum expectations:

- The asset declares prerequisites, outcomes, and verification clearly.
- The code or output aligns with current .NET guidance.
- The content fits the roadmap and stage progression.
- The learner can understand why the topic matters, not just how to copy it.
