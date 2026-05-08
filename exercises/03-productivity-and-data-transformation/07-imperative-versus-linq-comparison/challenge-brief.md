# Challenge Brief

Build a console app named `StudyDigestComparisonConsole` that produces the same study digest twice: once with explicit loops and mutable accumulators, and once with a LINQ-based transformation pipeline.

Your app must:

- start from one shared in-memory collection of study work items
- build one focus list and one category summary with an imperative implementation
- build the same focus list and category summary with a LINQ implementation
- show that both approaches produce the same final results
- print a short note explaining when the imperative version felt clearer and when the LINQ version felt clearer

The key requirement is not only to make both versions run, but to compare the tradeoffs in plain language.