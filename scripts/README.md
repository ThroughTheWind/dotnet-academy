# Scripts

This directory contains validation and maintenance scripts for the repository.

This directory is part of the contributor workflow. Learners do not need these scripts to begin the course and should start with [docs/README.md](../docs/README.md).

Keep scripts small, predictable, and safe to run locally and in CI.

Current scripts:

- `validate-repository.ps1` checks the baseline scaffold, validates local Markdown links, validates required curriculum topic files and lesson frontmatter metadata, validates sample-data and fixture conventions, validates root solution coverage for runnable projects, restores and builds the solution or projects, and runs tests when test projects exist.
- `new-curriculum-topic.ps1` creates a topic skeleton across `docs/`, `src/`, `exercises/`, and `labs/`.

