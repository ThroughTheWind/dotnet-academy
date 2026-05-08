# 08 Learning Track Domain Model Lab

This guided lab is the first integrated Stage 2 project. It combines classes, records and structs, interfaces, inheritance, generics, exceptions, delegates, events, and pattern matching in one small domain-modeling exercise.

## Outcomes

- model a small learning-track domain with a shared abstraction and specialized item types
- choose between reference and value semantics intentionally for different parts of the model
- use a generic catalog and boundary validation to keep the model consistent
- raise an event when a track item is scheduled and describe items through pattern matching

## Contents

- `lab.md` guides the learner through the integrated task.
- `checklist.md` gives a completion checklist.
- `starter/` contains the lab starter assets and workspace guidance.
- `solution/DotnetAcademy.LearningTrackLab/` contains a runnable reference implementation.
- `tests/02-csharp-core/08-learning-track-domain-model-lab/DotnetAcademy.LearningTrackLab.Tests/` verifies the reference implementation.

## Run The Reference Implementation

```bash
dotnet run --project ./labs/02-csharp-core/08-learning-track-domain-model-lab/solution/DotnetAcademy.LearningTrackLab -- Ada
```