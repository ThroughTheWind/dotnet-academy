# Challenge Brief

Build a console app named `LearningTrackPlannerConsole` that models a learner track with specialized item types.

Your app must:

- use one shared abstraction for the track items
- choose a value-like type for one small immutable value
- store the items through a generic catalog or planner collection
- raise one event when an item is scheduled
- describe the items with pattern matching
- print a clear note when a lookup fails at the boundary

The goal is to make the type choices and the control flow easy to defend.