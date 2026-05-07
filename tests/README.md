# Tests

This directory contains automated tests for runnable samples and, later, integrated solutions.

## Current Coverage

- `tests/01-foundations/01-development-environment-and-cli/DotnetAcademy.CliBasicsDemo.Tests/` verifies the first CLI basics sample.
- `tests/01-foundations/02-first-console-application/DotnetAcademy.FirstConsoleAppDemo.Tests/` verifies the first console application sample.

## Conventions

- Keep test projects aligned to the same stage and topic structure used by `src/`.
- Prefer xUnit unless a later module has a strong teaching reason to compare frameworks.
- Make test names readable and analyzer-compliant so the repository can keep warnings as errors.