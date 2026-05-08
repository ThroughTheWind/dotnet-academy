---
title: 02 Records Structs And Enums Exercise
stage: 02-csharp-core
topic: 02-records-structs-and-enums
exercise_type: guided
estimated_minutes: 65
prerequisites:
  - 02 Records Structs And Enums
success_criteria:
  - Use an enum for milestone state.
  - Use a struct for one small value-focused model.
  - Use a record and a `with` expression to produce an updated version of the same data.
---

# 02 Records Structs And Enums Exercise

## Prompt

Create a console app named `MilestoneTrackerConsole` that models a small course milestone tracker.

Your app must:

1. define an enum for milestone state
2. define a record for a course milestone
3. define a struct for a simple practice budget or session summary
4. create an updated milestone by copying a record with one changed value
5. print a readable summary that uses all three types

Use the starter pack in `exercises/02-csharp-core/02-records-structs-and-enums/` while working.

## Constraints

- Use `with` at least once on the record.
- Keep the struct focused on a small value model.
- Use the enum instead of free-form status strings.
- Keep the program as a console app.

## Hints

- A milestone title and status are enough for the record.
- A planned-vs-completed session count is enough for the struct.
- A method or helper that formats enum values can keep the output readable.
- Start with one milestone, then create the updated copy.

## Verification

The exercise is complete when the learner can show all of the following:

- the project builds and runs successfully
- the enum limits the possible milestone states
- the original record remains unchanged after the copied version is created
- the output clearly uses data from the record, struct, and enum together

Compare your output structure to the starter pack examples. The exact wording can differ.

## Extension Ideas

- Add a second enum state such as `Blocked`.
- Compare two records with the same values.
- Add another computed member to the struct.

## Micro Exercise

For a 10-minute focused drill, use `exercises/02-csharp-core/02-records-structs-and-enums/micro-exercise.md`.

This micro exercise isolates one enum and one small record copy before the larger guided exercise.