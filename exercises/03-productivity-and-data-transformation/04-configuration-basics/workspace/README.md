# Workspace Guidance

Create the learner exercise project in this folder so the starter assets and your code stay together.

Suggested commands:

```bash
dotnet new console -n StudyPlannerConfigConsole
dotnet add ./StudyPlannerConfigConsole package Microsoft.Extensions.Configuration.Json
dotnet add ./StudyPlannerConfigConsole package Microsoft.Extensions.Configuration.Binder
dotnet add ./StudyPlannerConfigConsole package Microsoft.Extensions.Configuration.EnvironmentVariables
dotnet run --project ./StudyPlannerConfigConsole
```

After the first version runs, compare your behavior with `../expected-output.md`.