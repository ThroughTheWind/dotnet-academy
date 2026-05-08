---
title: Generic Bucket Drill
stage: 02-csharp-core
topic: 05-generics-collections-and-exceptions
exercise_type: micro
estimated_minutes: 10
prerequisites:
  - 05 Generics Collections And Exceptions
success_criteria:
  - Create one small generic class that stores typed items.
  - Throw an exception when the learner requests an item from an empty bucket.
---

# Generic Bucket Drill

## Prompt

Create a generic class named `PracticeBucket<T>` with two members:

- `Add(T item)`
- `TakeFirst()`

Store items in a `List<T>`. If `TakeFirst()` is called when the bucket is empty, throw an `InvalidOperationException`.

Then create a short console flow that stores two `string` values and prints the first one.

## Constraints

- Keep the drill to one generic class.
- Use `List<T>`.
- Throw a standard exception instead of returning `null`.

## Hints

- Check `Count` before removing the first item.
- `RemoveAt(0)` is fine for this small drill.

## Verification

The drill is complete when the program prints one stored value and the class throws the expected exception if the bucket is empty.

## Extension Ideas

- Instantiate the same bucket with `int` values.
- Add a `Count` property.