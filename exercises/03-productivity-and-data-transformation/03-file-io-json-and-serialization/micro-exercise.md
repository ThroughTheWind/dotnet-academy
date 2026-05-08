---
title: JSON Round Trip Drill
stage: 03-productivity-and-data-transformation
topic: 03-file-io-json-and-serialization
exercise_type: micro
estimated_minutes: 10
prerequisites:
  - 03 File IO JSON And Serialization
success_criteria:
  - Deserialize a small JSON payload into a model.
  - Serialize a different export model back to JSON.
---

# JSON Round Trip Drill

## Prompt

Create a small JSON payload representing two study sessions.

Then:

1. deserialize it into input models
2. build a smaller export model with just totals
3. serialize the export model back into JSON
4. print both the input count and the new JSON output

## Constraints

- Keep the drill in one file and one small data model pair.
- Use `System.Text.Json`.
- Use a different type for the output than for the input.

## Hints

- `JsonSerializer.Deserialize<T>` reads the input payload.
- `JsonSerializer.Serialize` writes the output payload.
- The point of the drill is to make the transformation step explicit.

## Verification

The drill is complete when the output JSON contains the transformed summary rather than the original session array.

## Extension Ideas

- Add indentation options to the serialized JSON.
- Add one category breakdown field to the export model.