# Collections And Immutability Tradeoffs Sample

This folder contains the runnable sample for the `02-collections-and-immutability-tradeoffs` topic.

## Project

- `DotnetAcademy.CollectionsTradeoffsDemo/` demonstrates list ordering, dictionary lookup, hash set uniqueness, and stable snapshot publication.

## Run The Sample

From the repository root:

```powershell
dotnet run --project ./src/03-productivity-and-data-transformation/02-collections-and-immutability-tradeoffs/DotnetAcademy.CollectionsTradeoffsDemo
```

## What To Observe

- the working board stays mutable because planning still changes over time
- the published snapshot copies the report data so readers see a stable view
- the sample uses different collection types because the operations are different, not because variety is required