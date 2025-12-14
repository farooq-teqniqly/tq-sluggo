# Performance Review Results

**Date**: 2025-12-14 22:42:59 UTC
**Baseline**: 2025-12-07T22:42:27.732707
**Commit**: 397bd70a52da6a0c58de75571df35229952033da

## Summary

- **Total Benchmarks**: 20
- **Regressions**: 2
- **Improvements**: 0
- **Status**: ⚠️ REGRESSIONS FOUND (MINOR)

## CPU Benchmarks

| Benchmark | Baseline | Current | Change | Status |
|-----------|----------|---------|--------|--------|
| CreateSlug_Empty_String | 270.700 ns | 272.900 ns | +0.8% | ➡️  |
| CreateSlug_Long_Text_Truncated | 7754.200 ns | 7860.500 ns | +1.4% | ➡️  |
| CreateSlug_No_Trim_Separators | 1008.400 ns | 1077.100 ns | +6.8% | ⚠️ MINOR |
| CreateSlug_Simple_Ascii_Default | 1084.100 ns | 1075.800 ns | -0.8% | ➡️  |
| CreateSlug_Simple_Overload_Custom | 1074.300 ns | 1096.500 ns | +2.1% | ➡️  |
| CreateSlug_Special_Chars_Default | 1769.100 ns | 1811.800 ns | +2.4% | ➡️  |
| CreateSlug_Special_Chars_Extended | 1460.000 ns | 1473.000 ns | +0.9% | ➡️  |
| CreateSlug_Underscore_Separator | 735.400 ns | 772.400 ns | +5.0% | ⚠️ MINOR |
| CreateSlug_Unicode_Text_Default | 2228.700 ns | 2278.700 ns | +2.2% | ➡️  |
| CreateSlug_Unicode_Text_Unicode_Allowed | 1816.800 ns | 1843.100 ns | +1.4% | ➡️  |
| CreateSlug_Whitespace_Only | 274.100 ns | 279.900 ns | +2.1% | ➡️  |

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

- **Baseline**: 1008.400 ns (1,248 B allocated)
- **Current**: 1077.100 ns (1,248 B allocated)
- **Change**: +6.8%
- **Recommendation**: Monitor

### CreateSlug_Underscore_Separator - MINOR

- **Baseline**: 735.400 ns (960 B allocated)
- **Current**: 772.400 ns (960 B allocated)
- **Change**: +5.0%
- **Recommendation**: Monitor


## Action Items

- [ ] Review regression details above
- [ ] Investigate root cause of performance degradation
- [ ] Fix regression or document justification

## Conclusion

⚠️ **2 regression(s) detected with MINOR severity.** Please review and address before baseline is updated.
