---
title: Base Type Drill
stage: 02-csharp-core
topic: 04-inheritance-basics
exercise_type: micro
estimated_minutes: 10
prerequisites:
  - 04 Inheritance Basics
success_criteria:
  - Define one base type and one derived type.
  - Override one member in the derived type.
---

# Base Type Drill

## Prompt

Create an abstract base type named `MessageBase` with one abstract method named `BuildLine()`.

Create one derived type that returns a concrete line of text and print it through a base-type reference.

## Constraints

- Keep the drill to one base type and one derived type.
- Do not add interfaces or collections.

## Hints

- The base type can be `abstract`.
- Store the derived instance in a variable of the base type.

## Verification

The drill is complete when the printed text comes from the overridden member on the derived type.

## Extension Ideas

- Add a second derived type.
- Add a virtual member with a default implementation.