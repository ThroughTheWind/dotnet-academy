---
title: 01 LINQ Fundamentals And Query Thinking Exercise
stage: 03-productivity-and-data-transformation
topic: 01-linq-fundamentals-and-query-thinking
exercise_type: guided
estimated_minutes: 70
prerequisites:
  - 01 LINQ Fundamentals And Query Thinking
success_criteria:
  - Build at least one filtered and ordered query.
  - Build at least one grouped summary query.
  - Explain the question each query is answering.
---

# 01 LINQ Fundamentals And Query Thinking Exercise

## Prompt

Create a console app named `StudyQueryReportConsole` that prints a simple study report from an in-memory collection.

Your app must:

1. define a small list of study attempts or practice sessions
2. print a completed-items section using filtering and ordering
3. print a focus section for items that still need attention
4. print a category summary using grouping
5. keep the queries readable enough to explain in plain language

Use the starter pack in `exercises/03-productivity-and-data-transformation/01-linq-fundamentals-and-query-thinking/` while working.

## Constraints

- Keep the first version in memory; do not add files or databases yet.
- Use LINQ for the query sections instead of manual nested loops.
- Include at least one `Select` projection that changes the shape of the output.
- Keep the output as a console app report.

## Hints

- Start each query by writing the data question as a comment or note.
- `Where` filters, `Select` shapes, `OrderBy` sorts, and `GroupBy` summarizes.
- Materialize with `ToList()` only when you actually need a concrete list.
- If a query gets hard to scan, store it in a clearly named variable before printing.

## Verification

The exercise is complete when the learner can show all of the following:

- the project builds and runs successfully
- the completed-items section is filtered and ordered with LINQ
- the category summary comes from a grouped query
- the learner can explain what question each query answers

## Extension Ideas

- Rewrite one query in query syntax and compare readability.
- Add another category and update the summary output.
- Add a second focus rule and explain whether it belongs in the same query or a separate one.

## Micro Exercise

For a 10-minute focused drill, use `exercises/03-productivity-and-data-transformation/01-linq-fundamentals-and-query-thinking/micro-exercise.md`.

This micro exercise isolates one short filter-and-order query before the full guided exercise.

