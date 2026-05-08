# Challenge Brief

Build a console app named `StudyPlannerConfigConsole` that loads a small settings object from layered configuration sources.

Your app must:

- read defaults from a base JSON file
- override at least one value with a later source
- bind the final values into an options object
- validate the settings before use
- explain in the output which source won for one setting

Keep the design small enough that another learner can point to the provider order, the bound section, and the final effective values clearly.