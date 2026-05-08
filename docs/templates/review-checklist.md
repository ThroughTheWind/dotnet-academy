# Review Checklist

Use this checklist before marking a lesson, exercise, lab, or code slice as done.

## How To Use It

- Treat every unchecked required item as a reason to keep the backlog item open.
- Mark items as not applicable only when the asset type genuinely does not need them.
- Run the smallest meaningful validation first, then finish with repository validation before closing a substantial slice.

## Review Rubric

| Result | Meaning | Action |
| --- | --- | --- |
| pass | The asset is clear, complete, and verifiable. | Safe to keep and ship. |
| revise | The asset mostly works but still has a local gap. | Fix the gap before marking the slice done. |
| blocked | A required element is missing or validation failed. | Do not close the backlog item. |

## Lesson Checklist

- [ ] Frontmatter includes stage, topic, level, prerequisites, learning outcomes, and estimated time.
- [ ] The lesson explains why the topic matters before going deep on mechanics.
- [ ] Concepts progress in a learner-friendly order without skipping essential context.
- [ ] The lesson links to a real demo or reference implementation when code is part of the topic.
- [ ] Verification tells the learner how to confirm understanding or correct behavior.

## Exercise Checklist

- [ ] The exercise type and time estimate are explicit.
- [ ] Success criteria are concrete enough to evaluate.
- [ ] The prompt stays within the stated prerequisites.
- [ ] Constraints and hints support the learner without replacing the work.
- [ ] Verification uses tests, expected output, or clear manual checks.

## Lab Checklist

- [ ] The lab combines previously taught topics instead of introducing unrelated new concepts.
- [ ] Starter assets and reference solution assets are clearly separated.
- [ ] Milestones encourage small runnable checkpoints instead of one large jump.
- [ ] Verification includes run commands or other end-to-end checks.
- [ ] The lab README explains where starter assets, reference code, and tests live.

## Code Sample Checklist

- [ ] The project builds on the current target framework and follows shared repository conventions.
- [ ] Names and output are descriptive enough for the intended learner level.
- [ ] Nullability, parsing, formatting, and other platform-sensitive behaviors follow current .NET guidance.
- [ ] Tests exist when the sample is intended to stay stable and reusable, or manual verification is documented when tests are not appropriate.
- [ ] The code supports the teaching goal without introducing unexplained complexity.

## Slice Completion Checklist

- [ ] Relevant README, roadmap, backlog, or index pages link to the new asset.
- [ ] A focused validation step has been run for the touched slice.
- [ ] Repository validation has been run after substantial changes.
- [ ] Backlog status and the next logical slice are updated.
- [ ] Conventions or contributor docs were updated if the slice introduced a new pattern.