---
title: 01 Dotnet CLI SDK Build And Packaging
stage: 04-runtime-tooling-and-diagnostics
topic: 01-dotnet-cli-sdk-build-and-packaging
level: intermediate
estimated_hours: 2
prerequisites:
  - 01 Development Environment And CLI
  - 03 File IO JSON And Serialization
learning_outcomes:
  - Explain how global.json pins SDK selection for local and CI workflows.
  - Describe the purpose and order of dotnet restore, build, test, and pack.
  - Identify the project file properties that affect package generation.
  - Predict the main build and packaging artifacts produced by a Release workflow.
---

# 01 Dotnet CLI SDK Build And Packaging

## Why This Matters

Most real .NET work happens in a loop that starts before the application runs.

You pick an SDK, restore dependencies, build artifacts, run tests, and sometimes package a reusable library for distribution.

That workflow matters because:

1. local development and CI need to agree on which SDK and commands are being used
2. build failures are easier to reason about when restore, compile, test, and packaging are kept distinct
3. package creation only makes sense for some project types, so the project file needs to describe that intent clearly

## Concepts

### 1. The SDK Controls The Toolchain

The .NET SDK is not just the compiler. It drives templates, restore behavior, build targets, test orchestration, and pack or publish operations.

When a repository commits `global.json`, it is pinning the expected SDK feature band so local machines and CI use a predictable toolchain.

```json
{
  "sdk": {
    "version": "10.0.102",
    "rollForward": "latestFeature"
  }
}
```

That file does not bundle the SDK. It only tells the CLI which installed SDK version or feature band should be selected.

### 2. Restore, Build, Test, And Pack Solve Different Problems

- `dotnet restore` resolves NuGet dependencies and project references.
- `dotnet build` compiles the project and writes artifacts such as assemblies into `bin/<Configuration>/<TargetFramework>/`.
- `dotnet test` runs automated verification, often reusing the existing build with `--no-build`.
- `dotnet pack` creates a NuGet package when the project is intended to be distributed as a library.

Treating those steps as one blurry command makes troubleshooting harder. Treating them as separate phases makes command output and failures easier to understand.

### 3. Project Properties Drive Packaging Behavior

Several common properties explain what the build should produce.

```xml
<PropertyGroup>
  <TargetFramework>net10.0</TargetFramework>
  <OutputType>Library</OutputType>
  <PackageId>DotnetAcademy.ToolingSample</PackageId>
  <Version>1.2.0</Version>
  <IsPackable>true</IsPackable>
</PropertyGroup>
```

- `TargetFramework` controls the target runtime or API surface.
- `OutputType` distinguishes library-style output from executable output.
- `PackageId` and `Version` shape the package artifact name.
- `IsPackable` makes the packaging intent explicit.

### 4. Build Artifacts And Package Artifacts Are Not The Same Thing

A Release build typically produces compiled assemblies and related runtime files.

A package step produces a `.nupkg` file for distribution.

That means a project can build successfully without being a good candidate for packing. Console apps and diagnostics experiments may build and run perfectly while still not belonging on a package feed.

### 5. Keep The First Tooling Example Concrete

This topic is about the command flow and the project metadata, not about a large application host.

Use a small console app that explains a sample project's SDK pin, build steps, and expected package artifact so the learner can focus on the tooling decisions themselves.

## Demo

The runnable sample for this topic lives at:

`src/04-runtime-tooling-and-diagnostics/01-dotnet-cli-sdk-build-and-packaging/DotnetAcademy.DotnetCliBuildPackagingDemo/`

Run it from the repository root:

```powershell
dotnet run --project ./src/04-runtime-tooling-and-diagnostics/01-dotnet-cli-sdk-build-and-packaging/DotnetAcademy.DotnetCliBuildPackagingDemo
```

Expected result:

- the sample reads a pinned SDK version from `global.json`
- it explains the project properties that make a library packable
- it prints a clear command flow for restore, build, test, and pack
- it names the expected Release output directory and package artifact

## Common Mistakes

- Treating `global.json` as if it installs the SDK instead of selecting one that is already present.
- Assuming `dotnet build` also proves correctness without running tests.
- Packing every project by habit instead of deciding whether the project is meant to be distributed as a reusable library.
- Forgetting that package names and versions come from project metadata.
- Mixing `publish` and `pack` even though they target different outcomes.

## Exercises

Use `exercises.md` for the guided exercise.

The starter pack for this topic lives under:

`exercises/04-runtime-tooling-and-diagnostics/01-dotnet-cli-sdk-build-and-packaging/`

It includes a workspace folder, a challenge brief, expected output examples, and a short micro drill focused on deciding whether a project should be packed.

## Verification

This topic is successful when the learner can do all of the following:

- explain why the repository pins an SDK version
- describe the separate responsibilities of restore, build, test, and pack
- identify at least three project properties that affect packaging behavior
- predict whether a given project should produce a `.nupkg` artifact