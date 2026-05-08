# 02 Collections And Immutability Tradeoffs

## Goal

This topic teaches the learner how to choose the right collection for the job and how to decide where mutation should stop so published results stay stable.

By the end of the topic, the learner should be able to:

- choose between `List<T>`, `Dictionary<TKey, TValue>`, and `HashSet<T>` based on access patterns
- explain why mutable working state and published read models often need different shapes
- create stable snapshots for reporting instead of leaking live mutable state
- recognize that read-only APIs help at boundaries but are not the same as deep immutability

## Deliverables

- `lesson.md` contains the teaching material for collection choice and mutation boundaries.
- `exercises.md` contains a guided exercise for building a planning board with stable snapshots.
- Runnable sample project: `src/03-productivity-and-data-transformation/02-collections-and-immutability-tradeoffs/DotnetAcademy.CollectionsTradeoffsDemo/`.
- Learner starter assets: `exercises/03-productivity-and-data-transformation/02-collections-and-immutability-tradeoffs/`.
- Automated tests: `tests/03-productivity-and-data-transformation/02-collections-and-immutability-tradeoffs/DotnetAcademy.CollectionsTradeoffsDemo.Tests/`.

## Status

- Lesson bundle authored
- Runnable sample added
- Starter assets added
- Tests added
