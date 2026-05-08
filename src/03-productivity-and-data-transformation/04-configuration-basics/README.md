# Configuration Basics Sample

This folder contains the runnable sample for the `04-configuration-basics` topic.

## Project

- `DotnetAcademy.ConfigurationBasicsDemo/` demonstrates layered JSON configuration, later-source overrides, binding, and validation in a console app.

## Run The Sample

From the repository root:

```powershell
dotnet run --project ./src/03-productivity-and-data-transformation/04-configuration-basics/DotnetAcademy.ConfigurationBasicsDemo
```

## What To Observe

- the sample loads base defaults and then applies development overrides
- the final values are bound into a focused settings object
- the report explains that later providers override earlier ones