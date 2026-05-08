---
title: 04 Inheritance Basics
stage: 02-csharp-core
topic: 04-inheritance-basics
level: intermediate
estimated_hours: 2
prerequisites:
  - 03 Interfaces And Composition
learning_outcomes:
  - Explain the relationship between a base type and a derived type.
  - Define an abstract base class with shared state or behavior.
  - Override behavior in a derived class.
  - Recognize when inheritance communicates a true specialized relationship and when composition would be safer.
---

# 04 Inheritance Basics

## Why This Matters

Inheritance is a real tool in C#, but it is also easy to misuse.

When a derived type truly is a specialized version of a base type, inheritance can make shared behavior clear and reduce duplication. When that relationship is forced, inheritance makes designs rigid and harder to change.

This topic teaches the useful part without pretending inheritance is the answer to every abstraction problem.

## Concepts

### 1. A Base Type Defines Shared Members

A base type can hold shared state and shared behavior that multiple derived types need.

```csharp
public abstract class LearningResource
{
    protected LearningResource(string title, int estimatedMinutes)
    {
        Title = title;
        EstimatedMinutes = estimatedMinutes;
    }

    public string Title { get; }
    public int EstimatedMinutes { get; }

    public abstract string BuildSummary();
}
```

The base type above says that every learning resource has a title, an estimated length, and a summary.

### 2. Derived Types Specialize The Base Type

Derived types inherit the shared members and add or override behavior.

Examples:

- a guided lesson can include a focus area
- a code challenge can include required outputs

If those types really are specialized forms of the same concept, inheritance can read clearly.

### 3. Abstract Members Force Derived Types To Provide Behavior

An abstract member means the base type requires the derived type to provide its own implementation.

That is useful when every derived type must support the same kind of operation, but the exact behavior differs.

### 4. Virtual Members Allow Shared Defaults With Overrides

A virtual member gives the base type a default implementation while allowing derived types to replace it when needed.

This is helpful when most derived types can share a standard behavior, but one or two need a specialized version.

### 5. Inheritance Is About A True "Is A" Relationship

The key design question is:

Is the derived type truly a specialized version of the base type?

If the answer is weak or unclear, composition is usually safer.

That is why this topic comes after interfaces and composition. Inheritance should be a deliberate choice, not the first abstraction tool reached for automatically.

## Demo

The runnable sample for this topic lives at:

`src/02-csharp-core/04-inheritance-basics/DotnetAcademy.InheritanceBasicsDemo/`

Run it from the repository root:

```powershell
dotnet run --project ./src/02-csharp-core/04-inheritance-basics/DotnetAcademy.InheritanceBasicsDemo
```

Expected result:

- the sample creates two derived resource types through a shared base type reference
- one derived type uses the base follow-up action and another overrides it
- the output ends with a design note about when inheritance fits

## Common Mistakes

- Using inheritance when the relationship is not a real specialization.
- Putting too much responsibility into the base class.
- Forgetting that derived types should still honor the base type's meaning.
- Overriding behavior without a clear reason.
- Choosing inheritance before considering composition.

## Exercises

Use `exercises.md` for the guided exercise.

The starter pack for this topic lives under:

`exercises/02-csharp-core/04-inheritance-basics/`

It includes a workspace folder, a challenge brief, expected output examples, and a short micro drill.

## Verification

This topic is successful when the learner can do all of the following:

- define one abstract base class with shared members
- create at least two derived types
- override behavior in at least one derived type
- explain why the inheritance relationship is a real specialization and not just shared convenience