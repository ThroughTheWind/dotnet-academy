---
title: 05 Nullability And Debugging Basics
stage: 01-foundations
topic: 05-nullability-and-debugging-basics
level: beginner
estimated_hours: 2
prerequisites:
  - 03 Variables Types And Conversions
  - 04 Control Flow And Methods
learning_outcomes:
  - Explain what a nullable reference such as `string?` communicates in a beginner-friendly way.
  - Use a null check or the `??` operator to provide a safe fallback value.
  - Identify a small set of debugging steps before changing code blindly.
  - Read a small console app and reason about where a missing value affected the output.
---

# 05 Nullability And Debugging Basics

## Why This Matters

Real programs do not always have every value available.

Sometimes a learner has no mentor assigned yet. Sometimes a warning message was never recorded. Sometimes a value that looked safe turns out to be missing.

Nullability matters because it helps the program and the programmer express that possibility clearly instead of pretending every value will always be present.

Debugging matters because even small programs can behave differently than the learner expected. A reliable process is better than random edits.

## Concepts

### 1. Some Values May Be Missing

When a value might be missing, the code should say so.

Example:

```csharp
string? mentorName = null;
```

The `?` on `string?` tells the reader and the compiler that the variable may contain text or may contain no value at all.

For a beginner, the important idea is simple:

- `string` means the code expects a text value to exist
- `string?` means the code is prepared for the value to be missing

### 2. Safe Fallback Values

If a value might be missing, the program needs a safe next step.

One simple approach is the null-coalescing operator:

```csharp
var mentorDisplay = mentorName ?? "no mentor assigned";
```

This means:

- use `mentorName` if it has a value
- otherwise use the fallback text

Another approach is a normal null check:

```csharp
if (mentorName is null)
{
    Console.WriteLine("No mentor assigned.");
}
```

### 3. Nullability Is About Intent, Not Panic

Beginners sometimes hear “null” and treat it as a mysterious disaster.

At this stage, the better mindset is:

- missing values happen
- the code should acknowledge that possibility
- the program should choose a sensible fallback instead of crashing or printing confusing output

### 4. Beginner Debugging Is A Process

When output looks wrong, do not immediately rewrite the program.

Use a short checklist:

1. reproduce the behavior with the same input
2. inspect the current values involved in the problem
3. identify the exact line or step where the value stopped matching expectations
4. change one thing at a time and rerun

This process works in a terminal, in VS Code, or in a full IDE.

### 5. Small Signals That Help With Debugging

Even in a basic console app, the learner can use several useful signals:

- the current printed output
- temporary `Console.WriteLine` statements
- method return values
- compiler warnings, including nullability warnings

The goal is not to teach advanced debugging tools yet. The goal is to teach disciplined observation.

### 6. Why Nullability And Debugging Fit Together

These topics connect naturally:

- a missing value often explains unexpected output
- a good fallback prevents confusing failures
- a debugging checklist helps the learner confirm what was actually null and where the fallback should be applied

That is why this lesson combines both ideas into one small beginner topic.

## Demo

The runnable sample for this topic lives at:

`src/01-foundations/05-nullability-and-debugging-basics/DotnetAcademy.NullabilityDebuggingDemo/`

Run it from the repository root:

```powershell
dotnet run --project ./src/01-foundations/05-nullability-and-debugging-basics/DotnetAcademy.NullabilityDebuggingDemo
```

Expected result:

- the sample prints a learner support summary
- a nullable value is shown in its raw state and then displayed with a safe fallback
- the output includes a short debugging checklist instead of vague advice

## Common Mistakes

- Treating nullable values as if they are always present.
- Using fallback values without understanding why the original value was missing.
- Making multiple code changes before confirming which value is actually wrong.
- Ignoring nullability warnings because the program “still runs.”
- Using vague debugging advice instead of checking the actual variable values involved.

## Exercises

Use `exercises.md` for the guided exercise.

The starter pack for this topic lives under:

`exercises/01-foundations/05-nullability-and-debugging-basics/`

It includes a workspace folder, a short challenge brief, and expected output examples.

## Verification

This topic is successful when the learner can do all of the following without guessing:

- declare at least one nullable variable intentionally
- use a null check or `??` to provide a safe fallback value
- explain why the fallback exists
- follow a short debugging checklist to inspect a wrong or missing value before editing the program

