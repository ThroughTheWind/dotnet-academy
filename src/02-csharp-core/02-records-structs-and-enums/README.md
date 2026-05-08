# Records Structs And Enums Sample

This folder contains the runnable sample for the `02-records-structs-and-enums` topic.

## Project

- `DotnetAcademy.RecordsStructsEnumsDemo/` demonstrates one enum, one record, and one struct working together in a small data model.

## Run The Sample

From the repository root:

```powershell
dotnet run --project ./src/02-csharp-core/02-records-structs-and-enums/DotnetAcademy.RecordsStructsEnumsDemo
```

## What To Observe

- the enum keeps state values named and constrained
- the record can be copied with one changed property using `with`
- the struct summarizes small value-oriented data clearly