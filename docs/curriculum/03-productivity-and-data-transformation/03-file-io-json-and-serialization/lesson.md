---
title: 03 File IO JSON And Serialization
stage: 03-productivity-and-data-transformation
topic: 03-file-io-json-and-serialization
level: intermediate
estimated_hours: 2
prerequisites:
  - 01 LINQ Fundamentals And Query Thinking
  - 02 Collections And Immutability Tradeoffs
learning_outcomes:
  - Read structured input from disk with basic file APIs.
  - Deserialize JSON into explicit models and serialize export models back to disk.
  - Separate source models from export models during data transformation.
---

# 03 File IO JSON And Serialization

## Why This Matters

Most useful applications eventually need to cross a process boundary.

That usually means reading data from disk, shaping it in memory, and then writing a result that another tool, user, or process can consume later. .NET makes that straightforward, but the code gets clearer when the workflow is kept explicit:

1. read the file
2. deserialize it into a model that matches the source data
3. transform it into the information the application actually needs
4. serialize an output model and write the result to disk

This topic focuses on that full path with local files and JSON.

## Concepts

### 1. File APIs Move Bytes And Text Across The Boundary

Methods like `File.ReadAllText`, `File.WriteAllText`, and `File.WriteAllLines` are useful when the files are small enough to load into memory comfortably.

That keeps the first file I/O examples simple and readable.

```csharp
var json = File.ReadAllText(inputPath);
File.WriteAllText(summaryPath, summaryJson);
```

For this topic, small files are enough. Streaming and asynchronous file APIs can come later.

### 2. Deserialize Into A Model That Matches The Input

The input file structure should map cleanly to a type that represents what is already on disk.

```csharp
var sessions = JsonSerializer.Deserialize<StudySessionRecord[]>(json, serializerOptions)
    ?? throw new InvalidOperationException("The input file did not contain session data.");
```

That keeps the boundary honest. The code is reading the source shape first, not pretending the file already matches the final report.

### 3. Transform In Memory Before Writing The Output

After deserialization, use normal collection and LINQ operations to compute the export data.

```csharp
var categories = sessions
    .GroupBy(session => session.Category)
    .OrderBy(group => group.Key)
    .Select(group => new StudySessionCategorySummary(group.Key, group.Count(), group.Sum(session => session.Minutes)))
    .ToArray();
```

This is the point where the application turns raw input into a useful summary.

### 4. Serialize Explicit Export Models

It is usually better to serialize a deliberate export model than to re-emit the same input objects without thinking.

```csharp
var summaryJson = JsonSerializer.Serialize(summary, serializerOptions);
File.WriteAllText(summaryPath, summaryJson);
```

That makes the output contract clearer and prevents accidental coupling between what the application read and what it wants to publish.

### 5. Keep Writes Out Of The Source Tree During Demos

For runnable samples, write generated files into the build output or another safe working directory instead of modifying the repository source files.

That keeps validation predictable and avoids teaching learners to scatter generated artifacts into tracked folders by default.

## Demo

The runnable sample for this topic lives at:

`src/03-productivity-and-data-transformation/03-file-io-json-and-serialization/DotnetAcademy.FileIoJsonSerializationDemo/`

Run it from the repository root:

```powershell
dotnet run --project ./src/03-productivity-and-data-transformation/03-file-io-json-and-serialization/DotnetAcademy.FileIoJsonSerializationDemo
```

Expected result:

- the sample reads a seeded JSON file copied into the build output
- it deserializes study sessions into source models
- it writes a JSON summary export and a text report into a generated folder under the build output
- the console output explains what was loaded and what was written

## Common Mistakes

- Reusing the input model as the output model without deciding what the export should contain.
- Writing generated output back into tracked source folders during a demo.
- Assuming deserialization always succeeds without checking for missing or empty data.
- Mixing path construction, file I/O, transformation, and presentation into one unreadable method.
- Jumping to asynchronous file APIs before the synchronous workflow is clear.

## Exercises

Use `exercises.md` for the guided exercise.

The starter pack for this topic lives under:

`exercises/03-productivity-and-data-transformation/03-file-io-json-and-serialization/`

It includes a workspace folder, a challenge brief, expected output examples, and a short micro drill for reading JSON and serializing a small export model.

## Verification

This topic is successful when the learner can do all of the following:

- read a small file from disk and explain where the path comes from
- deserialize JSON into an explicit input model
- transform the data into a separate export model
- write serialized output and a text report without modifying repository source files

