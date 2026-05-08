# Immutable, Read Only, And Frozen Collections Sample

This folder contains the runnable sample for the `02a-immutable-read-only-and-frozen-collection-tradeoffs` topic.

## Project

- `DotnetAcademy.ReadOnlyImmutableFrozenCollectionsDemo/` demonstrates a live read-only wrapper, an immutable snapshot, and a frozen lookup built from one source catalog.

## Run The Sample

From the repository root:

```powershell
dotnet run --project ./src/03-productivity-and-data-transformation/02a-immutable-read-only-and-frozen-collection-tradeoffs/DotnetAcademy.ReadOnlyImmutableFrozenCollectionsDemo
```

## What To Observe

- the read-only wrapper hides mutators but still reflects later changes to the source catalog
- the immutable snapshot preserves the original published result
- the frozen lookup captures finalized data for repeated reads without tracking later mutations