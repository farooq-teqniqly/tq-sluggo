# Performance Review Results

**Date**: 2025-11-16 22:42:29 UTC
**Baseline**: 2025-11-13T05:59:57.860860
**Commit**: 7e221e5cc9f819abeefb40a1f2c964248506ae10

## Summary

- **Total Benchmarks**: 20
- **Regressions**: 1
- **Improvements**: 0
- **Status**: ⚠️ REGRESSIONS FOUND (MINOR)

## CPU Benchmarks

| Benchmark | Baseline | Current | Change | Status |
|-----------|----------|---------|--------|--------|
| CreateSlug_Empty_String | 267.900 ns | 268.700 ns | +0.3% | ➡️  |
| CreateSlug_Long_Text_Truncated | 7758.300 ns | 7753.800 ns | -0.1% | ➡️  |
| CreateSlug_No_Trim_Separators | 996.800 ns | 1066.300 ns | +7.0% | ⚠️ MINOR |
| CreateSlug_Simple_Ascii_Default | 1087.200 ns | 1081.400 ns | -0.5% | ➡️  |
| CreateSlug_Simple_Overload_Custom | 1086.600 ns | 1077.800 ns | -0.8% | ➡️  |
| CreateSlug_Special_Chars_Default | 1809.200 ns | 1799.700 ns | -0.5% | ➡️  |
| CreateSlug_Special_Chars_Extended | 1477.100 ns | 1472.300 ns | -0.3% | ➡️  |
| CreateSlug_Underscore_Separator | 747.200 ns | 747.100 ns | -0.0% | ➡️  |
| CreateSlug_Unicode_Text_Default | 2216.300 ns | 2196.400 ns | -0.9% | ➡️  |
| CreateSlug_Unicode_Text_Unicode_Allowed | 1831.100 ns | 1832.000 ns | +0.0% | ➡️  |
| CreateSlug_Whitespace_Only | 278.400 ns | 272.000 ns | -2.3% | ➡️  |

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

- **Baseline**: 996.800 ns (1,248 B allocated)
- **Current**: 1066.300 ns (1,248 B allocated)
- **Change**: +7.0%
- **Recommendation**: Monitor


## Action Items

- [ ] Review regression details above
- [ ] Investigate root cause of performance degradation
- [ ] Fix regression or document justification

## Conclusion

⚠️ **1 regression(s) detected with MINOR severity.** Please review and address before baseline is updated.
