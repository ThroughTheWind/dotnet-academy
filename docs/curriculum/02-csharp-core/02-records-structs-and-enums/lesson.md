---
title: 02 Records Structs And Enums
stage: 02-csharp-core
topic: 02-records-structs-and-enums
level: intermediate
estimated_hours: 2
prerequisites:
  - 01 Classes And Objects
learning_outcomes:
  - Explain the difference between class-based object models and smaller data-oriented models using records, structs, and enums.
  - Use an enum to constrain a state value to a known list of options.
  - Use a struct to model a compact value with simple behavior.
  - Use a record to copy data with a small change while keeping the original instance unchanged.
---

# 02 Records Structs And Enums

## Why This Matters

Not every model in a .NET application needs the full flexibility of a mutable class.

Sometimes the code needs:

- a small fixed state value like `Planned` or `Completed`
- a compact value model like a budget or coordinate
- a simple data shape that is easy to copy with one changed value

Records, structs, and enums exist because those cases are common.

## Concepts

### 1. Enums Represent A Closed Set Of Named Options

An enum is useful when a value should only come from a small list of choices.

```csharp
public enum PracticeStatus
{
    Planned,
    InProgress,
    Review,
    Completed
}
```

This is clearer than passing around magic numbers or inconsistent text values.

### 2. Structs Fit Small Value-Oriented Models

A struct is often a good fit when a type is small, self-contained, and behaves like a value.

Examples:

- a budget
- a coordinate
- a duration summary

At this stage, the main idea is not deep runtime behavior. The main idea is that a struct can model a compact value with its own validation and helper methods.

### 3. Records Reduce Boilerplate For Data-Centered Types

A record is a convenient way to define a type whose main job is to hold related data.

```csharp
public sealed record LearningMilestone(string Title, PracticeStatus Status);
```

Records can still have methods, but they are especially useful when the shape is mostly data.

### 4. Records Support Copy-With-Change Behavior

The `with` expression creates a copy based on an existing record while changing only the specified members.

```csharp
var original = new LearningMilestone("Records", PracticeStatus.InProgress);
var updated = original with { Status = PracticeStatus.Completed };
```

This is useful when the program should preserve the original value and create a new version for the next state.

### 5. The Goal Is Better Modeling, Not More Syntax

The real question is not “Which keyword looks interesting?”

The better question is:

Which type best matches the concept I am modeling?

- use an enum for named states
- use a struct for a small value model
- use a record for simple data-centered objects
- use a class when the object needs richer, evolving behavior

## Demo

The runnable sample for this topic lives at:

`src/02-csharp-core/02-records-structs-and-enums/DotnetAcademy.RecordsStructsEnumsDemo/`

Run it from the repository root:

```powershell
dotnet run --project ./src/02-csharp-core/02-records-structs-and-enums/DotnetAcademy.RecordsStructsEnumsDemo
```

Expected result:

- the sample prints an enum-driven status label
- a record is copied with an updated status using `with`
- a struct summarizes a small practice budget value cleanly

## Common Mistakes

- Using free-form strings when an enum should represent the state.
- Choosing a record or struct only because it is shorter, without thinking about the model.
- Mutating data everywhere instead of using a record copy when a new version is clearer.
- Making a struct large and behavior-heavy when a class would communicate the model better.
- Treating these types as isolated syntax exercises instead of modeling tools.

## Exercises

Use `exercises.md` for the guided exercise.

The starter pack for this topic lives under:

`exercises/02-csharp-core/02-records-structs-and-enums/`

It includes a workspace folder, a challenge brief, expected output examples, and a short micro drill.

## Verification

This topic is successful when the learner can do all of the following:

- define one enum and explain why it prevents invalid state values
- create one small struct with validation or a computed member
- define one record for data-centered modeling
- use `with` to create an updated record while preserving the original value