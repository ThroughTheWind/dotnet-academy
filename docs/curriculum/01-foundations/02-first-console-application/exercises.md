---
title: 02 First Console Application Exercise
stage: 01-foundations
topic: 02-first-console-application
exercise_type: guided
estimated_minutes: 45
prerequisites:
  - 01 Development Environment And CLI
  - 02 First Console Application
success_criteria:
  - Create a new console app from the command line and run it successfully.
  - Modify `Program.cs` so the application prints a short learner card.
  - Accept an optional first command-line argument and use it in the greeting.
---

# 02 First Console Application Exercise

## Prompt

Create a new console app named `LearnerCardConsole` and turn it into a short learner-introduction program.

Your app must:

1. print a title line
2. print a greeting that defaults to `learner`
3. print one line describing what you are learning
4. print one line describing your current goal
5. replace the default greeting when the app is run with a name argument

Use the starter pack in `exercises/01-foundations/02-first-console-application/` while working.

## Constraints

- Create the project with the CLI instead of an IDE wizard.
- Use top-level statements in `Program.cs`.
- Accept the first command-line argument as an optional name.
- Keep the application simple and text-based.

## Hints

- Start in the `workspace/` folder from the starter pack.
- Use `dotnet new console -n LearnerCardConsole`.
- `args.Length > 0 ? args[0] : "learner"` is a useful pattern for a default name.
- Run the app with a custom name by using `dotnet run -- Ada`.

## Verification

The exercise is complete when the learner can show all of the following:

- the project was created from the CLI
- the application runs successfully with no arguments
- the application runs successfully with a custom name argument
- the output contains a title, a greeting, and two additional descriptive lines

Compare your output to the examples in the starter pack. The wording does not need to match exactly, but the structure and behavior should.

## Extension Ideas

- Accept a second argument for the learning goal.
- Add the current date to the output.
- Create a second version of the app with slightly different wording without looking up the commands again.

