---
title: Study Digest Pipeline Lab
stage: 03-productivity-and-data-transformation
topic: 08-study-digest-pipeline-lab
exercise_type: guided
estimated_minutes: 120
prerequisites:
  - 01 LINQ Fundamentals And Query Thinking
  - 02 Collections And Immutability Tradeoffs
  - 03 File IO JSON And Serialization
  - 04 Configuration Basics
  - 05 Async And Await Foundations
  - 05A Cancellation Async Streams And ValueTask Tradeoffs
success_criteria:
  - Load study work items from a JSON file and at least one additional asynchronous source.
  - Combine the items into one collection and shape the digest with LINQ.
  - Persist both a JSON summary file and a text report.
  - Keep the loading, shaping, and output steps readable and separately testable.
---

# Study Digest Pipeline Lab

## Scenario

You are building a small digest tool for a learner trying to coordinate Stage 3 study work. The data arrives partly from a local JSON file and partly from another source that completes later. The final tool should produce a readable digest and persist the shaped result for later review.

## Prompt

Build a console app that prints a learner study digest and writes two output files.

Your program should:

- read the learner name from the first command-line argument, with a safe fallback
- load study work items from a JSON file asynchronously
- load at least one additional asynchronous source and combine the results
- use collections and LINQ to build a category summary and a focus list
- write one JSON summary file and one text report after the combined data is shaped
- keep configuration or settings separate from the transformation logic
- print one short note explaining why the final design separates loading from shaping

## Milestones

1. Create a console app in the recommended workspace and confirm it runs with `dotnet run`.
2. Add the study-work-item shape plus a JSON-backed source that loads items from a seed file.
3. Add a second asynchronous source and combine both sources with `Task.WhenAll`.
4. Build the category summary and focus list with LINQ over the combined collection.
5. Write the JSON summary and text report to an output folder after the digest is complete.
6. Re-run the app after each meaningful change and compare the structure against `starter/expected-output.md`.

## Constraints

- Target .NET 10.
- Keep the application as a console app.
- Use asynchronous file APIs or asynchronous source methods where the load completes later.
- Keep the transformation logic readable enough that another learner can point to the loading step and the shaping step separately.
- Do not hide the whole workflow inside one large method.

## Hints

- One source can load JSON from disk while another returns delayed in-memory data.
- `Task.WhenAll` is a clean way to combine independent asynchronous loads.
- A normal mutable collection is fine while gathering data; LINQ is useful once the combined view is ready to shape.
- Writing a JSON summary and a text report is enough to prove the persistence step works.
- A small settings object can hold the output folder name and the minimum focus threshold.

## Verification

Run your project with a learner name and compare the structure with the expected output example:

```bash
dotnet run --project ./starter/workspace/StudyDigestPipelineConsole -- Ada
```

If you get stuck, inspect the reference implementation in `solution/` only after you have tried the milestones yourself.

## Extension Ideas

- Add one more asynchronous source.
- Add a filter that keeps only selected categories in the focus list.
- Add a cancellation token to the delayed source once the base version works.