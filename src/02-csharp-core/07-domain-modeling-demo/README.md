# Domain Modeling Demo

This folder contains the integrated Stage 2 sample for domain modeling and clean abstractions.

## Projects

- `DotnetAcademy.DomainModelingDemo/` contains the shared domain model, generic catalog, abstractions, and domain policies.
- `DotnetAcademy.DomainModelingDemo.Console/` contains the runnable console host that wires the domain model together.

## Run The Sample

From the repository root:

```powershell
dotnet run --project ./src/02-csharp-core/07-domain-modeling-demo/DotnetAcademy.DomainModelingDemo.Console
```

## What To Observe

- the sample keeps the core model in a reusable library instead of burying it in the console app
- the catalog uses generic, type-safe storage while the planner composes workload advice behind an interface
- step-added events, pattern matching, and focused delegate filters work together without hiding the control flow