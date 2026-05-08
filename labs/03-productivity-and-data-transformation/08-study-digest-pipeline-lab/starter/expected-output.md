# Expected Output Example

Your wording can differ, but the structure should look similar to this.

```text
Study Digest Pipeline Lab
-------------------------
Learner: Ada
Items loaded: 5
Focus items: 4
Total minutes: 155
Category summary:
- async: 2 items, 5 pending steps, 55 min
- data: 2 items, 3 pending steps, 65 min
- platform: 1 items, 2 pending steps, 35 min
Focus list:
- Async digest [async] from mentor queue: 3 pending steps, 30 min
- JSON exports [data] from seed archive: 2 pending steps, 45 min
- Configuration layering [platform] from seed archive: 2 pending steps, 35 min
- Cancellation review [async] from mentor queue: 2 pending steps, 25 min
Output note: wrote study-digest-summary.json and study-digest-report.txt.
Flow note: load file and delayed sources first, then use LINQ to shape the combined collection before writing outputs.
Design note: keep local collections mutable while gathering data, then produce sorted summaries and persisted output from one shaped view of the data.
```

The important part is that the output proves the learner combined collections, LINQ, files, and async work in one coherent flow.