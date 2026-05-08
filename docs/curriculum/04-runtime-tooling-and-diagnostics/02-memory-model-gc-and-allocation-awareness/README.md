# 02 Memory Model GC And Allocation Awareness

## Goal

This topic teaches the learner how managed allocations create garbage-collection work, why short-lived and retained objects behave differently, and how to observe those effects with basic runtime APIs.

By the end of the topic, the learner should be able to:

- explain that allocation volume and live memory are related but different measurements
- describe how short-lived objects usually die in younger generations while survivors can be promoted
- interpret `GC.CollectionCount`, `GC.GetTotalAllocatedBytes`, and `GC.GetTotalMemory` in a small console sample
- identify how retaining objects changes post-collection live memory compared with transient allocations

## Deliverables

- `lesson.md` contains the teaching material for memory model, garbage collection, and allocation awareness.
- `exercises.md` contains a guided exercise for comparing transient and retained workloads.
- Runnable sample project: `src/04-runtime-tooling-and-diagnostics/02-memory-model-gc-and-allocation-awareness/DotnetAcademy.MemoryGcAllocationDemo/`.
- Learner starter assets: `exercises/04-runtime-tooling-and-diagnostics/02-memory-model-gc-and-allocation-awareness/`.
- Automated tests: `tests/04-runtime-tooling-and-diagnostics/02-memory-model-gc-and-allocation-awareness/DotnetAcademy.MemoryGcAllocationDemo.Tests/`.

## Status

- Lesson bundle authored
- Runnable sample added
- Starter assets added
- Tests added
