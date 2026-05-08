# Tests

This directory contains automated tests for runnable demos and, later, integrated solutions.

## Current Coverage

- `tests/01-foundations/01-development-environment-and-cli/DotnetAcademy.CliBasicsDemo.Tests/` verifies the first CLI basics sample.
- `tests/01-foundations/02-first-console-application/DotnetAcademy.FirstConsoleAppDemo.Tests/` verifies the first console application sample.
- `tests/01-foundations/03-variables-types-and-conversions/DotnetAcademy.VariablesTypesDemo.Tests/` verifies the variables, types, and conversions sample.
- `tests/01-foundations/04-control-flow-and-methods/DotnetAcademy.ControlFlowMethodsDemo.Tests/` verifies the control flow and methods sample.
- `tests/01-foundations/05-nullability-and-debugging-basics/DotnetAcademy.NullabilityDebuggingDemo.Tests/` verifies the nullability and debugging basics sample.
- `tests/01-foundations/06-study-session-planner-lab/DotnetAcademy.StudySessionPlannerLab.Tests/` verifies the first integrated Stage 1 lab reference implementation.
- `tests/02-csharp-core/01-classes-and-objects/DotnetAcademy.ClassesObjectsDemo.Tests/` verifies the first Stage 2 classes-and-objects sample.
- `tests/02-csharp-core/02-records-structs-and-enums/DotnetAcademy.RecordsStructsEnumsDemo.Tests/` verifies the second Stage 2 object-modeling sample.
- `tests/02-csharp-core/03-interfaces-and-composition/DotnetAcademy.InterfacesCompositionDemo.Tests/` verifies the first Stage 2 abstraction sample centered on interfaces and composition.
- `tests/02-csharp-core/04-inheritance-basics/DotnetAcademy.InheritanceBasicsDemo.Tests/` verifies the Stage 2 inheritance basics sample.
- `tests/02-csharp-core/05-generics-collections-and-exceptions/DotnetAcademy.GenericsCollectionsExceptionsDemo.Tests/` verifies the Stage 2 reusable code sample for generics, collections, and exception handling.
- `tests/02-csharp-core/06-lambdas-delegates-events-and-pattern-matching/DotnetAcademy.LambdasDelegatesEventsPatternMatchingDemo.Tests/` verifies the Stage 2 behavior sample for lambdas, delegates, events, and pattern matching.
- `tests/02-csharp-core/07-domain-modeling-demo/DotnetAcademy.DomainModelingDemo.Tests/` verifies the integrated Stage 2 domain-modeling sample across the shared domain project and console host.
- `tests/02-csharp-core/08-learning-track-domain-model-lab/DotnetAcademy.LearningTrackLab.Tests/` verifies the Stage 2 guided lab reference implementation.
- `tests/03-productivity-and-data-transformation/01-linq-fundamentals-and-query-thinking/DotnetAcademy.LinqQueryThinkingDemo.Tests/` verifies the first Stage 3 LINQ sample for filtering, ordering, grouping, and readable query composition.
- `tests/03-productivity-and-data-transformation/02-collections-and-immutability-tradeoffs/DotnetAcademy.CollectionsTradeoffsDemo.Tests/` verifies the second Stage 3 sample for collection choice, keyed lookup, unique category tracking, and stable published snapshots.
- `tests/03-productivity-and-data-transformation/02a-immutable-read-only-and-frozen-collection-tradeoffs/DotnetAcademy.ReadOnlyImmutableFrozenCollectionsDemo.Tests/` verifies the Stage 3 follow-up sample for live read-only views, immutable snapshots, and frozen read-heavy lookups.
- `tests/03-productivity-and-data-transformation/03-file-io-json-and-serialization/DotnetAcademy.FileIoJsonSerializationDemo.Tests/` verifies the Stage 3 file I/O sample for reading seeded JSON, transforming it into export models, and writing generated JSON and text outputs.
- `tests/03-productivity-and-data-transformation/04-configuration-basics/DotnetAcademy.ConfigurationBasicsDemo.Tests/` verifies the Stage 3 configuration sample for layered JSON settings, later-source overrides, binding, and validation.
- `tests/03-productivity-and-data-transformation/05-async-and-await-foundations/DotnetAcademy.AsyncAwaitFoundationsDemo.Tests/` verifies the Stage 3 async sample for `Task<T>`, `await`, and `Task.WhenAll` over independent sources.
- `tests/03-productivity-and-data-transformation/05a-cancellation-async-streams-and-valuetask-tradeoffs/DotnetAcademy.CancellationAsyncStreamsValueTaskDemo.Tests/` verifies the Stage 3 advanced async sample for cooperative cancellation, `await foreach`, and narrow `ValueTask<T>` cache usage.
- `tests/03-productivity-and-data-transformation/06-integrated-transformation-sample/DotnetAcademy.IntegratedTransformationDemo.Tests/` verifies the integrated Stage 3 sample for multi-source loading, LINQ shaping, configuration-driven focus rules, and persisted JSON and text outputs.
- `tests/03-productivity-and-data-transformation/08-study-digest-pipeline-lab/DotnetAcademy.StudyDigestPipelineLab.Tests/` verifies the Stage 3 guided lab reference implementation for JSON input, delayed async sources, LINQ summaries, and persisted output files.
- `tests/04-runtime-tooling-and-diagnostics/01-dotnet-cli-sdk-build-and-packaging/DotnetAcademy.DotnetCliBuildPackagingDemo.Tests/` verifies the first Stage 4 tooling sample for SDK pinning, project metadata parsing, command sequencing, and packaging decisions.

## Conventions

- Keep test projects aligned to the same stage and topic structure used by `src/`.
- Prefer xUnit unless a later module has a strong teaching reason to compare frameworks.
- Make test names readable and analyzer-compliant so the repository can keep warnings as errors.