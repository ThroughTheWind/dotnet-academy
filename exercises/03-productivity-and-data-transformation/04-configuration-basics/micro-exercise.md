---
title: Configuration Override Drill
stage: 03-productivity-and-data-transformation
topic: 04-configuration-basics
exercise_type: micro
estimated_minutes: 10
prerequisites:
  - 04 Configuration Basics
success_criteria:
  - Bind a small settings object from layered configuration.
  - Show one value overridden by a later provider.
---

# Configuration Override Drill

## Prompt

Create one base configuration source and one later override source for a settings object with two properties.

Then:

1. add both sources to a `ConfigurationBuilder`
2. bind the result into an options object
3. print the final values
4. explain which provider won for the overridden property

## Constraints

- Keep the drill to one small settings type.
- Use at least two providers in a clear order.
- Override exactly one property so the effect is obvious.

## Hints

- Later configuration providers override earlier keys.
- `Bind` can map the section into a simple options object.
- The point of the drill is to make provider order visible.

## Verification

The drill is complete when the output shows one property retaining the base value and one property taking the later override.

## Extension Ideas

- Add validation for one invalid numeric setting.
- Add a nested section to the settings object.