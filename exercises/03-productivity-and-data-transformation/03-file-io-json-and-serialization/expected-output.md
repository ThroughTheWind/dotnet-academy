# Expected Output Example

Your wording can differ, but the structure should look similar to this.

```text
Study Session Export Demo
-------------------------
Loaded file: study-sessions.json
Sessions loaded: 4
Completed sessions: 3
Total minutes: 81
Category summary:
- file io: 2 sessions, 42 min
- json: 1 sessions, 14 min
- serialization: 1 sessions, 25 min
Generated files:
- generated\study-session-summary.json
- generated\study-session-report.txt
```

The important part is that the app reads a source file, transforms the data, and writes two generated outputs.