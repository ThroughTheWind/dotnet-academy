# 01 Dotnet CLI SDK Build And Packaging

## Goal

This topic teaches the learner how the .NET SDK selects tooling, restores dependencies, builds projects, runs tests, and creates package artifacts.

By the end of the topic, the learner should be able to:

- explain what `global.json` does and why SDK pinning matters
- describe the difference between `restore`, `build`, `test`, and `pack`
- identify the project properties that control package creation
- predict which artifacts a Release build and a pack command produce for a reusable library

## Deliverables

- `lesson.md` contains the teaching material for .NET CLI, SDK, build, and packaging basics.
- `exercises.md` contains a guided exercise for building a small release briefing console app.
- Runnable sample project: `src/04-runtime-tooling-and-diagnostics/01-dotnet-cli-sdk-build-and-packaging/DotnetAcademy.DotnetCliBuildPackagingDemo/`.
- Learner starter assets: `exercises/04-runtime-tooling-and-diagnostics/01-dotnet-cli-sdk-build-and-packaging/`.
- Automated tests: `tests/04-runtime-tooling-and-diagnostics/01-dotnet-cli-sdk-build-and-packaging/DotnetAcademy.DotnetCliBuildPackagingDemo.Tests/`.

## Status

- Lesson bundle authored
- Runnable sample added
- Starter assets added
- Tests added