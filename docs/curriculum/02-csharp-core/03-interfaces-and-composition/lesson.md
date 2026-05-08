---
title: 03 Interfaces And Composition
stage: 02-csharp-core
topic: 03-interfaces-and-composition
level: intermediate
estimated_hours: 2
prerequisites:
  - 01 Classes And Objects
  - 02 Records Structs And Enums
learning_outcomes:
  - Explain how an interface defines a contract without choosing an implementation.
  - Implement the same interface in more than one class.
  - Compose interface-based objects into a higher-level type.
  - Describe why composition is often safer and more flexible than tightly coupled designs.
---

# 03 Interfaces And Composition

## Why This Matters

As code grows, one class should not need to know every concrete detail about every other class.

Interfaces help by describing what behavior is available. Composition helps by combining smaller objects into a richer model without hardwiring everything into one giant type hierarchy.

Together, they are a practical starting point for maintainable design.

## Concepts

### 1. An Interface Defines A Contract

An interface says what members a type must provide.

```csharp
public interface ILearningActivity
{
    string Title { get; }
    int EstimatedMinutes { get; }
    string BuildSummary();
}
```

The interface does not say how a video lesson or a practice exercise should implement those members. It only defines the shared shape.

### 2. Different Classes Can Satisfy The Same Contract

Two classes can implement the same interface with different behavior.

- a video lesson may describe itself as a video
- a practice exercise may describe itself as a coding task

This lets the rest of the program work with the abstraction instead of a long list of special cases.

### 3. Composition Builds Larger Behavior From Smaller Parts

Composition means one object owns or uses other objects as part of its behavior.

For example, a `StudyPlan` can contain a list of `ILearningActivity` items.

The `StudyPlan` does not need to know every concrete detail of each activity type. It only needs the contract.

### 4. Interfaces Help Create Dependency Boundaries

If a type depends on an interface instead of one specific concrete class, it becomes easier to:

- replace one implementation with another
- test behavior in smaller pieces
- keep responsibilities separated

This is one of the first steps from beginner code toward maintainable application design.

### 5. Composition Is Usually The Safer Default

When deciding between composition and more rigid coupling, composition is often the safer choice because it keeps types smaller and easier to rearrange.

At this stage, the important habit is simple:

prefer combining focused objects over creating one class that tries to own every concern.

## Demo

The runnable sample for this topic lives at:

`src/02-csharp-core/03-interfaces-and-composition/DotnetAcademy.InterfacesCompositionDemo/`

Run it from the repository root:

```powershell
dotnet run --project ./src/02-csharp-core/03-interfaces-and-composition/DotnetAcademy.InterfacesCompositionDemo
```

Expected result:

- the sample creates two different activity types that implement the same interface
- a `StudyPlan` composes those activities into one agenda
- the output shows that the higher-level plan depends on the interface contract, not one hardcoded type

## Common Mistakes

- Treating an interface as a place for stored state.
- Creating an interface with only one trivial implementation and no clear boundary reason.
- Making the composed type depend on concrete details it does not actually need.
- Stuffing unrelated behavior back into one large class instead of composing focused collaborators.
- Using interfaces as ceremony instead of to express a meaningful contract.

## Exercises

Use `exercises.md` for the guided exercise.

The starter pack for this topic lives under:

`exercises/02-csharp-core/03-interfaces-and-composition/`

It includes a workspace folder, a challenge brief, expected output examples, and a short micro drill.

## Verification

This topic is successful when the learner can do all of the following:

- define one interface that represents a meaningful shared behavior
- implement that interface in at least two classes
- compose those implementations into a coordinating object
- explain why the coordinating object only needs the interface contract