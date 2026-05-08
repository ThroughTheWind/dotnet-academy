---
title: 02 Memory Model GC And Allocation Awareness
stage: 04-runtime-tooling-and-diagnostics
topic: 02-memory-model-gc-and-allocation-awareness
level: intermediate
estimated_hours: 2
prerequisites:
  - 01 Dotnet CLI SDK Build And Packaging
  - 02 Collections And Immutability Tradeoffs
learning_outcomes:
  - Explain how managed allocations create GC work and how reachability affects reclamation.
  - Distinguish total allocated bytes from live managed memory after collection.
  - Interpret generation collection counts in the context of short-lived and retained objects.
  - Identify retention patterns that keep memory alive longer than expected.
---

# 02 Memory Model GC And Allocation Awareness

## Why This Matters

Many .NET performance problems begin long before a profiler session.

They start when code allocates more objects than expected, keeps them alive longer than intended, or confuses cumulative allocation with current memory usage.

That matters because:

1. a workload can allocate a large amount of memory even if only a small fraction stays alive
2. retained objects change what the garbage collector has to revisit and promote
3. debugging memory behavior is much easier when you can read simple allocation and collection signals first

## Concepts

### 1. Managed Objects Stay Alive While They Are Reachable

In the managed world, memory is reclaimed when objects are no longer reachable from active roots such as locals, fields, and static references.

For this first memory topic, the important mental model is:

- allocating creates work for the runtime
- retaining references keeps objects alive
- dropping references allows the garbage collector to reclaim those objects later

The next Stage 4 topic goes deeper on stack versus heap details. Here, the focus is on object lifetime and observation.

### 2. Generational GC Optimizes For Short-Lived Objects

The .NET garbage collector assumes that many objects die young.

That is why it tracks younger generations separately from longer-lived objects.

In practice, that means:

- short-lived allocations often disappear after younger-generation collections
- objects that survive multiple collections can be promoted
- keeping unnecessary references alive can increase the amount of memory the runtime must revisit later

You do not need every internal GC detail to benefit from this model. You do need to know that lifetime patterns affect collection behavior.

### 3. Allocation Volume Is Not The Same As Live Memory

`GC.GetTotalAllocatedBytes` tells you how much managed allocation work happened over time.

`GC.GetTotalMemory` estimates how much managed memory is currently live.

Those numbers answer different questions:

- allocated bytes: how much managed memory was requested during the scenario
- live managed memory: how much managed memory is still alive after collection

Confusing those two values leads to bad conclusions. A workload can allocate heavily but still leave very little alive after a collection if most objects were short-lived.

### 4. Simple Runtime APIs Already Teach A Lot

For a first memory observation sample, a few runtime APIs are enough:

```csharp
var allocatedBytes = GC.GetTotalAllocatedBytes(precise: true);
var gen0Collections = GC.CollectionCount(0);
var liveManagedBytes = GC.GetTotalMemory(forceFullCollection: false);
```

These APIs do not replace profiling tools, but they let you ask clear questions:

- did this workload allocate more than I expected?
- did collections happen while it ran?
- how much memory still looks alive after I finish the scenario?

### 5. Compare Transient And Retained Workloads Directly

The easiest first experiment is to run two similar workloads:

- one that creates temporary objects and lets them go
- one that keeps summary objects alive in a retained list

If both scenarios do similar work but one retains data longer, the live-memory story changes even when the creation loop looks almost identical.

That comparison turns memory behavior into something concrete instead of mystical.

## Demo

The runnable sample for this topic lives at:

`src/04-runtime-tooling-and-diagnostics/02-memory-model-gc-and-allocation-awareness/DotnetAcademy.MemoryGcAllocationDemo/`

Run it from the repository root:

```powershell
dotnet run --project ./src/04-runtime-tooling-and-diagnostics/02-memory-model-gc-and-allocation-awareness/DotnetAcademy.MemoryGcAllocationDemo
```

Expected result:

- the sample compares a transient workload against a retained-summary workload
- it reports total allocated bytes and collection counts for both scenarios
- it shows live managed memory after a forced collection step used only for observation
- it explains why retained objects keep more memory alive after the work is done

## Common Mistakes

- Treating total allocated bytes as if they were the same thing as current live memory.
- Assuming all garbage collections are automatically a bug instead of asking what workload caused them.
- Keeping references alive in caches or lists without realizing they change post-collection memory.
- Forcing collections in production code because a demo used them for controlled observation.
- Jumping straight to advanced tools before the basic memory questions are clear.

## Exercises

Use `exercises.md` for the guided exercise.

The starter pack for this topic lives under:

`exercises/04-runtime-tooling-and-diagnostics/02-memory-model-gc-and-allocation-awareness/`

It includes a workspace folder, a challenge brief, expected output examples, and a short micro drill focused on allocation volume versus live memory.

## Verification

This topic is successful when the learner can do all of the following:

- explain why retained objects can keep live memory elevated after a collection
- describe the difference between allocation volume and live memory
- show how `GC.CollectionCount` changes during a small workload
- explain why the sample forces collection only as a teaching aid, not as a production recommendation

