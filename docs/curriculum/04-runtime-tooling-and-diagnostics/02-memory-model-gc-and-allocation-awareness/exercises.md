---
title: 02 Memory Model GC And Allocation Awareness Exercise
stage: 04-runtime-tooling-and-diagnostics
topic: 02-memory-model-gc-and-allocation-awareness
exercise_type: guided
estimated_minutes: 75
prerequisites:
  - 02 Memory Model GC And Allocation Awareness
success_criteria:
  - Compare a transient workload with a retained workload using GC runtime APIs.
  - Explain the difference between allocated bytes and live managed memory.
  - Show how retaining objects changes the post-collection result.
---

# 02 Memory Model GC And Allocation Awareness Exercise

## Prompt

Create a console app named `StudyMemoryObservationConsole` that compares two workloads doing similar work:

1. a transient workload that creates batch objects and immediately lets them go
2. a retained workload that keeps summary objects alive after each batch

Your app must:

- report total allocated bytes for both scenarios
- report generation collection counts for both scenarios
- report live managed memory after a controlled collection step
- explain why the retained scenario keeps more memory alive conceptually even if both scenarios allocate heavily

Use the starter pack in `exercises/04-runtime-tooling-and-diagnostics/02-memory-model-gc-and-allocation-awareness/` while working.

## Constraints

- Use basic runtime GC APIs instead of external diagnostics tools for this first topic.
- Keep the workload deterministic enough that another learner can reason about the result.
- Do not introduce pooling, spans, or ref-heavy optimizations yet; those belong to later topics.
- If you force a collection to stabilize the live-memory comparison, clearly explain that it is a teaching aid rather than a production hot-path technique.

## Hints

- `GC.GetTotalAllocatedBytes` answers a different question than `GC.GetTotalMemory`.
- `GC.CollectionCount(0)`, `GC.CollectionCount(1)`, and `GC.CollectionCount(2)` let you see whether collections happened during the scenario.
- Holding summary objects in a list is a simple way to model retention.
- The same number of created objects can still lead to different live-memory results when one scenario retains references.

## Verification

The exercise is complete when the learner can show all of the following:

- the project builds and runs successfully
- both scenarios print allocation and collection data
- the output distinguishes cumulative allocation from post-collection live memory
- the explanation calls out why the retained workload changes the memory story

## Extension Ideas

- Add a third scenario that keeps only one summary per category instead of every batch summary.
- Compare a small workload and a larger workload to see how the reported numbers scale.
- Add one short note about which future tooling topic would help confirm the observations in a larger program.

## Micro Exercise

For a 10-minute focused drill, use `exercises/04-runtime-tooling-and-diagnostics/02-memory-model-gc-and-allocation-awareness/micro-exercise.md`.

This micro exercise isolates the difference between cumulative allocation and live managed memory.

