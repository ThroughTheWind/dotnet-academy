# Expected Output Example

Your wording can differ, but the structure should look similar to this.

```text
Memory Model, GC, And Allocation Awareness Demo
-----------------------------------------------
Workload: 48 batches x 180 items
Scenario: transient batch summaries
- Created objects: 8640
- Retained summaries: 0
- Retained records represented: 0
- Total allocated bytes: 1536000
- Live managed bytes after collection: 0
- GC collections: Gen0=1 Gen1=1 Gen2=1
Scenario: retained batch summaries
- Created objects: 8640
- Retained summaries: 48
- Retained records represented: 8640
- Total allocated bytes: 1684000
- Live managed bytes after collection: 27648
- GC collections: Gen0=1 Gen1=1 Gen2=1
Observation note: total allocated bytes measure work done during the scenario, while live managed bytes show what still survives after collection.
GC note: this sample forces a full collection around each scenario only to make the live-memory comparison easier to read.
```

The important part is that the app prints both measurements and explains why retained references change the post-collection picture.