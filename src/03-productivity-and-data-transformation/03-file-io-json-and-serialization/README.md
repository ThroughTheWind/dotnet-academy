# File IO JSON And Serialization Sample

This folder contains the runnable sample for the `03-file-io-json-and-serialization` topic.

## Project

- `DotnetAcademy.FileIoJsonSerializationDemo/` demonstrates reading seeded JSON from disk, transforming it in memory, and writing generated JSON and text outputs.

## Run The Sample

From the repository root:

```powershell
dotnet run --project ./src/03-productivity-and-data-transformation/03-file-io-json-and-serialization/DotnetAcademy.FileIoJsonSerializationDemo
```

## What To Observe

- the sample reads an input file copied into the build output instead of reading directly from the source tree
- the transformation builds a separate export model before serializing output
- the generated files land under the build output so the repository stays clean during validation