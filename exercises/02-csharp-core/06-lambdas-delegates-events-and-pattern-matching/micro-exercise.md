---
title: Pattern Match Status Drill
stage: 02-csharp-core
topic: 06-lambdas-delegates-events-and-pattern-matching
exercise_type: micro
estimated_minutes: 10
prerequisites:
  - 06 Lambdas Delegates Events And Pattern Matching
success_criteria:
  - Define three small result shapes.
  - Use one switch expression to describe all three shapes.
---

# Pattern Match Status Drill

## Prompt

Create three result types for a learner task:

- one for a strong finish
- one for more practice
- one for a skipped task

Then write one method named `DescribeResult` that uses a `switch` expression to return a different message for each result shape.

## Constraints

- Keep the drill focused on pattern matching.
- Do not use long chains of `if` and `else`.
- Return strings directly from the `switch` expression.

## Hints

- Records work well for small result shapes.
- You can match on both type and property values.

## Verification

The drill is complete when one method can describe all three shapes clearly and each branch is easy to read.

## Extension Ideas

- Add a score threshold branch for the strong-finish result.
- Add a default branch that throws for unexpected shapes.