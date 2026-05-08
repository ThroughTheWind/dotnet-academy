# Tests

This directory contains automated tests for runnable samples and, later, integrated solutions.

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

## Conventions

- Keep test projects aligned to the same stage and topic structure used by `src/`.
- Prefer xUnit unless a later module has a strong teaching reason to compare frameworks.
- Make test names readable and analyzer-compliant so the repository can keep warnings as errors.