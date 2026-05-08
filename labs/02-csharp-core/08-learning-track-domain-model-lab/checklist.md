# Learning Track Domain Model Lab Checklist

- [ ] The app runs from the command line with `dotnet run`.
- [ ] The learner name comes from the first command-line argument, with a safe fallback.
- [ ] The model includes one shared abstraction and at least two specialized item types.
- [ ] The lab uses one value-like type where copy semantics are intentional.
- [ ] A generic catalog or planner collection stores the track items.
- [ ] The lab raises one event when an item is scheduled.
- [ ] Pattern matching is used to build readable summary output.
- [ ] One invalid lookup or duplicate entry is handled with a clear boundary note.
- [ ] The output structure is close to `starter/expected-output.md`.
- [ ] The app was re-run after each meaningful change instead of being edited blindly.