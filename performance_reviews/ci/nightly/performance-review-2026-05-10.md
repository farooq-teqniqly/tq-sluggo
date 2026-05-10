# Performance Review Results

**Date**: 2026-05-10 22:52:40 UTC
**Baseline**: 2026-04-12T22:51:10.890819
**Commit**: 923f0a80792e0123e3f990da85c5a84b6593c4d9

## Summary

- **Total Benchmarks**: 20
- **Regressions**: 1
- **Improvements**: 0
- **Status**: ⚠️ REGRESSIONS FOUND (MINOR)

## CPU Benchmarks

| Benchmark | Baseline | Current | Change | Status |
|-----------|----------|---------|--------|--------|
| CreateSlug_Empty_String | 264.800 ns | 269.200 ns | +1.7% | ➡️  |
| CreateSlug_Long_Text_Truncated | 7782.800 ns | 7823.400 ns | +0.5% | ➡️  |
| CreateSlug_No_Trim_Separators | 991.200 ns | 1068.100 ns | +7.8% | ⚠️ MINOR |
| CreateSlug_Simple_Ascii_Default | 1087.500 ns | 1082.600 ns | -0.5% | ➡️  |
| CreateSlug_Simple_Overload_Custom | 1066.300 ns | 1076.200 ns | +0.9% | ➡️  |
| CreateSlug_Special_Chars_Default | 1792.000 ns | 1798.800 ns | +0.4% | ➡️  |
| CreateSlug_Special_Chars_Extended | 1461.000 ns | 1467.800 ns | +0.5% | ➡️  |
| CreateSlug_Underscore_Separator | 739.500 ns | 739.600 ns | +0.0% | ➡️  |
| CreateSlug_Unicode_Text_Default | 2233.700 ns | 2186.300 ns | -2.1% | ➡️  |
| CreateSlug_Unicode_Text_Unicode_Allowed | 1830.900 ns | 1843.400 ns | +0.7% | ➡️  |
| CreateSlug_Whitespace_Only | 272.900 ns | 274.400 ns | +0.5% | ➡️  |

## Memory Benchmarks

| Benchmark | Baseline | Current | Alloc Change | Gen0/1 | Status |
|-----------|----------|---------|--------------|--------|--------|
| BulkCreateSlugs_Default_Options | 1,908,408 B | 1,908,408 B | 0.0% | 113.3/25.4 | ➡️  |
| BulkCreateSlugs_Extended_Chars | 1,908,408 B | 1,908,408 B | 0.0% | 113.3/25.4 | ➡️  |
| BulkCreateSlugs_Unicode_Allowed | 1,908,408 B | 1,908,408 B | 0.0% | 113.3/25.4 | ➡️  |
| Chained_Slug_Operations | 9,531,555 B | 9,531,555 B | 0.0% | 562.5/132.8 | ➡️  |
| Create_New_Options_Instance | 2,915,041 B | 2,915,041 B | 0.0% | 171.9/39.1 | ➡️  |
| Filter_And_Store_Slugs_With_Linq | 2,915,041 B | 2,915,041 B | 0.0% | 171.9/39.1 | ➡️  |
| Process_Large_Payload | 5,274,337 B | 5,274,337 B | 0.0% | 312.5/179.7 | ➡️  |
| Reuse_Options_Instance | 1,908,408 B | 1,908,408 B | 0.0% | 113.3/27.3 | ➡️  |
| StoreSlugs_In_Dictionary | 2,936,012 B | 2,936,012 B | 0.0% | 171.9/19.5 | ➡️  |

## Regressions

### CreateSlug_No_Trim_Separators - MINOR

- **Baseline**: 991.200 ns (1,248 B allocated)
- **Current**: 1068.100 ns (1,248 B allocated)
- **Change**: +7.8%
- **Recommendation**: Monitor


## Action Items

- [ ] Review regression details above
- [ ] Investigate root cause of performance degradation
- [ ] Fix regression or document justification

## Conclusion

⚠️ **1 regression(s) detected with MINOR severity.** Please review and address before baseline is updated.
