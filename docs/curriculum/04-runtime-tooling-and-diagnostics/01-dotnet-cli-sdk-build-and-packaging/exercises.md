---
title: 01 Dotnet CLI SDK Build And Packaging Exercise
stage: 04-runtime-tooling-and-diagnostics
topic: 01-dotnet-cli-sdk-build-and-packaging
exercise_type: guided
estimated_minutes: 75
prerequisites:
  - 01 Dotnet CLI SDK Build And Packaging
success_criteria:
  - Show a clear command sequence for restore, build, test, and pack.
  - Explain which project properties make packaging appropriate or inappropriate.
  - Print the expected Release output and package artifact names for a sample library.
---

# 01 Dotnet CLI SDK Build And Packaging Exercise

## Prompt

Create a console app named `ToolingReleaseBriefConsole` that prints a short release briefing for a sample .NET library.

Your app must:

1. describe a pinned SDK version and why it matters
2. show the command order for restore, build, test, and pack
3. explain which project properties make the sample library packable
4. print the expected Release output directory
5. print the expected `.nupkg` artifact name for the sample package

Use the starter pack in `exercises/04-runtime-tooling-and-diagnostics/01-dotnet-cli-sdk-build-and-packaging/` while working.

## Constraints

- Keep the first version as a console app.
- Focus on the tooling workflow rather than dependency injection, hosting, or deployment.
- Keep the metadata model small enough that another learner can trace each printed line back to one project property or one CLI command.
- Distinguish build output from package output clearly.

## Hints

- `global.json` selects an SDK version for the repository.
- `TargetFramework`, `OutputType`, `PackageId`, `Version`, and `IsPackable` are a useful starting set of project properties.
- `dotnet test --no-build` is common when the build already happened in the previous step.
- `dotnet pack` is usually a library-oriented step, not the default action for every executable.

## Verification

The exercise is complete when the learner can show all of the following:

- the project builds and runs successfully
- the printed command sequence is ordered and purposeful
- the output identifies whether the sample project should be packed
- the output distinguishes `bin/<Configuration>/<TargetFramework>/` artifacts from the `.nupkg` artifact

## Extension Ideas

- Add a second profile for a console app and explain why the packaging guidance differs.
- Include one note about when `dotnet publish` becomes more appropriate than `dotnet pack`.
- Add one short explanation of why CI should use the same command flow.

## Micro Exercise

For a 10-minute focused drill, use `exercises/04-runtime-tooling-and-diagnostics/01-dotnet-cli-sdk-build-and-packaging/micro-exercise.md`.

This micro exercise isolates the decision about whether a project should be packed based on a few key properties.