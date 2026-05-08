# Study Digest Pipeline Lab Checklist

- [ ] The app runs from the command line with `dotnet run`.
- [ ] The learner name comes from the first command-line argument, with a safe fallback.
- [ ] The lab loads study work items from a JSON file asynchronously.
- [ ] At least one additional asynchronous source contributes items to the digest.
- [ ] Collections and LINQ are both used to shape the final digest.
- [ ] The solution writes a JSON summary file and a text report.
- [ ] Settings or configuration are kept separate from the transformation logic.
- [ ] The output structure is close to `starter/expected-output.md`.
- [ ] The learner can explain why loading and shaping are separate steps.
- [ ] The app was re-run after each meaningful change instead of being edited blindly.