# Performance Review Results

**Date**: 2026-02-01 22:47:47 UTC
**Baseline**: 2026-01-25T22:44:49.182446
**Commit**: e42cff0dae9cf91322defab229db7e6f9a9cea79

## Summary

- **Total Benchmarks**: 20
- **Regressions**: 1
- **Improvements**: 0
- **Status**: ⚠️ REGRESSIONS FOUND (MINOR)

## CPU Benchmarks

| Benchmark | Baseline | Current | Change | Status |
|-----------|----------|---------|--------|--------|
| CreateSlug_Empty_String | 275.200 ns | 269.800 ns | -2.0% | ➡️  |
| CreateSlug_Long_Text_Truncated | 7891.900 ns | 7723.900 ns | -2.1% | ➡️  |
| CreateSlug_No_Trim_Separators | 1008.300 ns | 1027.900 ns | +1.9% | ➡️  |
| CreateSlug_Simple_Ascii_Default | 1100.300 ns | 1075.900 ns | -2.2% | ➡️  |
| CreateSlug_Simple_Overload_Custom | 1087.200 ns | 1081.000 ns | -0.6% | ➡️  |
| CreateSlug_Special_Chars_Default | 1777.800 ns | 1769.000 ns | -0.5% | ➡️  |
| CreateSlug_Special_Chars_Extended | 1474.800 ns | 1465.500 ns | -0.6% | ➡️  |
| CreateSlug_Underscore_Separator | 744.400 ns | 816.500 ns | +9.7% | ⚠️ MINOR |
| CreateSlug_Unicode_Text_Default | 2166.300 ns | 2192.200 ns | +1.2% | ➡️  |
| CreateSlug_Unicode_Text_Unicode_Allowed | 1850.000 ns | 1813.700 ns | -2.0% | ➡️  |
| CreateSlug_Whitespace_Only | 272.200 ns | 268.500 ns | -1.4% | ➡️  |

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

### CreateSlug_Underscore_Separator - MINOR

- **Baseline**: 744.400 ns (960 B allocated)
- **Current**: 816.500 ns (960 B allocated)
- **Change**: +9.7%
- **Recommendation**: Monitor


## Action Items

- [ ] Review regression details above
- [ ] Investigate root cause of performance degradation
- [ ] Fix regression or document justification

## Conclusion

⚠️ **1 regression(s) detected with MINOR severity.** Please review and address before baseline is updated.
