---
title: 04 Control Flow And Methods
stage: 01-foundations
topic: 04-control-flow-and-methods
level: beginner
estimated_hours: 2
prerequisites:
  - 02 First Console Application
  - 03 Variables Types And Conversions
learning_outcomes:
  - Use `if` and `else` statements to make simple decisions in a console application.
  - Explain boolean conditions and comparison results in beginner-friendly terms.
  - Write and call small methods with parameters and return values.
  - Use a basic `for` loop to repeat a predictable step.
---

# 04 Control Flow And Methods

## Why This Matters

Control flow is how a program chooses what to do next. Methods are how a program groups logic so it can be reused and understood.

Without control flow, a program can only run straight from top to bottom. Without methods, even small programs become repetitive and hard to read.

This topic matters because it introduces three habits that show up everywhere in C#:

1. make a decision based on a condition
2. repeat a small step when the program needs to do it more than once
3. move logic into a named method so the intent is easier to read

## Concepts

### 1. Control Flow Means Choosing What Happens Next

When a program asks a question such as `Did the learner practice today?`, it needs a way to choose between outcomes.

That is what `if` and `else` do.

Example:

```csharp
if (practicedToday)
{
    Console.WriteLine("Keep going.");
}
else
{
    Console.WriteLine("Practice once more before moving on.");
}
```

The condition inside the parentheses must evaluate to `true` or `false`.

### 2. Conditions Usually Use Comparisons

Common beginner-friendly comparisons include:

- `==` equal to
- `!=` not equal to
- `>` greater than
- `<` less than
- `>=` greater than or equal to
- `<=` less than or equal to

Example:

```csharp
if (completedTopics >= 4)
{
    Console.WriteLine("You are ready for a larger exercise.");
}
```

### 3. Methods Give Logic A Name

A method lets the learner move a piece of logic into a named block.

Example:

```csharp
static string GetReadinessMessage(int completedTopics)
{
    if (completedTopics >= 4)
    {
        return "You are ready for the next challenge.";
    }

    return "Stay with the current topic a little longer.";
}
```

The important parts are:

- the method name describes what it does
- parameters let the caller pass in the data it needs
- the return value gives the result back to the caller

### 4. Why Methods Matter Early

Beginners often write everything directly in `Program.cs`.

That is acceptable at first, but once logic becomes more than one or two lines, methods help by:

- reducing repetition
- making the program easier to explain
- making the logic easier to test later

### 5. Repetition With A Basic Loop

Sometimes the program needs to perform a small step several times.

Example:

```csharp
for (var sessionNumber = 1; sessionNumber <= 3; sessionNumber++)
{
    Console.WriteLine($"Practice session {sessionNumber}");
}
```

At this stage, the learner should understand:

- where the loop starts
- when the loop stops
- what changes on each pass through the loop

### 6. Reading Flow From Top To Bottom

When code mixes variables, conditions, and method calls, the learner should still be able to explain it clearly:

1. variables store the current state
2. methods evaluate that state
3. conditions choose a branch
4. loops repeat a small action when needed

That mental model is more important than memorizing syntax alone.

## Demo

The runnable sample for this topic lives at:

`src/01-foundations/04-control-flow-and-methods/DotnetAcademy.ControlFlowMethodsDemo/`

Run it from the repository root:

```powershell
dotnet run --project ./src/01-foundations/04-control-flow-and-methods/DotnetAcademy.ControlFlowMethodsDemo
```

Expected result:

- the sample prints a study recommendation summary
- the sample uses methods to calculate messages
- the sample uses conditional logic to choose a recommendation
- the sample uses a loop to print suggested practice sessions

## Common Mistakes

- Writing conditions that do not evaluate to `true` or `false`.
- Copying the same logic in multiple places instead of moving it into a method.
- Writing a method without making its purpose clear from the name.
- Creating off-by-one errors in `for` loops.
- Making one beginner method do too many unrelated things.

## Exercises

Use `exercises.md` for the guided exercise.

The starter pack for this topic lives under:

`exercises/01-foundations/04-control-flow-and-methods/`

It includes a workspace folder, a short challenge brief, and expected output examples.

## Verification

This topic is successful when the learner can do all of the following without guessing:

- write a simple `if` and `else` branch
- explain what condition is being tested
- create a small method with parameters and a return value
- use a `for` loop to print a repeated sequence
- explain how methods make the program easier to read

