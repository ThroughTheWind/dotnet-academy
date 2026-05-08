---
title: 04 Configuration Basics
stage: 03-productivity-and-data-transformation
topic: 04-configuration-basics
level: intermediate
estimated_hours: 2
prerequisites:
  - 03 File IO JSON And Serialization
  - 02 Collections And Immutability Tradeoffs
learning_outcomes:
  - Explain how .NET configuration layers values from multiple providers.
  - Bind a configuration section into an options object and validate it.
  - Show how later configuration sources override earlier defaults.
---

# 04 Configuration Basics

## Why This Matters

Most .NET applications need values that should change without recompiling the code.

Connection strings, feature flags, file paths, environment-specific behavior, and tuning knobs all belong outside the main control flow. The configuration system exists so the application can read those values from layered sources instead of hard-coding them.

For a first configuration topic, the important ideas are:

1. defaults usually start in a base JSON file
2. later providers can override earlier values
3. the application should bind the final values into a small model it can validate and use clearly

## Concepts

### 1. Configuration Is An Ordered Pipeline Of Providers

The final configuration value depends on which providers were added and in what order.

If a key appears in multiple providers, the later provider wins.

```csharp
var configuration = new ConfigurationBuilder()
    .SetBasePath(baseDirectory)
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile("appsettings.Development.json", optional: true)
    .AddEnvironmentVariables(prefix: "DOTNET_ACADEMY__")
    .Build();
```

That order means environment-specific values can override the base JSON defaults without editing the original file.

### 2. JSON Files Are A Clear Starting Point

`appsettings.json` is a good place for defaults because it is readable and easy to review.

An optional follow-up file like `appsettings.Development.json` is useful when local development behavior should differ from the shared default.

### 3. Bind A Section Into An Options Object

Instead of reading each key one by one throughout the code, bind the relevant section into a focused options type.

```csharp
var settings = new StudyPlannerSettings();
configuration.GetSection(StudyPlannerSettings.SectionName).Bind(settings);
settings.Validate();
```

That gives the application one place to describe what it expects and one place to validate whether the configuration is usable.

### 4. Validate Early

Configuration errors are easier to fix when the application fails near startup instead of producing confusing behavior later.

Check for missing strings, invalid numbers, or other impossible combinations as soon as the options object is loaded.

### 5. Keep The First Example Small

This topic is about configuration behavior itself, not the full host pipeline.

Use a console application and a direct `ConfigurationBuilder` example so the learner can see the provider order, the bound section, and the final values without unrelated framework concepts getting in the way.

## Demo

The runnable sample for this topic lives at:

`src/03-productivity-and-data-transformation/04-configuration-basics/DotnetAcademy.ConfigurationBasicsDemo/`

Run it from the repository root:

```powershell
dotnet run --project ./src/03-productivity-and-data-transformation/04-configuration-basics/DotnetAcademy.ConfigurationBasicsDemo
```

Expected result:

- the sample loads settings from `appsettings.json`
- it applies development overrides from `appsettings.Development.json`
- it shows the final bound values in a small configuration report
- it explains why provider order matters

## Common Mistakes

- Assuming configuration providers merge without caring about order.
- Reading string keys inline everywhere instead of binding a focused settings object.
- Skipping validation and discovering bad configuration only after deeper logic runs.
- Mixing configuration basics with dependency injection and host setup before the underlying model is clear.
- Editing the base file for every local change instead of using a later override source.

## Exercises

Use `exercises.md` for the guided exercise.

The starter pack for this topic lives under:

`exercises/03-productivity-and-data-transformation/04-configuration-basics/`

It includes a workspace folder, a challenge brief, expected output examples, and a short micro drill focused on override order.

## Verification

This topic is successful when the learner can do all of the following:

- explain which provider supplied the final value for at least one setting
- bind a configuration section into a focused options object
- validate the loaded settings before using them
- show that a later source can override the base JSON file without changing the original defaults

