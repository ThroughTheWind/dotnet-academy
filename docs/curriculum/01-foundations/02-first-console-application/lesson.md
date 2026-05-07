---
title: 02 First Console Application
stage: 01-foundations
topic: 02-first-console-application
level: beginner
estimated_hours: 2
prerequisites:
  - 01 Development Environment And CLI
learning_outcomes:
  - Create and run a console application with the .NET CLI.
  - Explain how `Program.cs` and top-level statements work in a beginner-friendly console app.
  - Modify console output and rerun the application to verify the change.
  - Pass a simple command-line argument with `dotnet run -- <value>` and use it in the program.
---

# 02 First Console Application

## Why This Matters

Console applications are the simplest place to learn what a .NET program actually does when it starts.

They matter because they let a learner focus on the fundamentals without the extra moving parts of a web app or UI framework.

This topic also introduces habits that carry forward into later stages:

1. create a project from the CLI
2. inspect and modify source code intentionally
3. rerun the program to verify behavior
4. pass input into the program from the command line

## Concepts

### 1. What A Console Application Is

A console application is a program that runs in a terminal window and communicates with the user through text.

That makes it ideal for early learning because:

- the project shape is small
- the runtime behavior is easy to observe
- every change is visible immediately when the app runs

### 2. Create And Run The Project

The basic workflow is:

```powershell
dotnet new console -n HelloConsole
cd HelloConsole
dotnet run
```

The first run proves three things:

- the project was created successfully
- the code compiled successfully
- the program executed successfully

### 3. `Program.cs` And Top-Level Statements

In current .NET console templates, the learner does not immediately see a full `Main` method. Instead, the file often starts with top-level statements.

That means the code in `Program.cs` runs as the entry point of the application without the learner having to write boilerplate first.

For a beginner, the important mental model is:

- `Program.cs` is where execution starts for this simple app
- lines in that file run from top to bottom
- changing the text inside `Console.WriteLine` changes what appears in the terminal

### 4. Change The Program And Rerun It

One of the first useful exercises is to replace the default greeting with something personal or descriptive.

Example:

```csharp
Console.WriteLine("Welcome to Dotnet Academy.");
```

Then rerun the application:

```powershell
dotnet run
```

This reinforces an important loop:

1. edit the code
2. rerun the app
3. compare the output to what you expected

### 5. Pass Input With Command-Line Arguments

Console applications can receive input from the command line.

With top-level statements, the current template exposes `args` automatically.

Example:

```csharp
var name = args.Length > 0 ? args[0] : "learner";
Console.WriteLine($"Hello, {name}!");
```

Run the application with an argument like this:

```powershell
dotnet run -- Ada
```

The `--` separates arguments for `dotnet run` from arguments meant for the application itself.

### 6. Build Confidence By Reading The Output

At this stage, the learner does not need advanced architecture. They need confidence.

The key habit is to connect what they typed to what they see:

- command entered in the terminal
- code inside `Program.cs`
- output printed by the app

That connection is the foundation for every later lesson.

## Demo

The runnable sample for this topic lives at:

`src/01-foundations/02-first-console-application/DotnetAcademy.FirstConsoleAppDemo/`

Run it from the repository root with no arguments:

```powershell
dotnet run --project ./src/01-foundations/02-first-console-application/DotnetAcademy.FirstConsoleAppDemo
```

Run it again with a learner name:

```powershell
dotnet run --project ./src/01-foundations/02-first-console-application/DotnetAcademy.FirstConsoleAppDemo -- Ada
```

Expected result:

- the sample prints a short banner for the topic
- the greeting changes when a name is passed as the first argument
- the output explains the role of `Program.cs` and `dotnet run -- <value>`

## Common Mistakes

- Running `dotnet run Ada` without `--`, which sends the argument to the CLI instead of the application.
- Editing the wrong file or wrong project when multiple folders are open.
- Forgetting to rerun the app after changing the code.
- Thinking top-level statements are magic instead of understanding that they are a simpler entry-point syntax.
- Treating command-line arguments as always present without a fallback path.

## Exercises

Use `exercises.md` for the guided exercise.

The starter pack for this topic lives under:

`exercises/01-foundations/02-first-console-application/`

It includes a workspace folder, a challenge brief, and expected output examples.

## Verification

This topic is successful when the learner can do all of the following without guessing:

- create a console app from the CLI
- run it successfully
- change the displayed output in `Program.cs`
- pass a simple name argument with `dotnet run -- Ada`
- explain, at a beginner-friendly level, why `Program.cs` is enough for this simple app

