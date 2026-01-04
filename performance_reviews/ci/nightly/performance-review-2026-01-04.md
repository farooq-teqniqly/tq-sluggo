# Performance Review Results

**Date**: 2026-01-04 22:44:28 UTC
**Baseline**: 2025-12-28T22:44:06.103674
**Commit**: 6c7d1bfc52dacee321b850d30f20afafc0cb4bf1

## Summary

- **Total Benchmarks**: 20
- **Regressions**: 1
- **Improvements**: 0
- **Status**: ⚠️ REGRESSIONS FOUND (MINOR)

## CPU Benchmarks

| Benchmark | Baseline | Current | Change | Status |
|-----------|----------|---------|--------|--------|
| CreateSlug_Empty_String | 264.600 ns | 273.000 ns | +3.2% | ➡️  |
| CreateSlug_Long_Text_Truncated | 7736.400 ns | 7726.000 ns | -0.1% | ➡️  |
| CreateSlug_No_Trim_Separators | 976.700 ns | 1069.800 ns | +9.5% | ⚠️ MINOR |
| CreateSlug_Simple_Ascii_Default | 1071.900 ns | 1094.800 ns | +2.1% | ➡️  |
| CreateSlug_Simple_Overload_Custom | 1070.900 ns | 1089.300 ns | +1.7% | ➡️  |
| CreateSlug_Special_Chars_Default | 1774.600 ns | 1828.400 ns | +3.0% | ➡️  |
| CreateSlug_Special_Chars_Extended | 1458.200 ns | 1469.400 ns | +0.8% | ➡️  |
| CreateSlug_Underscore_Separator | 735.100 ns | 748.000 ns | +1.8% | ➡️  |
| CreateSlug_Unicode_Text_Default | 2177.600 ns | 2247.800 ns | +3.2% | ➡️  |
| CreateSlug_Unicode_Text_Unicode_Allowed | 1823.800 ns | 1849.000 ns | +1.4% | ➡️  |
| CreateSlug_Whitespace_Only | 276.600 ns | 286.100 ns | +3.4% | ➡️  |

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

- **Baseline**: 976.700 ns (1,248 B allocated)
- **Current**: 1069.800 ns (1,248 B allocated)
- **Change**: +9.5%
- **Recommendation**: Monitor


## Action Items

- [ ] Review regression details above
- [ ] Investigate root cause of performance degradation
- [ ] Fix regression or document justification

## Conclusion

⚠️ **1 regression(s) detected with MINOR severity.** Please review and address before baseline is updated.
