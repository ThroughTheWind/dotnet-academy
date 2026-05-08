# Challenge Brief

Build a console app named `StudyDigestAsyncConsole` that gathers module progress from several asynchronous sources and prints a readable digest.

Your app must:

- model source work with `Task<T>`
- start multiple independent operations
- await them together with `Task.WhenAll`
- print the completed results after they finish
- explain why the solution avoids blocking

Keep the design small enough that another learner can point to the asynchronous boundary and the post-await formatting step separately.