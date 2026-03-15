# Performance Review Results

**Date**: 2026-03-15 22:49:57 UTC
**Baseline**: 2026-02-08T22:49:54.298174
**Commit**: 726674440f533ba08095dfe6b59d48f202880a94

## Summary

- **Total Benchmarks**: 20
- **Regressions**: 4
- **Improvements**: 0
- **Status**: ⚠️ REGRESSIONS FOUND (MINOR)

## CPU Benchmarks

| Benchmark | Baseline | Current | Change | Status |
|-----------|----------|---------|--------|--------|
| CreateSlug_Empty_String | 270.200 ns | 283.500 ns | +4.9% | ➡️  |
| CreateSlug_Long_Text_Truncated | 7598.200 ns | 7985.300 ns | +5.1% | ⚠️ MINOR |
| CreateSlug_No_Trim_Separators | 971.100 ns | 1015.000 ns | +4.5% | ➡️  |
| CreateSlug_Simple_Ascii_Default | 1073.000 ns | 1117.600 ns | +4.2% | ➡️  |
| CreateSlug_Simple_Overload_Custom | 1043.900 ns | 1097.500 ns | +5.1% | ⚠️ MINOR |
| CreateSlug_Special_Chars_Default | 1864.500 ns | 1836.600 ns | -1.5% | ➡️  |
| CreateSlug_Special_Chars_Extended | 1452.700 ns | 1490.600 ns | +2.6% | ➡️  |
| CreateSlug_Underscore_Separator | 735.700 ns | 763.200 ns | +3.7% | ➡️  |
| CreateSlug_Unicode_Text_Default | 2169.500 ns | 2283.000 ns | +5.2% | ⚠️ MINOR |
| CreateSlug_Unicode_Text_Unicode_Allowed | 1810.000 ns | 1860.900 ns | +2.8% | ➡️  |
| CreateSlug_Whitespace_Only | 271.300 ns | 286.000 ns | +5.4% | ⚠️ MINOR |

## Memory Benchmarks

| Benchmark | Baseline | Current | Alloc Change | Gen0/1 | Status |
|-----------|----------|---------|--------------|--------|--------|
| BulkCreateSlugs_Default_Options | 1,908,408 B | 1,908,408 B | 0.0% | 113.3/25.4 | ➡️  |
| BulkCreateSlugs_Extended_Chars | 1,908,408 B | 1,908,408 B | 0.0% | 113.3/23.4 | ➡️  |
| BulkCreateSlugs_Unicode_Allowed | 1,908,408 B | 1,908,408 B | 0.0% | 113.3/25.4 | ➡️  |
| Chained_Slug_Operations | 9,531,555 B | 9,531,555 B | 0.0% | 562.5/132.8 | ➡️  |
| Create_New_Options_Instance | 2,915,041 B | 2,915,041 B | 0.0% | 171.9/39.1 | ➡️  |
| Filter_And_Store_Slugs_With_Linq | 2,915,041 B | 2,915,041 B | 0.0% | 171.9/39.1 | ➡️  |
| Process_Large_Payload | 5,274,337 B | 5,274,337 B | 0.0% | 312.5/179.7 | ➡️  |
| Reuse_Options_Instance | 1,908,408 B | 1,908,408 B | 0.0% | 113.3/27.3 | ➡️  |
| StoreSlugs_In_Dictionary | 2,936,012 B | 2,936,012 B | 0.0% | 171.9/19.5 | ➡️  |

## Regressions

### CreateSlug_Long_Text_Truncated - MINOR

- **Baseline**: 7598.200 ns (8,824 B allocated)
- **Current**: 7985.300 ns (8,824 B allocated)
- **Change**: +5.1%
- **Recommendation**: Monitor

### CreateSlug_Simple_Overload_Custom - MINOR

- **Baseline**: 1043.900 ns (1,960 B allocated)
- **Current**: 1097.500 ns (1,960 B allocated)
- **Change**: +5.1%
- **Recommendation**: Monitor

### CreateSlug_Unicode_Text_Default - MINOR

- **Baseline**: 2169.500 ns (3,040 B allocated)
- **Current**: 2283.000 ns (3,040 B allocated)
- **Change**: +5.2%
- **Recommendation**: Monitor

### CreateSlug_Whitespace_Only - MINOR

- **Baseline**: 271.300 ns (976 B allocated)
- **Current**: 286.000 ns (976 B allocated)
- **Change**: +5.4%
- **Recommendation**: Monitor


## Action Items

- [ ] Review regression details above
- [ ] Investigate root cause of performance degradation
- [ ] Fix regression or document justification

## Conclusion

⚠️ **4 regression(s) detected with MINOR severity.** Please review and address before baseline is updated.
