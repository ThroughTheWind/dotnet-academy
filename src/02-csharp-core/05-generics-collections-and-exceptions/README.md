# Generics Collections And Exceptions Sample

This folder contains the runnable sample for the `05-generics-collections-and-exceptions` topic.

## Project

- `DotnetAcademy.GenericsCollectionsExceptionsDemo/` demonstrates a constrained generic catalog, intentional collection choices, and boundary-focused exception handling.

## Run The Sample

From the repository root:

```powershell
dotnet run --project ./src/02-csharp-core/05-generics-collections-and-exceptions/DotnetAcademy.GenericsCollectionsExceptionsDemo
```

## What To Observe

- the sample uses one generic catalog for typed study resources instead of falling back to `object`
- the catalog combines a list, dictionary, and hash set because each serves a different lookup need
- the final lookup note catches a specific exception at the boundary and turns it into readable output