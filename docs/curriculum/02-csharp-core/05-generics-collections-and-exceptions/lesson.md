---
title: 05 Generics Collections And Exceptions
stage: 02-csharp-core
topic: 05-generics-collections-and-exceptions
level: intermediate
estimated_hours: 2
prerequisites:
  - 03 Interfaces And Composition
  - 04 Inheritance Basics
learning_outcomes:
  - Explain how generics keep reusable code type-safe.
  - Choose collections based on the access pattern the code actually needs.
  - Throw and handle standard exceptions at clear application boundaries.
---

# 05 Generics Collections And Exceptions

## Why This Matters

Real .NET applications move data through reusable types all the time.

You rarely want separate classes for `string`, `int`, or every domain type when the behavior is the same. Generics let you express that shared behavior once while keeping compile-time safety.

Collections matter just as much. A `List<T>` is great for preserving order, a `Dictionary<TKey, TValue>` is great for lookups, and a `HashSet<T>` is great when uniqueness matters. Choosing the wrong collection often makes code slower, more confusing, or both.

Exceptions complete the picture. They are not a replacement for regular control flow, but they are the right tool when a caller violates a method contract or when an operation cannot be completed safely.

## Concepts

### 1. Generics Preserve Type Safety In Reusable Code

Without generics, reusable containers often fall back to `object`, which forces casts and hides type errors until runtime.

```csharp
public sealed class StudyCatalog<TItem> where TItem : IPlannableResource
{
    private readonly List<TItem> _items = [];

    public void Add(TItem item)
    {
        ArgumentNullException.ThrowIfNull(item);
        _items.Add(item);
    }

    public IReadOnlyList<TItem> GetItems() => _items;
}
```

The generic type parameter says the catalog works with any item that satisfies the constraint. That gives the learner flexibility without giving up compiler help.

### 2. Collection Choice Should Match The Question Being Asked

Different collections optimize different operations.

- `List<T>` is a good default when order matters and sequential iteration is common.
- `Dictionary<TKey, TValue>` is a good choice for key-based lookup.
- `HashSet<T>` is useful when duplicates should collapse into one unique value.

It is common for one small class to use more than one collection internally because each answers a different question.

### 3. Exceptions Protect Method Contracts

Throw an exception when a caller supplies invalid input or requests an impossible operation.

Examples:

- `ArgumentException` when an identifier is missing
- `ArgumentOutOfRangeException` when a number must be positive
- `InvalidOperationException` when an operation violates an object's current state
- `KeyNotFoundException` when a requested key does not exist

This topic deliberately focuses on standard exceptions before custom exception hierarchies.

### 4. Catch Exceptions At The Boundary

Most domain code should validate early and throw when its contract is broken. The top-level application flow can then catch specific exceptions and decide how to respond.

That keeps the inner code honest while still letting the program fail gracefully at the edge.

### 5. Read-Only Views Communicate Intent

Returning `IReadOnlyList<T>` or `IReadOnlyCollection<T>` communicates that callers can inspect the data but should not mutate internal state directly.

That small design choice makes generic collection-based code much easier to reason about.

## Demo

The runnable sample for this topic lives at:

`src/02-csharp-core/05-generics-collections-and-exceptions/DotnetAcademy.GenericsCollectionsExceptionsDemo/`

Run it from the repository root:

```powershell
dotnet run --project ./src/02-csharp-core/05-generics-collections-and-exceptions/DotnetAcademy.GenericsCollectionsExceptionsDemo
```

Expected result:

- the sample builds a generic catalog for typed study resources
- it uses a list for ordered output, a dictionary for id-based lookup, and a hash set for unique categories
- it catches one lookup failure at the boundary and turns it into a readable note

## Common Mistakes

- Using `object` or untyped collections when a generic type would express the contract clearly.
- Picking one collection type for every problem instead of matching the operation to the data structure.
- Throwing exceptions for expected branching logic instead of truly invalid inputs or invalid states.
- Catching exceptions too early and hiding useful information from the caller.
- Returning mutable internal collections directly.

## Exercises

Use `exercises.md` for the guided exercise.

The starter pack for this topic lives under:

`exercises/02-csharp-core/05-generics-collections-and-exceptions/`

It includes a workspace folder, a challenge brief, expected output examples, and a short micro drill.

## Verification

This topic is successful when the learner can do all of the following:

- build a generic type with at least one useful constraint
- explain why each collection type in the sample was chosen
- throw a standard exception for an invalid operation or invalid input
- catch a specific exception at the application boundary and translate it into a readable message

