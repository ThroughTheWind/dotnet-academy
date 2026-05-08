# Challenge Brief

Build a console app named `PlanningSemanticsConsole` that models one shared course template and one copied schedule slot.

Your app must:

- use a reference type for a mutable template that should stay shared across variables
- use a value-oriented type for a small immutable schedule slot that should copy safely
- include one immutable record-style summary object for reporting
- print a short explanation of why each type choice fits the behavior you observed

The key requirement is not only to make the app run, but to defend the type choices in plain language.