# Performance Review Results

**Date**: 2026-03-01 22:46:47 UTC
**Baseline**: 2026-02-08T22:49:54.298174
**Commit**: a33694db1a0056017d90622ba0507f8ad7f1342e

## Summary

- **Total Benchmarks**: 20
- **Regressions**: 1
- **Improvements**: 0
- **Status**: ⚠️ REGRESSIONS FOUND (MINOR)

## CPU Benchmarks

| Benchmark | Baseline | Current | Change | Status |
|-----------|----------|---------|--------|--------|
| CreateSlug_Empty_String | 270.200 ns | 269.300 ns | -0.3% | ➡️  |
| CreateSlug_Long_Text_Truncated | 7598.200 ns | 7729.300 ns | +1.7% | ➡️  |
| CreateSlug_No_Trim_Separators | 971.100 ns | 975.000 ns | +0.4% | ➡️  |
| CreateSlug_Simple_Ascii_Default | 1073.000 ns | 1071.800 ns | -0.1% | ➡️  |
| CreateSlug_Simple_Overload_Custom | 1043.900 ns | 1119.400 ns | +7.2% | ⚠️ MINOR |
| CreateSlug_Special_Chars_Default | 1864.500 ns | 1788.900 ns | -4.1% | ➡️  |
| CreateSlug_Special_Chars_Extended | 1452.700 ns | 1459.500 ns | +0.5% | ➡️  |
| CreateSlug_Underscore_Separator | 735.700 ns | 742.400 ns | +0.9% | ➡️  |
| CreateSlug_Unicode_Text_Default | 2169.500 ns | 2218.300 ns | +2.2% | ➡️  |
| CreateSlug_Unicode_Text_Unicode_Allowed | 1810.000 ns | 1815.500 ns | +0.3% | ➡️  |
| CreateSlug_Whitespace_Only | 271.300 ns | 269.900 ns | -0.5% | ➡️  |

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

### CreateSlug_Simple_Overload_Custom - MINOR

- **Baseline**: 1043.900 ns (1,960 B allocated)
- **Current**: 1119.400 ns (1,960 B allocated)
- **Change**: +7.2%
- **Recommendation**: Monitor


## Action Items

- [ ] Review regression details above
- [ ] Investigate root cause of performance degradation
- [ ] Fix regression or document justification

## Conclusion

⚠️ **1 regression(s) detected with MINOR severity.** Please review and address before baseline is updated.
