# Performance Review Results

**Date**: 2026-02-22 22:48:00 UTC
**Baseline**: 2026-02-08T22:49:54.298174
**Commit**: 4087ced21c252ad58f7484aec9e5458c08667833

## Summary

- **Total Benchmarks**: 20
- **Regressions**: 1
- **Improvements**: 0
- **Status**: ⚠️ REGRESSIONS FOUND (MINOR)

## CPU Benchmarks

| Benchmark | Baseline | Current | Change | Status |
|-----------|----------|---------|--------|--------|
| CreateSlug_Empty_String | 270.200 ns | 269.800 ns | -0.1% | ➡️  |
| CreateSlug_Long_Text_Truncated | 7598.200 ns | 7721.200 ns | +1.6% | ➡️  |
| CreateSlug_No_Trim_Separators | 971.100 ns | 1007.800 ns | +3.8% | ➡️  |
| CreateSlug_Simple_Ascii_Default | 1073.000 ns | 1063.300 ns | -0.9% | ➡️  |
| CreateSlug_Simple_Overload_Custom | 1043.900 ns | 1081.300 ns | +3.6% | ➡️  |
| CreateSlug_Special_Chars_Default | 1864.500 ns | 1781.400 ns | -4.5% | ➡️  |
| CreateSlug_Special_Chars_Extended | 1452.700 ns | 1551.700 ns | +6.8% | ⚠️ MINOR |
| CreateSlug_Underscore_Separator | 735.700 ns | 733.600 ns | -0.3% | ➡️  |
| CreateSlug_Unicode_Text_Default | 2169.500 ns | 2178.500 ns | +0.4% | ➡️  |
| CreateSlug_Unicode_Text_Unicode_Allowed | 1810.000 ns | 1794.200 ns | -0.9% | ➡️  |
| CreateSlug_Whitespace_Only | 271.300 ns | 271.300 ns | 0.0% | ➡️  |

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

### CreateSlug_Special_Chars_Extended - MINOR

- **Baseline**: 1452.700 ns (1,856 B allocated)
- **Current**: 1551.700 ns (1,856 B allocated)
- **Change**: +6.8%
- **Recommendation**: Monitor


## Action Items

- [ ] Review regression details above
- [ ] Investigate root cause of performance degradation
- [ ] Fix regression or document justification

## Conclusion

⚠️ **1 regression(s) detected with MINOR severity.** Please review and address before baseline is updated.
