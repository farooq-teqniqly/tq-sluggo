# Performance Review Results

**Date**: 2026-04-19 22:51:16 UTC
**Baseline**: 2026-04-12T22:51:10.890819
**Commit**: 8a30538d8881838ce86e9cb80be61fa77ba87cc9

## Summary

- **Total Benchmarks**: 20
- **Regressions**: 1
- **Improvements**: 0
- **Status**: ⚠️ REGRESSIONS FOUND (CRITICAL)

## CPU Benchmarks

| Benchmark | Baseline | Current | Change | Status |
|-----------|----------|---------|--------|--------|
| CreateSlug_Empty_String | 264.800 ns | 319.400 ns | +20.6% | ⚠️ CRITICAL |
| CreateSlug_Long_Text_Truncated | 7782.800 ns | 7724.800 ns | -0.7% | ➡️  |
| CreateSlug_No_Trim_Separators | 991.200 ns | 984.900 ns | -0.6% | ➡️  |
| CreateSlug_Simple_Ascii_Default | 1087.500 ns | 1063.400 ns | -2.2% | ➡️  |
| CreateSlug_Simple_Overload_Custom | 1066.300 ns | 1089.400 ns | +2.2% | ➡️  |
| CreateSlug_Special_Chars_Default | 1792.000 ns | 1823.400 ns | +1.8% | ➡️  |
| CreateSlug_Special_Chars_Extended | 1461.000 ns | 1452.200 ns | -0.6% | ➡️  |
| CreateSlug_Underscore_Separator | 739.500 ns | 734.300 ns | -0.7% | ➡️  |
| CreateSlug_Unicode_Text_Default | 2233.700 ns | 2142.500 ns | -4.1% | ➡️  |
| CreateSlug_Unicode_Text_Unicode_Allowed | 1830.900 ns | 1833.700 ns | +0.2% | ➡️  |
| CreateSlug_Whitespace_Only | 272.900 ns | 272.000 ns | -0.3% | ➡️  |

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

### CreateSlug_Empty_String - CRITICAL

- **Baseline**: 264.800 ns (976 B allocated)
- **Current**: 319.400 ns (976 B allocated)
- **Change**: +20.6%
- **Recommendation**: Fix before merge


## Action Items

- [ ] Review regression details above
- [ ] Investigate root cause of performance degradation
- [ ] Fix regression or document justification

## Conclusion

⚠️ **1 regression(s) detected with CRITICAL severity.** Please review and address before baseline is updated.
