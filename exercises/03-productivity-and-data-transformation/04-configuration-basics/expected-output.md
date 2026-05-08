# Expected Output Example

Your wording can differ, but the structure should look similar to this.

```text
Configuration Basics Demo
-------------------------
Catalog name: Dotnet Academy Study Planner
Focus category: configuration
Reminder minutes: 15
Include archived: False
Provider order:
- appsettings.json
- appsettings.Development.json (optional)
- environment variables with prefix DOTNET_ACADEMY__
Configuration note: later providers override earlier values, so local or environment-specific settings can replace defaults without editing the base file.
```

The important part is that the app prints the final effective values and makes the override order explicit.