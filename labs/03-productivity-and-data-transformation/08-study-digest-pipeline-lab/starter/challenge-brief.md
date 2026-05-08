# Challenge Brief

Build a console app named `StudyDigestPipelineConsole` that combines file input, asynchronous loading, LINQ shaping, and persisted output.

Your app must:

- load study work items from a JSON file
- load at least one additional asynchronous source
- combine everything into one digest with a focus list and category summary
- write one JSON summary file and one text report
- print a short note explaining why the design separates loading from shaping

The goal is to make the pipeline and the control flow easy to defend.