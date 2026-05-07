---
title: 03 Variables Types And Conversions
stage: 01-foundations
topic: 03-variables-types-and-conversions
level: beginner
estimated_hours: 2
prerequisites:
  - 01 Development Environment And CLI
  - 02 First Console Application
learning_outcomes:
  - Declare variables with descriptive names and assign values to them.
  - Choose beginner-friendly built-in types such as `string`, `int`, `decimal`, and `bool`.
  - Explain simple implicit and explicit conversions in practical terms.
  - Convert numeric text into numbers and reuse the converted values in a small console app.
---

# 03 Variables Types And Conversions

## Why This Matters

Variables and types are how a program keeps track of information.

Once a learner moves past `Console.WriteLine("Hello")`, they need a way to store values, change them, and combine them. That is the point where variables and types stop being abstract language features and start becoming necessary tools.

This topic matters because:

1. every realistic C# program stores data in variables
2. the chosen type controls what kind of value the program can safely hold
3. conversions appear quickly whenever input starts as text but needs to become a number or another type

## Concepts

### 1. Variables Store Values

A variable is a named place in code that holds a value.

Examples:

```csharp
string learnerName = "Ada";
int completedTopics = 3;
decimal practiceHours = 4.5m;
bool isReadyForNextTopic = true;
```

The learner should connect each part of the declaration:

- the type tells C# what kind of value is stored
- the variable name describes what the value means
- the assigned value is the data the program uses

### 2. Basic Types For A Beginner

At this stage, these types are enough to build useful programs:

- `string` for text
- `int` for whole numbers
- `decimal` for precise decimal values such as money or measured hours
- `bool` for true or false values
- `char` for a single character when needed

The goal is not to memorize every .NET type yet. The goal is to choose the right simple type for the data in front of you.

### 3. Names Matter

Beginners often focus only on syntax, but names are part of the meaning of the program.

This is better:

```csharp
int completedTopics = 3;
```

than this:

```csharp
int x = 3;
```

The first version tells a reader what `3` represents.

### 4. Type And Value Are Not The Same Thing

These are different ideas:

- `"3"` is text stored in a `string`
- `3` is a whole number stored in an `int`

They may look similar to a human reader, but the program treats them differently.

That distinction is one of the first places beginners get stuck, so it should be stated directly.

### 5. Simple Conversions

Some conversions happen safely and automatically.

Example:

```csharp
int completedTopics = 3;
double completedTopicsAsDouble = completedTopics;
```

Some conversions require a deliberate step because the program needs proof that the value makes sense.

Example:

```csharp
string completedExercisesText = "5";
int completedExercises = int.Parse(completedExercisesText);
```

The important beginner takeaway is:

- text input often starts as `string`
- if the program needs a number, the text must be converted first

### 6. Why `decimal` Appears Early

Beginners often see both `double` and `decimal` and wonder which one to use.

For this course, a simple rule is enough at first:

- use `int` for whole numbers
- use `decimal` when you want a non-whole numeric value and want beginner-friendly precision for things like hours or currency examples

More nuance can come later.

### 7. Build A Small Mental Model

When reading code like this:

```csharp
string hoursText = "6";
int practiceHours = int.Parse(hoursText);
```

the learner should be able to say:

1. `hoursText` holds text
2. `practiceHours` holds a number
3. the second line converts the text value into the numeric value the program needs

## Demo

The runnable sample for this topic lives at:

`src/01-foundations/03-variables-types-and-conversions/DotnetAcademy.VariablesTypesDemo/`

Run it from the repository root:

```powershell
dotnet run --project ./src/01-foundations/03-variables-types-and-conversions/DotnetAcademy.VariablesTypesDemo
```

Expected result:

- the sample prints a short typed learner progress summary
- the output shows values from `string`, `int`, `decimal`, and `bool` variables
- the output includes one parsed value that started as text and became a number

## Common Mistakes

- Assuming `"3"` and `3` are the same because they look similar.
- Using vague variable names that hide the meaning of the value.
- Choosing `string` for everything instead of matching the type to the data.
- Forgetting that some conversions must be done explicitly.
- Mixing up `decimal` numeric literals and forgetting the `m` suffix.

## Exercises

Use `exercises.md` for the guided exercise.

The starter pack for this topic lives under:

`exercises/01-foundations/03-variables-types-and-conversions/`

It includes a workspace folder, a short challenge brief, and expected output examples.

## Verification

This topic is successful when the learner can do all of the following without guessing:

- declare several variables with meaningful names
- choose appropriate beginner-friendly types for text, whole numbers, decimal values, and true-or-false values
- explain the difference between a value stored as text and a value stored as a number
- convert numeric text into a numeric value and use it in a small console app

