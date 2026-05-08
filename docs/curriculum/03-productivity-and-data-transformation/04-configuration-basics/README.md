# 04 Configuration Basics

## Goal

This topic teaches the learner how .NET configuration composes values from multiple sources and how to bind those values into a small options object for a console application.

By the end of the topic, the learner should be able to:

- explain provider order and why later configuration sources override earlier ones
- load settings from JSON files and later-source overrides without editing the base file
- bind a configuration section into a small options object and validate it
- keep the first configuration example separate from hosting, dependency injection, and ASP.NET-specific concerns

## Deliverables

- `lesson.md` contains the teaching material for configuration basics.
- `exercises.md` contains a guided exercise for loading layered settings into a console app.
- Runnable sample project: `src/03-productivity-and-data-transformation/04-configuration-basics/DotnetAcademy.ConfigurationBasicsDemo/`.
- Learner starter assets: `exercises/03-productivity-and-data-transformation/04-configuration-basics/`.
- Automated tests: `tests/03-productivity-and-data-transformation/04-configuration-basics/DotnetAcademy.ConfigurationBasicsDemo.Tests/`.

## Status

- Lesson bundle authored
- Runnable sample added
- Starter assets added
- Tests added
