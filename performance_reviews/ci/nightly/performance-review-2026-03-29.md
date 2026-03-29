# Performance Review Results

**Date**: 2026-03-29 22:50:08 UTC
**Baseline**: 2026-03-22T22:48:25.782249
**Commit**: a10ace7bcf9266c578b97b9fa96b951556a3ead5

## Summary

- **Total Benchmarks**: 20
- **Regressions**: 1
- **Improvements**: 0
- **Status**: ⚠️ REGRESSIONS FOUND (MINOR)

## CPU Benchmarks

| Benchmark | Baseline | Current | Change | Status |
|-----------|----------|---------|--------|--------|
| CreateSlug_Empty_String | 269.700 ns | 274.000 ns | +1.6% | ➡️  |
| CreateSlug_Long_Text_Truncated | 7613.800 ns | 7863.300 ns | +3.3% | ➡️  |
| CreateSlug_No_Trim_Separators | 987.900 ns | 1017.900 ns | +3.0% | ➡️  |
| CreateSlug_Simple_Ascii_Default | 1084.400 ns | 1093.500 ns | +0.8% | ➡️  |
| CreateSlug_Simple_Overload_Custom | 1077.300 ns | 1078.600 ns | +0.1% | ➡️  |
| CreateSlug_Special_Chars_Default | 1883.200 ns | 1807.600 ns | -4.0% | ➡️  |
| CreateSlug_Special_Chars_Extended | 1469.300 ns | 1473.100 ns | +0.3% | ➡️  |
| CreateSlug_Underscore_Separator | 741.600 ns | 813.300 ns | +9.7% | ⚠️ MINOR |
| CreateSlug_Unicode_Text_Default | 2161.000 ns | 2221.900 ns | +2.8% | ➡️  |
| CreateSlug_Unicode_Text_Unicode_Allowed | 1830.200 ns | 1836.400 ns | +0.3% | ➡️  |
| CreateSlug_Whitespace_Only | 271.600 ns | 274.500 ns | +1.1% | ➡️  |

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

- **Baseline**: 741.600 ns (960 B allocated)
- **Current**: 813.300 ns (960 B allocated)
- **Change**: +9.7%
- **Recommendation**: Monitor


## Action Items

- [ ] Review regression details above
- [ ] Investigate root cause of performance degradation
- [ ] Fix regression or document justification

## Conclusion

⚠️ **1 regression(s) detected with MINOR severity.** Please review and address before baseline is updated.
