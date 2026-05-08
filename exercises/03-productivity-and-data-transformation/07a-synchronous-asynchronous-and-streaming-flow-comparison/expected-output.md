# Expected Output Example

Your wording can differ, but the structure should look similar to this.

```text
Synchronous Asynchronous Streaming Comparison
--------------------------------------------
Synchronous digest:
- Items loaded: 4
- Focus items: 3
Asynchronous digest:
- Items loaded: 4
- Focus items: 3
Streaming digest:
- Items loaded: 4
- Focus items: 3
Flow note: synchronous code stayed simplest when the data was already local, asynchronous batching fit independent delayed sources, and streaming fit values that arrived gradually without needing the whole collection up front.
```

The important part is that the learner can explain why the three flows have different control structures even when they produce the same final answer.