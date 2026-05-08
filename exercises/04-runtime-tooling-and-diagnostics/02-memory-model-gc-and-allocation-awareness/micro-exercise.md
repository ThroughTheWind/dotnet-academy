# Micro Exercise

Take 10 minutes and answer this question without building the full exercise first.

You run a scenario that allocates 2 MB of temporary objects and then drops every reference before a full collection. After the collection, only 50 KB of managed memory from that scenario is still alive.

Write two or three sentences that explain:

1. why `allocated bytes` and `live managed memory` are different values
2. which value better answers "how much work did this scenario create for the allocator?"
3. which value better answers "how much memory is still alive now?"

Then compare your answer with the rules in `../lesson.md` and the full expected output example.