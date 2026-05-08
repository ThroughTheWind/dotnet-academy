# Expected Output Example

Your wording can differ, but the structure should look similar to this.

```text
.NET CLI, SDK, Build, And Packaging Demo
----------------------------------------
SDK pin: 10.0.102 (rollForward: latestFeature)
Sample project: DotnetAcademy.ToolingSample
Target framework: net10.0
Output type: Library
Package ID: DotnetAcademy.ToolingSample
Packable: True
Release output: bin/Release/net10.0
Expected package artifact: DotnetAcademy.ToolingSample.1.2.0.nupkg
Command flow:
- Verify SDK: dotnet --version
- Restore dependencies: dotnet restore <project-or-solution>
- Build Release output: dotnet build <project-or-solution> -c Release
- Run automated tests: dotnet test <test-project-or-solution> -c Release --no-build
- Pack the library: dotnet pack <library-project> -c Release --no-build --output ./artifacts/packages
Packaging note: pack is appropriate here because the sample project is a reusable library with a PackageId, a Version, and IsPackable set to true.
```

The important part is that the app prints a meaningful command flow and makes the packaging decision explicit.