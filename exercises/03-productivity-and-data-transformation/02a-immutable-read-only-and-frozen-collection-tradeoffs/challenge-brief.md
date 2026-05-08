# Challenge Brief

Build a console app named `PublishedGuideCatalogConsole` that publishes three different collection surfaces from one underlying guide catalog.

Your app must:

- expose a live read-only view
- publish an immutable snapshot
- publish a frozen lookup for repeated keyed reads
- mutate the live catalog after publication so the differences are visible
- explain why each collection surface fits its boundary

Keep the example small enough that another learner could describe the promise each surface makes in one sentence.