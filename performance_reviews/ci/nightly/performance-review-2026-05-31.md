# Performance Review Results

**Date**: 2026-05-31 22:54:34 UTC
**Baseline**: 2026-05-24T22:54:00.020653
**Commit**: 81b3f636b7d71c555ba8942d62485170dc7afded

## Summary

- **Total Benchmarks**: 20
- **Regressions**: 1
- **Improvements**: 0
- **Status**: ⚠️ REGRESSIONS FOUND (MINOR)

## CPU Benchmarks

| Benchmark | Baseline | Current | Change | Status |
|-----------|----------|---------|--------|--------|
| CreateSlug_Empty_String | 270.800 ns | 273.500 ns | +1.0% | ➡️  |
| CreateSlug_Long_Text_Truncated | 7798.100 ns | 7748.900 ns | -0.6% | ➡️  |
| CreateSlug_No_Trim_Separators | 979.600 ns | 982.500 ns | +0.3% | ➡️  |
| CreateSlug_Simple_Ascii_Default | 1068.600 ns | 1156.900 ns | +8.3% | ⚠️ MINOR |
| CreateSlug_Simple_Overload_Custom | 1074.200 ns | 1077.100 ns | +0.3% | ➡️  |
| CreateSlug_Special_Chars_Default | 1788.300 ns | 1816.500 ns | +1.6% | ➡️  |
| CreateSlug_Special_Chars_Extended | 1460.800 ns | 1458.100 ns | -0.2% | ➡️  |
| CreateSlug_Underscore_Separator | 759.400 ns | 744.200 ns | -2.0% | ➡️  |
| CreateSlug_Unicode_Text_Default | 2204.100 ns | 2165.900 ns | -1.7% | ➡️  |
| CreateSlug_Unicode_Text_Unicode_Allowed | 1833.400 ns | 1828.700 ns | -0.3% | ➡️  |
| CreateSlug_Whitespace_Only | 279.000 ns | 288.500 ns | +3.4% | ➡️  |

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

### CreateSlug_Simple_Ascii_Default - MINOR

- **Baseline**: 1068.600 ns (1,960 B allocated)
- **Current**: 1156.900 ns (1,960 B allocated)
- **Change**: +8.3%
- **Recommendation**: Monitor


## Action Items

- [ ] Review regression details above
- [ ] Investigate root cause of performance degradation
- [ ] Fix regression or document justification

## Conclusion

⚠️ **1 regression(s) detected with MINOR severity.** Please review and address before baseline is updated.
