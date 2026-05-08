---
title: Filter And Order Drill
stage: 03-productivity-and-data-transformation
topic: 01-linq-fundamentals-and-query-thinking
exercise_type: micro
estimated_minutes: 10
prerequisites:
  - 01 LINQ Fundamentals And Query Thinking
success_criteria:
  - Filter a small list with `Where`.
  - Order the filtered result before printing it.
---

# Filter And Order Drill

## Prompt

Create a small list of four study attempt objects with a `Title`, `Score`, and `Completed` flag.

Then write one query that:

1. keeps only the completed attempts
2. orders them from highest score to lowest score
3. prints the titles in that order

## Constraints

- Keep the drill to one list and one query.
- Use LINQ instead of manual loops for the query.
- Print the result in score order.

## Hints

- `Where` filters the list.
- `OrderByDescending` can sort by score.
- `Select` can keep only the title if that is all you want to print.

## Verification

The drill is complete when the printed titles are limited to completed items and appear in descending score order.

## Extension Ideas

- Add a tie score and break it with `ThenBy`.
- Print both the title and the score.