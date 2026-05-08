# Issue And Branch Naming

Use backlog IDs as the source of truth for issue and branch names so planning, implementation, and review stay aligned.

## Issue Title Format

Use this shape for issues:

```text
<BACKLOG-ID>: <short imperative summary>
```

Rules:

- Keep the backlog ID uppercase exactly as it appears in `BACKLOG.md`.
- Start the summary with a verb such as `create`, `add`, `define`, or `update`.
- Keep one issue focused on one backlog item unless the backlog item was explicitly split.

Examples:

- `S02-01: create object modeling topic sequence`
- `PLAT-03: add curriculum index pages`
- `PLAT-05: define issue and branch naming conventions`

## Branch Name Format

Use this shape for branches:

```text
<track>/<backlog-id-lowercase>-<short-kebab-summary>
```

Recommended tracks:

- `content` for lessons, exercises, labs, or sample code tied to learner-facing work
- `platform` for templates, validation, navigation, contributor workflow, and repository standards
- `chore` for low-risk maintenance work that does not change the learning model directly

Rules:

- Keep the backlog ID in lowercase inside the branch name.
- Reuse the issue summary in shorter kebab-case form when practical.
- Prefer one branch per backlog item so commits, pull requests, and review comments stay easy to map.

Examples:

- `content/s01-08-study-session-planner-lab`
- `platform/plat-03-curriculum-index`
- `platform/plat-04-review-checklist`
- `content/s02-01-object-modeling-topics`

## Mapping Guidance

- Use the same backlog ID in the issue title, branch name, and pull request title whenever possible.
- If a backlog item needs a sub-slice, append a suffix consistently, such as `S02-01A` in the issue and `s02-01a` in the branch.
- If work starts as platform or docs support for a learner-facing slice, keep the learner-facing backlog ID when that work is still part of the same delivery.