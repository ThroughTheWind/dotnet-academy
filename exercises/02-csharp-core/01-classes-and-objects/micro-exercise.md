---
title: Class Snapshot Drill
stage: 02-csharp-core
topic: 01-classes-and-objects
exercise_type: micro
estimated_minutes: 10
prerequisites:
  - 01 Classes And Objects
success_criteria:
  - Create one small class with a constructor and one property.
  - Call one method on an object created from that class.
---

# Class Snapshot Drill

## Prompt

Create a small class named `TopicSnapshot` with:

- one constructor
- one read-only property named `Title`
- one method named `GetLabel()` that returns a short sentence

Create one object from the class and print the label.

## Constraints

- Keep the class under 20 lines if possible.
- Do not add inheritance or collections.

## Hints

- Start with `public sealed class TopicSnapshot`.
- Let the constructor set `Title`.

## Verification

The drill is complete when the program prints text that clearly came from a method on the object.

## Extension Ideas

- Add a second property for difficulty.
- Create a second object with a different title.