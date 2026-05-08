---
title: 06 Lambdas Delegates Events And Pattern Matching
stage: 02-csharp-core
topic: 06-lambdas-delegates-events-and-pattern-matching
level: intermediate
estimated_hours: 2
prerequisites:
  - 05 Generics Collections And Exceptions
learning_outcomes:
  - Use delegates and lambdas to pass behavior clearly.
  - Raise and subscribe to simple events.
  - Use pattern matching to branch on type and value together.
---

# 06 Lambdas Delegates Events And Pattern Matching

## Why This Matters

Modern C# does not only model data. It also models behavior.

Delegates and lambdas let you pass small pieces of behavior into a method without creating a new class every time. Events let one object announce that something happened without knowing exactly who is listening. Pattern matching makes those flows easier to read by turning scattered type checks into one clear expression.

These tools appear everywhere in .NET: LINQ, UI callbacks, background processing, domain notifications, and branching logic over rich data shapes.

## Concepts

### 1. Delegates Represent Methods As Values

A delegate describes the shape of a callable piece of behavior.

```csharp
public delegate bool StudyResultFilter(StudyResult result);
```

Any method or lambda that matches that signature can now be passed into another method.

### 2. Lambdas Supply Small Behavior Inline

Lambda expressions are often the clearest way to provide short behavior directly at the call site.

```csharp
StudyResultFilter needsFollowUp = result => result is NeedsPractice or DeferredStudy;
```

That keeps the code near the place where it is used.

### 3. Events Publish Notifications Without Tight Coupling

An event lets a class expose that something happened while keeping control over who can raise it.

```csharp
public event EventHandler<StudyResultRecordedEventArgs>? ResultRecorded;
```

The publisher raises the event. Subscribers decide what to do with that information.

### 4. Pattern Matching Clarifies Type-Driven Branching

Pattern matching is especially useful when different result shapes need different descriptions.

```csharp
return result switch
{
    ReadyToReview { Score: >= 90 } ready => $"{ready.Title} => ready to review after a strong {ready.Score}% result.",
    NeedsPractice practice => $"{practice.Title} => practice again because the score is {practice.Score}%.",
    DeferredStudy deferred => $"{deferred.Title} => revisit later because {deferred.Reason}.",
    _ => throw new ArgumentOutOfRangeException(nameof(result))
};
```

This combines type checks and value checks in one focused block.

### 5. Small Behavior Hooks Should Stay Explicit

These features are powerful, but they are easiest to learn and maintain when kept small.

- use delegates for narrow behavior hooks
- use lambdas for short, obvious logic
- use events for notifications, not hidden workflows
- use pattern matching when it makes branching easier to read than chained `if` statements

## Demo

The runnable sample for this topic lives at:

`src/02-csharp-core/06-lambdas-delegates-events-and-pattern-matching/DotnetAcademy.LambdasDelegatesEventsPatternMatchingDemo/`

Run it from the repository root:

```powershell
dotnet run --project ./src/02-csharp-core/06-lambdas-delegates-events-and-pattern-matching/DotnetAcademy.LambdasDelegatesEventsPatternMatchingDemo
```

Expected result:

- the sample records three study results and raises an event for each one
- lambdas supply both the filtering and formatting logic for a focus list
- pattern matching produces the human-readable descriptions for each result type

## Common Mistakes

- Creating custom delegates when an existing built-in delegate would be clearer in real code.
- Hiding too much work inside an event handler.
- Forgetting that only the publisher should raise the event.
- Using pattern matching without covering all expected shapes.
- Replacing clear named methods with oversized lambdas.

## Exercises

Use `exercises.md` for the guided exercise.

The starter pack for this topic lives under:

`exercises/02-csharp-core/06-lambdas-delegates-events-and-pattern-matching/`

It includes a workspace folder, a challenge brief, expected output examples, and a short micro drill.

## Verification

This topic is successful when the learner can do all of the following:

- define and use a delegate or compatible lambda expression intentionally
- raise one event and observe it from a subscriber
- use pattern matching to describe at least three result shapes clearly
- explain why the final design keeps behavior visible instead of magical

