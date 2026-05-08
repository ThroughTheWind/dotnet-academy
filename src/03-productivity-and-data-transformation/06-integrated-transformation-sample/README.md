# Integrated Transformation Sample

This folder contains the integrated Stage 3 sample for loading, transforming, and persisting study data from multiple sources.

## Projects

- `DotnetAcademy.IntegratedTransformationDemo/` contains the source abstractions, transformation workflow, summary models, and persistence helpers.
- `DotnetAcademy.IntegratedTransformationDemo.Console/` contains the runnable console host, configuration loading, seed data, and presenter.

## Run The Sample

From the repository root:

```powershell
dotnet run --project ./src/03-productivity-and-data-transformation/06-integrated-transformation-sample/DotnetAcademy.IntegratedTransformationDemo.Console
```

## What To Observe

- the sample loads work items from seeded JSON, in-memory data, and a streamed async feed
- it composes the source loads asynchronously and shapes the combined data with LINQ
- it persists both JSON and text output files after the transformation step completes
- configuration stays in the console host while the workflow logic remains reusable and testable