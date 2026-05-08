---
title: 04 Configuration Basics Exercise
stage: 03-productivity-and-data-transformation
topic: 04-configuration-basics
exercise_type: guided
estimated_minutes: 75
prerequisites:
  - 04 Configuration Basics
success_criteria:
  - Load configuration from at least two sources in a predictable order.
  - Bind the final values into an options object.
  - Explain which source won for at least one overridden value.
---

# 04 Configuration Basics Exercise

## Prompt

Create a console app named `StudyPlannerConfigConsole` that loads settings for a study planner from layered configuration sources.

Your app must:

1. load defaults from a base JSON file
2. apply a second source that overrides at least one value
3. bind the final values into an options object
4. validate those values before using them
5. print a short configuration report that explains at least one effective override

Use the starter pack in `exercises/03-productivity-and-data-transformation/04-configuration-basics/` while working.

## Constraints

- Keep the first version as a console app rather than introducing the generic host.
- Use the .NET configuration system instead of manually parsing the JSON files yourself.
- Keep the settings model small and focused.
- Show at least one setting whose final value came from a later provider.

## Hints

- `ConfigurationBuilder` adds providers in order.
- `appsettings.json` is a good base source.
- `Bind` or `Get<T>` can map a section to a small options object.
- Validate the options object before printing the final report.

## Verification

The exercise is complete when the learner can show all of the following:

- the project builds and runs successfully
- the final printed settings came from layered configuration rather than hard-coded values
- at least one value was overridden by a later source
- invalid configuration is rejected early with a clear failure

## Extension Ideas

- Add a third provider, such as an environment-variable override.
- Split one settings group into nested sections.
- Add a short explanation of when host-based configuration becomes more useful.

## Micro Exercise

For a 10-minute focused drill, use `exercises/03-productivity-and-data-transformation/04-configuration-basics/micro-exercise.md`.

This micro exercise isolates one override flowing from a second provider into the final bound settings object.

