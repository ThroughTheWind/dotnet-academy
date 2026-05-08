# 03 Productivity And Data Transformation

This stage focuses on the everyday language and library features that make .NET productive.

## Fastest Routes

- Learner start guide: [Start Learning](../../README.md#start-path)
- Curriculum stage map: [Curriculum Index](../README.md#stage-map)
- Review the previous stage: [02 CSharp Core](../02-csharp-core/README.md#how-to-use-this-stage)
- Jump to this stage assets: [Topic And Asset Index](#topic-and-asset-index)
- Open the integrated sample: [06 Integrated Transformation Sample](../../../src/03-productivity-and-data-transformation/06-integrated-transformation-sample/README.md)
- Open the stage exercise pack: [07 Imperative Versus LINQ Comparison](../../../exercises/03-productivity-and-data-transformation/07-imperative-versus-linq-comparison/README.md)
- Open the async flow comparison pack: [07A Synchronous Asynchronous Streaming Flow Comparison](../../../exercises/03-productivity-and-data-transformation/07a-synchronous-asynchronous-and-streaming-flow-comparison/README.md)
- Open the guided lab: [08 Study Digest Pipeline Lab](../../../labs/03-productivity-and-data-transformation/08-study-digest-pipeline-lab/README.md)
- Open the first lesson: [01 LINQ Fundamentals And Query Thinking Lesson](./01-linq-fundamentals-and-query-thinking/lesson.md)
- Open the first exercises: [01 LINQ Fundamentals And Query Thinking Exercises](./01-linq-fundamentals-and-query-thinking/exercises.md)
- Open the first demo: [DotnetAcademy.LinqQueryThinkingDemo](../../../src/03-productivity-and-data-transformation/01-linq-fundamentals-and-query-thinking/DotnetAcademy.LinqQueryThinkingDemo/)
- Continue to the next stage: [04 Runtime Tooling And Diagnostics](../04-runtime-tooling-and-diagnostics/README.md)

Stage 3 is implemented today. Topics 01, 02, 02A, 03, 04, 05, and 05A are ready now, the integrated sample is ready now, both comparison exercise packs are ready now, and the guided lab is ready now.

## Outcomes

- Transform data with LINQ clearly and efficiently.
- Work with files, JSON, configuration, and modern collection APIs effectively.
- Use async, await, cancellation, and streaming patterns correctly in small and medium-sized applications.

## How To Use This Stage

- Work through the implemented topics in order.
- For each implemented topic, read the overview and lesson first, attempt the exercises, then inspect the matching demo in `src/`.
- Use the integrated demo after the core topics when you want one sample that combines files, configuration, collections, LINQ shaping, and asynchronous source loading.
- Use the stage exercise packs after the core topics when you want to compare both data-shaping styles and flow-control styles against the same requirements.
- Use the guided lab after the topics, integrated demo, and comparison packs when you want one learner project that combines the full Stage 3 toolset.

## Topic Sequence

- 01 LINQ fundamentals and query thinking
- 02 Collections and immutability tradeoffs
- 02A Immutable, read-only, and frozen collection tradeoffs
- 03 File I/O and serialization
- 04 Configuration basics
- 05 Async and await foundations
- 05A Cancellation, async streams, and `ValueTask` tradeoffs

## Topic And Asset Index

Each Demo link opens a runnable reference implementation under `src/`.

| Topic | Overview | Lesson | Exercises | Demo | Tests |
| --- | --- | --- | --- | --- | --- |
| 01 LINQ Fundamentals And Query Thinking | [Overview](./01-linq-fundamentals-and-query-thinking/README.md) | [Lesson](./01-linq-fundamentals-and-query-thinking/lesson.md) | [Exercises](./01-linq-fundamentals-and-query-thinking/exercises.md) | [Demo](../../../src/03-productivity-and-data-transformation/01-linq-fundamentals-and-query-thinking/DotnetAcademy.LinqQueryThinkingDemo/) | [Tests](../../../tests/03-productivity-and-data-transformation/01-linq-fundamentals-and-query-thinking/DotnetAcademy.LinqQueryThinkingDemo.Tests/) |
| 02 Collections And Immutability Tradeoffs | [Overview](./02-collections-and-immutability-tradeoffs/README.md) | [Lesson](./02-collections-and-immutability-tradeoffs/lesson.md) | [Exercises](./02-collections-and-immutability-tradeoffs/exercises.md) | [Demo](../../../src/03-productivity-and-data-transformation/02-collections-and-immutability-tradeoffs/DotnetAcademy.CollectionsTradeoffsDemo/) | [Tests](../../../tests/03-productivity-and-data-transformation/02-collections-and-immutability-tradeoffs/DotnetAcademy.CollectionsTradeoffsDemo.Tests/) |
| 02A Immutable Read Only And Frozen Collection Tradeoffs | [Overview](./02a-immutable-read-only-and-frozen-collection-tradeoffs/README.md) | [Lesson](./02a-immutable-read-only-and-frozen-collection-tradeoffs/lesson.md) | [Exercises](./02a-immutable-read-only-and-frozen-collection-tradeoffs/exercises.md) | [Demo](../../../src/03-productivity-and-data-transformation/02a-immutable-read-only-and-frozen-collection-tradeoffs/DotnetAcademy.ReadOnlyImmutableFrozenCollectionsDemo/) | [Tests](../../../tests/03-productivity-and-data-transformation/02a-immutable-read-only-and-frozen-collection-tradeoffs/DotnetAcademy.ReadOnlyImmutableFrozenCollectionsDemo.Tests/) |
| 03 File IO JSON And Serialization | [Overview](./03-file-io-json-and-serialization/README.md) | [Lesson](./03-file-io-json-and-serialization/lesson.md) | [Exercises](./03-file-io-json-and-serialization/exercises.md) | [Demo](../../../src/03-productivity-and-data-transformation/03-file-io-json-and-serialization/DotnetAcademy.FileIoJsonSerializationDemo/) | [Tests](../../../tests/03-productivity-and-data-transformation/03-file-io-json-and-serialization/DotnetAcademy.FileIoJsonSerializationDemo.Tests/) |
| 04 Configuration Basics | [Overview](./04-configuration-basics/README.md) | [Lesson](./04-configuration-basics/lesson.md) | [Exercises](./04-configuration-basics/exercises.md) | [Demo](../../../src/03-productivity-and-data-transformation/04-configuration-basics/DotnetAcademy.ConfigurationBasicsDemo/) | [Tests](../../../tests/03-productivity-and-data-transformation/04-configuration-basics/DotnetAcademy.ConfigurationBasicsDemo.Tests/) |
| 05 Async And Await Foundations | [Overview](./05-async-and-await-foundations/README.md) | [Lesson](./05-async-and-await-foundations/lesson.md) | [Exercises](./05-async-and-await-foundations/exercises.md) | [Demo](../../../src/03-productivity-and-data-transformation/05-async-and-await-foundations/DotnetAcademy.AsyncAwaitFoundationsDemo/) | [Tests](../../../tests/03-productivity-and-data-transformation/05-async-and-await-foundations/DotnetAcademy.AsyncAwaitFoundationsDemo.Tests/) |
| 05A Cancellation Async Streams And ValueTask Tradeoffs | [Overview](./05a-cancellation-async-streams-and-valuetask-tradeoffs/README.md) | [Lesson](./05a-cancellation-async-streams-and-valuetask-tradeoffs/lesson.md) | [Exercises](./05a-cancellation-async-streams-and-valuetask-tradeoffs/exercises.md) | [Demo](../../../src/03-productivity-and-data-transformation/05a-cancellation-async-streams-and-valuetask-tradeoffs/DotnetAcademy.CancellationAsyncStreamsValueTaskDemo/) | [Tests](../../../tests/03-productivity-and-data-transformation/05a-cancellation-async-streams-and-valuetask-tradeoffs/DotnetAcademy.CancellationAsyncStreamsValueTaskDemo.Tests/) |

## Integrated Demo

- [06 Integrated Transformation Sample](../../../src/03-productivity-and-data-transformation/06-integrated-transformation-sample/README.md) combines Stage 3 file input, configuration, collections, LINQ shaping, and asynchronous loading in one multi-project sample.
- Library project: [DotnetAcademy.IntegratedTransformationDemo](../../../src/03-productivity-and-data-transformation/06-integrated-transformation-sample/DotnetAcademy.IntegratedTransformationDemo/)
- Console host: [DotnetAcademy.IntegratedTransformationDemo.Console](../../../src/03-productivity-and-data-transformation/06-integrated-transformation-sample/DotnetAcademy.IntegratedTransformationDemo.Console/)
- Tests: [DotnetAcademy.IntegratedTransformationDemo.Tests](../../../tests/03-productivity-and-data-transformation/06-integrated-transformation-sample/DotnetAcademy.IntegratedTransformationDemo.Tests/)

## Stage Exercise Packs

- [07 Imperative Versus LINQ Comparison](../../../exercises/03-productivity-and-data-transformation/07-imperative-versus-linq-comparison/README.md) asks learners to solve the same digest-building problem once with explicit loops and once with a LINQ pipeline.
- Workspace guidance: [workspace](../../../exercises/03-productivity-and-data-transformation/07-imperative-versus-linq-comparison/workspace/README.md)
- [07A Synchronous Asynchronous Streaming Flow Comparison](../../../exercises/03-productivity-and-data-transformation/07a-synchronous-asynchronous-and-streaming-flow-comparison/README.md) asks learners to build the same digest through synchronous, asynchronous batch, and streaming control flows.
- Workspace guidance: [workspace](../../../exercises/03-productivity-and-data-transformation/07a-synchronous-asynchronous-and-streaming-flow-comparison/workspace/README.md)

## Guided Lab

- [08 Study Digest Pipeline Lab](../../../labs/03-productivity-and-data-transformation/08-study-digest-pipeline-lab/README.md) combines collections, LINQ, file input, configuration, and asynchronous loading in one learner-facing project.
- Starter pack: [starter](../../../labs/03-productivity-and-data-transformation/08-study-digest-pipeline-lab/starter/)
- Reference implementation: [solution](../../../labs/03-productivity-and-data-transformation/08-study-digest-pipeline-lab/solution/DotnetAcademy.StudyDigestPipelineLab/)
- Tests: [DotnetAcademy.StudyDigestPipelineLab.Tests](../../../tests/03-productivity-and-data-transformation/08-study-digest-pipeline-lab/DotnetAcademy.StudyDigestPipelineLab.Tests/)
