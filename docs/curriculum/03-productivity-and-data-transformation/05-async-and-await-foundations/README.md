# 05 Async And Await Foundations

## Goal

This topic teaches the learner how to model non-blocking work with `Task`, use `async` and `await` clearly, and compose independent asynchronous operations before moving into cancellation or streaming tradeoffs.

By the end of the topic, the learner should be able to:

- explain what a `Task` represents and why `await` is different from blocking
- write small asynchronous methods that return `Task` or `Task<T>`
- start multiple independent operations and await them together with `Task.WhenAll`
- keep the first async examples readable without mixing in cancellation, async streams, or `ValueTask`

## Deliverables

- `lesson.md` contains the teaching material for async and await foundations.
- `exercises.md` contains a guided exercise for asynchronously gathering and printing a study digest.
- Runnable sample project: `src/03-productivity-and-data-transformation/05-async-and-await-foundations/DotnetAcademy.AsyncAwaitFoundationsDemo/`.
- Learner starter assets: `exercises/03-productivity-and-data-transformation/05-async-and-await-foundations/`.
- Automated tests: `tests/03-productivity-and-data-transformation/05-async-and-await-foundations/DotnetAcademy.AsyncAwaitFoundationsDemo.Tests/`.

## Status

- Lesson bundle authored
- Runnable sample added
- Starter assets added
- Tests added
