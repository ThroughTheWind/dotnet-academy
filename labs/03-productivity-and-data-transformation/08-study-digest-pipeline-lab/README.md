# 08 Study Digest Pipeline Lab

This guided lab is the integrated Stage 3 project. It combines collections, LINQ shaping, file-based JSON input, asynchronous source loading, and persisted output in one small console application.

## Outcomes

- load study work items from a JSON file asynchronously
- combine file-based and delayed in-memory sources into one collection
- use LINQ to build a category summary and a focus list
- write both a JSON summary file and a text report after the transformation completes
- keep configuration, loading, shaping, and output concerns separated enough to explain clearly

## Contents

- `lab.md` guides the learner through the integrated task.
- `checklist.md` gives a completion checklist.
- `starter/` contains the lab starter assets and workspace guidance.
- `solution/DotnetAcademy.StudyDigestPipelineLab/` contains a runnable reference implementation.
- `tests/03-productivity-and-data-transformation/08-study-digest-pipeline-lab/DotnetAcademy.StudyDigestPipelineLab.Tests/` verifies the reference implementation.

## Run The Reference Implementation

```bash
dotnet run --project ./labs/03-productivity-and-data-transformation/08-study-digest-pipeline-lab/solution/DotnetAcademy.StudyDigestPipelineLab -- Ada
```