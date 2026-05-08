# Challenge Brief

Build a console app named `StudyMemoryObservationConsole` that compares a transient workload with a retained workload.

Your app must:

- allocate a predictable batch of objects in both scenarios
- keep the transient scenario short-lived
- retain summary objects in the second scenario
- print allocated bytes, collection counts, and live managed memory after collection
- explain why cumulative allocation and live memory are different measurements

Keep the design small enough that another learner can trace each printed line back to one runtime API or one retention choice clearly.