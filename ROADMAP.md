# Roadmap

This roadmap defines the initial v1 learning path for Dotnet Academy. The goal is not only to teach syntax, but to build the habits, system understanding, and engineering judgment needed to become a strong senior .NET developer.

For implementation tracking, sequencing, and end-to-end delivery status, use `BACKLOG.md` alongside this roadmap.

## Principles

- Start with fundamentals, but always move toward production-grade thinking.
- Pair theory with runnable demos, exercises, labs, and capstones.
- Teach the platform as a system: language, runtime, libraries, frameworks, tooling, and delivery.
- Prefer current .NET guidance and current platform defaults over legacy patterns unless teaching migration explicitly.

## Stage Map

### Stage 1: Foundations

- Programming mindset and tooling
- C# syntax, variables, expressions, control flow, methods
- Types, nullability, debugging basics

### Stage 2: Core C#

- Classes, objects, records, structs, enums
- Interfaces, inheritance, composition
- Generics, collections, exception handling
- Delegates, events, lambdas, pattern matching

### Stage 3: Productivity and Data Transformation

- LINQ fundamentals and query thinking
- Working with collections and immutability tradeoffs
- File I/O, serialization, configuration basics
- Async and await foundations

### Stage 4: Runtime, Tooling, and Diagnostics

- .NET CLI, SDK layout, build pipeline, package management
- Memory model, garbage collection, spans, allocations
- Logging, metrics, tracing, debugging, profiling
- Concurrency, cancellation, and resilience basics

### Stage 5: Data and Persistence

- Relational modeling and SQL fundamentals for .NET developers
- EF Core basics and advanced usage
- Migrations, query performance, transactions
- Caching strategies and tradeoffs

### Stage 6: ASP.NET Core Foundations

- Hosting model, middleware, routing, DI, configuration
- Options pattern, logging, environment configuration
- Validation, error handling, and secure defaults

### Stage 7: API Development

- REST API design and versioning
- Minimal APIs and controllers
- Authentication and authorization
- OpenAPI, contract design, pagination, filtering
- gRPC services and SignalR for real-time communication

### Stage 8: Blazor

- Components, parameters, rendering, forms, and validation
- State management and data loading
- Authentication and authorization in UI flows
- Integrating Blazor with APIs and real-world application structure

### Stage 9: Testing and Quality

- Unit, integration, and end-to-end testing
- xUnit and ASP.NET Core testing patterns
- Test doubles, fixtures, and maintainable test suites
- Static analysis and code quality gates

### Stage 10: Performance and Memory Optimization

- Measuring before optimizing
- Allocation analysis and hot path tuning
- Async throughput, backpressure, and scalability
- API, database, and caching performance patterns

### Stage 11: Architecture and Delivery

- Layered architecture, vertical slice architecture, and modular monolith patterns
- SOLID in practice and its limits
- Domain boundaries, messaging, and system design basics
- Deployment, configuration, observability, and release concerns

### Stage 12: Capstone

- End-to-end system design and implementation
- API, data access, caching, background processing, and Blazor UI
- Documentation, testing, performance review, and production hardening

## Done Definition For A Stage

A stage is only complete when it includes:

- Stage overview and learning objectives
- One or more lessons
- Runnable demos in `src/`
- Exercises in `exercises/`
- At least one guided lab where appropriate
- Verification steps and expected outcomes
