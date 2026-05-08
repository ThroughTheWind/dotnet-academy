# 02 CSharp Core

This stage builds the core language features needed to write maintainable real-world applications.

## Fastest Routes

- Learner start guide: [Start Learning](../../README.md#start-path)
- Curriculum stage map: [Curriculum Index](../README.md#stage-map)
- Review the previous stage: [01 Foundations](../01-foundations/README.md#how-to-use-this-stage)
- Jump to this stage assets: [Topic And Asset Index](#topic-and-asset-index)
- Open the first lesson: [01 Classes And Objects Lesson](./01-classes-and-objects/lesson.md)
- Open the first exercises: [01 Classes And Objects Exercises](./01-classes-and-objects/exercises.md)
- Open the first demo: [DotnetAcademy.ClassesObjectsDemo](../../../src/02-csharp-core/01-classes-and-objects/DotnetAcademy.ClassesObjectsDemo/)
- Open the integrated demo: [07 Domain Modeling Demo](../../../src/02-csharp-core/07-domain-modeling-demo/README.md)
- Open the stage lab: [08 Learning Track Domain Model Lab](../../../labs/02-csharp-core/08-learning-track-domain-model-lab/README.md)
- Continue to the next stage: [03 Productivity And Data Transformation](../03-productivity-and-data-transformation/README.md#how-to-use-this-stage)

## Outcomes

- Model behavior and data with classes, records, structs, enums, and interfaces.
- Use composition, inheritance, generics, and exceptions appropriately.
- Apply lambdas, delegates, events, and pattern matching in practical code.

## How To Use This Stage

- Work through the six core topics in order.
- For each topic, read the overview and lesson first, attempt the exercises, then inspect the matching demo in `src/`.
- Use the integrated demo after the core topics when you want to see how the features fit together in one reference solution.
- Use the stage exercise pack and guided lab after the core topics when you are ready to justify design choices and build a learner project.

## Topic Sequence

- 01 Classes and objects
- 02 Records, structs, and enums
- 03 Interfaces and dependency boundaries
- 04 Inheritance basics
- 05 Generics, collections, and exceptions
- 06 Lambdas, delegates, events, and pattern matching

## Topic And Asset Index

Each Demo link opens a runnable reference implementation under `src/`.

| Topic | Overview | Lesson | Exercises | Demo | Tests |
| --- | --- | --- | --- | --- | --- |
| 01 Classes And Objects | [Overview](./01-classes-and-objects/README.md) | [Lesson](./01-classes-and-objects/lesson.md) | [Exercises](./01-classes-and-objects/exercises.md) | [Demo](../../../src/02-csharp-core/01-classes-and-objects/DotnetAcademy.ClassesObjectsDemo/) | [Tests](../../../tests/02-csharp-core/01-classes-and-objects/DotnetAcademy.ClassesObjectsDemo.Tests/) |
| 02 Records Structs And Enums | [Overview](./02-records-structs-and-enums/README.md) | [Lesson](./02-records-structs-and-enums/lesson.md) | [Exercises](./02-records-structs-and-enums/exercises.md) | [Demo](../../../src/02-csharp-core/02-records-structs-and-enums/DotnetAcademy.RecordsStructsEnumsDemo/) | [Tests](../../../tests/02-csharp-core/02-records-structs-and-enums/DotnetAcademy.RecordsStructsEnumsDemo.Tests/) |
| 03 Interfaces And Composition | [Overview](./03-interfaces-and-composition/README.md) | [Lesson](./03-interfaces-and-composition/lesson.md) | [Exercises](./03-interfaces-and-composition/exercises.md) | [Demo](../../../src/02-csharp-core/03-interfaces-and-composition/DotnetAcademy.InterfacesCompositionDemo/) | [Tests](../../../tests/02-csharp-core/03-interfaces-and-composition/DotnetAcademy.InterfacesCompositionDemo.Tests/) |
| 04 Inheritance Basics | [Overview](./04-inheritance-basics/README.md) | [Lesson](./04-inheritance-basics/lesson.md) | [Exercises](./04-inheritance-basics/exercises.md) | [Demo](../../../src/02-csharp-core/04-inheritance-basics/DotnetAcademy.InheritanceBasicsDemo/) | [Tests](../../../tests/02-csharp-core/04-inheritance-basics/DotnetAcademy.InheritanceBasicsDemo.Tests/) |
| 05 Generics Collections And Exceptions | [Overview](./05-generics-collections-and-exceptions/README.md) | [Lesson](./05-generics-collections-and-exceptions/lesson.md) | [Exercises](./05-generics-collections-and-exceptions/exercises.md) | [Demo](../../../src/02-csharp-core/05-generics-collections-and-exceptions/DotnetAcademy.GenericsCollectionsExceptionsDemo/) | [Tests](../../../tests/02-csharp-core/05-generics-collections-and-exceptions/DotnetAcademy.GenericsCollectionsExceptionsDemo.Tests/) |
| 06 Lambdas Delegates Events And Pattern Matching | [Overview](./06-lambdas-delegates-events-and-pattern-matching/README.md) | [Lesson](./06-lambdas-delegates-events-and-pattern-matching/lesson.md) | [Exercises](./06-lambdas-delegates-events-and-pattern-matching/exercises.md) | [Demo](../../../src/02-csharp-core/06-lambdas-delegates-events-and-pattern-matching/DotnetAcademy.LambdasDelegatesEventsPatternMatchingDemo/) | [Tests](../../../tests/02-csharp-core/06-lambdas-delegates-events-and-pattern-matching/DotnetAcademy.LambdasDelegatesEventsPatternMatchingDemo.Tests/) |

## Integrated Demo

- [07 Domain Modeling Demo](../../../src/02-csharp-core/07-domain-modeling-demo/README.md) combines the Stage 2 language features into one small multi-project sample.
- Domain project: [DotnetAcademy.DomainModelingDemo](../../../src/02-csharp-core/07-domain-modeling-demo/DotnetAcademy.DomainModelingDemo/)
- Console host: [DotnetAcademy.DomainModelingDemo.Console](../../../src/02-csharp-core/07-domain-modeling-demo/DotnetAcademy.DomainModelingDemo.Console/)
- Tests: [DotnetAcademy.DomainModelingDemo.Tests](../../../tests/02-csharp-core/07-domain-modeling-demo/DotnetAcademy.DomainModelingDemo.Tests/)

## Stage Exercise Pack

- [07 Reference And Value Semantics](../../../exercises/02-csharp-core/07-reference-and-value-semantics/README.md) asks learners to justify when a shared reference, immutable record, or value-like struct is the safer design choice.
- Workspace guidance: [workspace](../../../exercises/02-csharp-core/07-reference-and-value-semantics/workspace/README.md)

## Guided Lab

- [08 Learning Track Domain Model Lab](../../../labs/02-csharp-core/08-learning-track-domain-model-lab/README.md) combines the Stage 2 language features into one learner-facing domain-modeling project.
- Starter assets: [starter](../../../labs/02-csharp-core/08-learning-track-domain-model-lab/starter/)
- Reference implementation: [solution](../../../labs/02-csharp-core/08-learning-track-domain-model-lab/solution/DotnetAcademy.LearningTrackLab/)
- Tests: [DotnetAcademy.LearningTrackLab.Tests](../../../tests/02-csharp-core/08-learning-track-domain-model-lab/DotnetAcademy.LearningTrackLab.Tests/)
