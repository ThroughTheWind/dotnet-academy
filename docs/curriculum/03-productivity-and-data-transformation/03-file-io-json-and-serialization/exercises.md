---
title: 03 File IO JSON And Serialization Exercise
stage: 03-productivity-and-data-transformation
topic: 03-file-io-json-and-serialization
exercise_type: guided
estimated_minutes: 80
prerequisites:
  - 03 File IO JSON And Serialization
success_criteria:
  - Read structured input from disk and deserialize it correctly.
  - Transform the input into a separate export model.
  - Write both a serialized export file and a text report to disk.
---

# 03 File IO JSON And Serialization Exercise

## Prompt

Create a console app named `StudyArchiveExportConsole` that reads a small study-session file, transforms it, and writes exported outputs.

Your app must:

1. read a JSON file from disk
2. deserialize it into explicit input models
3. build a summary export model in memory
4. write the summary back to disk as JSON
5. write a plain-text report alongside the JSON export

Use the starter pack in `exercises/03-productivity-and-data-transformation/03-file-io-json-and-serialization/` while working.

## Constraints

- Keep the first version synchronous and file-based.
- Use `System.Text.Json` for JSON work.
- Keep the input model and the export model separate.
- Write generated files into a safe working folder rather than modifying the original source file.

## Hints

- `File.ReadAllText` and `File.WriteAllText` are enough for the first version.
- `JsonSerializer.Deserialize<T>` and `JsonSerializer.Serialize` cover the JSON boundary.
- Build the export model after deserialization instead of trying to serialize the raw input directly.
- `Path.Combine` helps keep the file paths readable and portable.

## Verification

The exercise is complete when the learner can show all of the following:

- the project builds and runs successfully
- the input file is read from disk and deserialized correctly
- the output JSON contains the transformed summary rather than just the raw input objects
- the plain-text report and JSON export both appear in the expected output folder

## Extension Ideas

- Add validation for a missing input file and print a clearer error.
- Add another export field, such as average minutes per category.
- Replace one plain-text line with a formatted timestamp or path summary.

## Micro Exercise

For a 10-minute focused drill, use `exercises/03-productivity-and-data-transformation/03-file-io-json-and-serialization/micro-exercise.md`.

This micro exercise isolates the deserialize-transform-serialize loop without the larger console workflow.

