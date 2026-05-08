---
title: 03 Variables Types And Conversions Exercise
stage: 01-foundations
topic: 03-variables-types-and-conversions
exercise_type: guided
estimated_minutes: 50
prerequisites:
  - 02 First Console Application
  - 03 Variables Types And Conversions
success_criteria:
  - Declare several variables with appropriate beginner-friendly types.
  - Parse numeric text into an integer or decimal value before using it.
  - Print a small learner progress summary using the typed values.
---

# 03 Variables Types And Conversions Exercise

## Prompt

Create a console app named `LearnerProgressCard` that prints a short progress summary using typed variables.

Your app must:

1. store a learner name in a `string`
2. store completed topics in an `int`
3. store practice hours in a `decimal`
4. store readiness for the next topic in a `bool`
5. start with one numeric value as text and convert it into a number before printing it
6. print all of that information in a readable multi-line summary

Use the starter pack in `exercises/01-foundations/03-variables-types-and-conversions/` while working.

## Constraints

- Use top-level statements in `Program.cs`.
- Use at least four different variable declarations.
- Include at least one conversion from text to a numeric type.
- Keep the program focused on variables, types, and conversions rather than control flow.

## Hints

- Start in the `workspace/` folder from the starter pack.
- `int.Parse(...)` or `decimal.Parse(...)` can convert numeric text into numeric values.
- Remember that `decimal` literals need the `m` suffix, for example `4.5m`.
- A variable name should describe the meaning of the value, not just hold a short placeholder like `x`.

## Verification

The exercise is complete when the learner can show all of the following:

- the program builds and runs successfully
- the output contains a readable progress summary
- the summary includes values from multiple types
- at least one value started as text and was converted before use

Compare the structure of your output to the starter pack examples. The exact wording can differ.

## Extension Ideas

- Calculate a simple average such as practice hours per completed topic.
- Add a `char` grade or level marker to the summary.
- Replace one explicit type with `var` and explain why the inferred type is still clear.

## Micro Exercise

For a 10-minute focused drill, use `exercises/01-foundations/03-variables-types-and-conversions/micro-exercise.md`.

This micro exercise isolates the core idea of the topic: choose simple types correctly and convert one text value into a number before printing it.

