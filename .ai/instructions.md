# Dotnet Academy AI Instructions

This repository is a course platform for teaching modern C#, .NET, ASP.NET Core, and Blazor from beginner to senior level.

## Primary Goals

- Keep the repository structured, consistent, and easy to extend.
- Prefer current .NET 10 and C# 14 guidance.
- Produce learner-facing material in English.
- Pair lesson content with runnable demos, exercises, or labs whenever the topic is technical enough to benefit from hands-on work.

## Repository Ownership Model

- `README.md` explains the repository mission and navigation.
- `ROADMAP.md` defines the high-level staged learning path.
- `docs/curriculum/` contains stage and lesson documentation.
- `docs/templates/` contains reusable lesson and exercise templates.
- `src/` contains runnable demos, reference code, and supporting utilities.
- `exercises/` contains learner tasks and starter code.
- `labs/` contains guided projects and capstones.
- `scripts/` contains validation and maintenance automation.

## Authoring Rules

- Use Markdown-first authoring for lessons and learning paths.
- Keep lessons explicit about prerequisites, outcomes, and expected effort.
- Favor current platform defaults over outdated or legacy patterns.
- Prefer `./scripts/new-curriculum-topic.ps1` when creating a new topic skeleton.
- Do not introduce broad structural changes without updating `README.md`, `ROADMAP.md`, and relevant templates.
- Do not add a topic to the curriculum without placing it in the stage model.
- Avoid shallow checklist-only content. Each lesson should explain why the topic matters, how it works, and how learners should practice it.

## Technical Defaults For Future Projects

- Target .NET 10 unless a lesson intentionally demonstrates migration or compatibility.
- Use nullable reference types.
- Use implicit usings where it improves clarity.
- Treat warnings as errors for authored code unless there is a teaching reason not to.
- Prefer xUnit for testing unless there is a strong reason to use another test framework.
- Prefer ASP.NET Core patterns that reflect current guidance.
- Prefer Blazor Web App as the default Blazor teaching model unless a module explicitly focuses on a different hosting mode.

## Lesson Bundle Standard

Each module should eventually follow a consistent package shape:

```text
docs/curriculum/<stage>/<topic>/
|-- README.md
|-- lesson.md
|-- exercises.md
`-- checklist.md
```

Associated runnable materials should be placed under `src/`, `exercises/`, or `labs/` using the same stage and topic naming.

## Quality Bar

- Content should be accurate, current, and progressive.
- Code should be small enough to teach clearly, but realistic enough to matter.
- Performance topics should be evidence-driven and measured, not opinion-driven.
- Advanced topics should connect back to earlier lessons rather than appearing as isolated theory.

