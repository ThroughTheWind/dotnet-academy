---
title: 01 Development Environment And CLI Exercise
stage: 01-foundations
topic: 01-development-environment-and-cli
exercise_type: guided
estimated_minutes: 35
prerequisites:
  - 01 Development Environment And CLI
success_criteria:
  - Verify that a .NET 10 SDK is installed and available on the command line.
  - Create, build, and run a new console application using the CLI only.
  - Identify the purpose of the generated project file, `Program.cs`, `bin/`, and `obj/`.
---

# 01 Development Environment And CLI Exercise

## Prompt

Complete the following steps from a terminal without using IDE project creation wizards:

1. Run `dotnet --version` and `dotnet --list-sdks`.
2. Confirm that at least one installed SDK is a `10.x` version.
3. Create a new console application named `HelloDotnetAcademy`.
4. Build and run the application from the terminal.
5. Open the generated folder and inspect `Program.cs` and the `.csproj` file.
6. Write short answers to these questions:

- What is the practical difference between the SDK and the runtime?
- What file controls how the project is built?
- What are `bin/` and `obj/` used for?
- Which command would you use to discover available project templates?

## Constraints

- Use the CLI for all creation, build, and run steps.
- Do not use copy-pasted screenshots as proof; use the command output and the generated files.
- Keep the generated project close to its default state so the focus stays on the toolchain.

## Hints

- If `dotnet` is not recognized, restart the terminal and verify the SDK installation.
- Use `dotnet new console -n HelloDotnetAcademy` to create the project.
- Use `dotnet run` from inside the project directory to build and run in one step.
- Use `dotnet new list` or `dotnet --help` when you are unsure about command syntax.

## Verification

The exercise is complete when the learner can show all of the following:

- command output proving a .NET 10 SDK is installed
- a successfully created `HelloDotnetAcademy` project
- successful execution of `dotnet build` or `dotnet run`
- correct short explanations for the four reflection questions

Expected observable result:

- the project builds without errors
- the application runs and prints the default greeting message

## Extension Ideas

- Run `dotnet new list` and identify three templates you expect to use later in the course.
- Create a second console app in a different folder without looking up the command again.
- Inspect the `.csproj` file and identify the SDK being used by the project.

## Micro Exercise

For a 10-minute focused drill, use `exercises/01-foundations/01-development-environment-and-cli/micro-exercise.md`.

This micro exercise isolates the three smallest habits from the topic: verifying the SDK, discovering templates, and identifying the project file that controls a basic console app.

