---
title: 01 Classes And Objects
stage: 02-csharp-core
topic: 01-classes-and-objects
level: intermediate
estimated_hours: 2
prerequisites:
  - 04 Control Flow And Methods
  - 05 Nullability And Debugging Basics
learning_outcomes:
  - Explain how a class groups related state and behavior.
  - Create object instances with a constructor and use properties to inspect their state.
  - Call instance methods that update or summarize object data.
  - Recognize when a small model should become a class instead of staying as loose variables.
---

# 01 Classes And Objects

## Why This Matters

Real applications rarely stay as a flat list of variables.

Once a program needs to describe a learner, a course, an order, or a message, the code becomes easier to reason about when the related data and behavior live together.

Classes are the most common way to model those concepts in C#. They give the developer a place to define valid starting state, expose important values, and keep related logic close to the object it belongs to.

## Concepts

### 1. A Class Describes A Kind Of Thing

A class is a definition. It says what data an object should hold and what behavior it should support.

Example:

```csharp
public sealed class LearnerProfile
{
    public LearnerProfile(string name, int completedTopics)
    {
        Name = name;
        CompletedTopics = completedTopics;
    }

    public string Name { get; }
    public int CompletedTopics { get; private set; }

    public void CompleteTopic()
    {
        CompletedTopics++;
    }
}
```

The class is not the learner itself. It is the blueprint for learner objects.

### 2. An Object Is One Instance Of That Class

When the program runs `new LearnerProfile(...)`, it creates one object with its own state.

```csharp
var learner = new LearnerProfile("Avery", 2);
```

Another object created from the same class can hold different values.

```csharp
var secondLearner = new LearnerProfile("Mina", 4);
```

Both objects come from the same class, but they are separate instances.

### 3. Constructors Give Objects A Valid Starting State

The constructor runs when the object is created.

Use it to require the values that matter most and to reject invalid starting state.

In beginner-friendly terms, the constructor answers this question:

What must be true before this object should exist?

### 4. Properties Expose State Clearly

Properties make important values readable in a consistent way.

Examples:

- `Name`
- `CompletedTopics`
- `RemainingTopics`

Some properties simply return stored values. Others can compute a value from existing state.

```csharp
public int RemainingTopics => WeeklyGoal - CompletedTopics;
```

This is often clearer than recalculating the same result in several different places.

### 5. Methods Keep Behavior Close To The Data

If behavior depends on an object's state, a method on the class is often the clearest home for that logic.

Examples:

- `CompleteTopic()` updates progress
- `SetFocusArea(...)` keeps focus text normalized
- `GetProgressSummary()` turns the current state into a readable message

This style reduces the amount of logic scattered around the rest of the program.

### 6. Classes Help The Program Read Like The Problem Domain

Instead of passing unrelated variables around:

- learner name
- completed topics
- weekly goal
- focus area

the program can work with one `LearnerProfile` object.

That makes the code closer to the real concept it is modeling.

## Demo

The runnable sample for this topic lives at:

`src/02-csharp-core/01-classes-and-objects/DotnetAcademy.ClassesObjectsDemo/`

Run it from the repository root:

```powershell
dotnet run --project ./src/02-csharp-core/01-classes-and-objects/DotnetAcademy.ClassesObjectsDemo
```

Expected result:

- the sample creates a `LearnerProfile` object
- the object updates its own focus area and progress
- the output shows how properties and methods work together to describe the current state

## Common Mistakes

- Treating a class like a random container instead of modeling one clear concept.
- Putting all logic back in `Program.cs` instead of giving the object meaningful methods.
- Creating objects without validating important constructor inputs.
- Exposing too many values as unrelated local variables after an object already exists.
- Forgetting that different objects from the same class can hold different state.

## Exercises

Use `exercises.md` for the guided exercise.

The starter pack for this topic lives under:

`exercises/02-csharp-core/01-classes-and-objects/`

It includes a workspace folder, a challenge brief, expected output examples, and a short micro drill.

## Verification

This topic is successful when the learner can do all of the following:

- define one small class with a constructor, properties, and at least one method
- create at least two separate objects from that class
- explain which values belong to object state
- move at least one behavior into the class instead of leaving it as a loose helper around raw variables