# First Console Application Sample

This folder contains the runnable sample for the `02-first-console-application` topic.

## Project

- `DotnetAcademy.FirstConsoleAppDemo/` demonstrates a simple console app that prints a greeting and reacts to an optional first command-line argument.

## Run The Sample

From the repository root:

```powershell
dotnet run --project ./src/01-foundations/02-first-console-application/DotnetAcademy.FirstConsoleAppDemo
dotnet run --project ./src/01-foundations/02-first-console-application/DotnetAcademy.FirstConsoleAppDemo -- Ada
```

## What To Observe

- `Program.cs` is enough to drive this simple console application.
- top-level statements keep the first project small and readable
- `dotnet run -- Ada` passes `Ada` to the application as the first argument