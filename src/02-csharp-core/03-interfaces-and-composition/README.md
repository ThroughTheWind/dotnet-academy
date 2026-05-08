# Interfaces And Composition Sample

This folder contains the runnable sample for the `03-interfaces-and-composition` topic.

## Project

- `DotnetAcademy.InterfacesCompositionDemo/` demonstrates two interface implementations composed into one study plan.

## Run The Sample

From the repository root:

```powershell
dotnet run --project ./src/02-csharp-core/03-interfaces-and-composition/DotnetAcademy.InterfacesCompositionDemo
```

## What To Observe

- different classes satisfy the same interface contract
- the study plan depends on the abstraction instead of one concrete type
- composition keeps the higher-level object small and readable