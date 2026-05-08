# Expected Output Example

Your wording can differ, but the structure should look similar to this.

```text
Imperative Versus LINQ Comparison
---------------------------------
Imperative focus items:
- Async digest [async]: 3 pending steps, 30 min
- JSON exports [data]: 2 pending steps, 45 min
- Configuration layering [platform]: 2 pending steps, 35 min
Imperative category summary:
- async: 1 items, 3 pending steps, 30 min
- data: 2 items, 4 pending steps, 60 min
- platform: 1 items, 2 pending steps, 35 min
LINQ focus items:
- Async digest [async]: 3 pending steps, 30 min
- JSON exports [data]: 2 pending steps, 45 min
- Configuration layering [platform]: 2 pending steps, 35 min
LINQ category summary:
- async: 1 items, 3 pending steps, 30 min
- data: 2 items, 4 pending steps, 60 min
- platform: 1 items, 2 pending steps, 35 min
Comparison note: the imperative version made each mutation step obvious, while the LINQ version made filtering, ordering, and grouping easier to scan once the pipeline was understood.
```

The important part is that both approaches produce the same results and the learner can defend the tradeoffs instead of only repeating style preferences.