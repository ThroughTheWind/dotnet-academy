# Expected Output Example

Your wording can differ, but the structure should look similar to this.

```text
Guide Catalog Publication Demo
------------------------------
Read-only view count after live update: 4
Immutable snapshot count: 3
Frozen lookup count: 3
Frozen category set contains 'frozen': False
Read-only latest item: GUIDE-04 => Build a frozen category index
Immutable snapshot still ends with: GUIDE-03 => Freeze repeated lookups after configuration loads
Frozen lookup contains guide-02: True
Frozen lookup contains GUIDE-04: False
```

The important part is that the three published surfaces make visibly different promises after the live source changes.