# Lambdas Delegates Events And Pattern Matching Sample

This folder contains the runnable sample for the `06-lambdas-delegates-events-and-pattern-matching` topic.

## Project

- `DotnetAcademy.LambdasDelegatesEventsPatternMatchingDemo/` demonstrates small behavior delegates, a simple event notification flow, and pattern matching over study result shapes.

## Run The Sample

From the repository root:

```powershell
dotnet run --project ./src/02-csharp-core/06-lambdas-delegates-events-and-pattern-matching/DotnetAcademy.LambdasDelegatesEventsPatternMatchingDemo
```

## What To Observe

- the sample records study results and raises one event per recorded item
- lambdas define both the filter and formatter used for the focus list
- the descriptions come from one pattern-matching function instead of scattered branching logic