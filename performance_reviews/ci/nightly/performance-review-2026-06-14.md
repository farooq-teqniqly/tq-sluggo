# Performance Review Results

**Date**: 2026-06-14 22:59:24 UTC
**Baseline**: 2026-06-07T22:56:31.822240
**Commit**: 15db63cd26e120ca1e3cde680b03bdf15033e22f

## Summary

- **Total Benchmarks**: 20
- **Regressions**: 1
- **Improvements**: 0
- **Status**: ⚠️ REGRESSIONS FOUND (MINOR)

## CPU Benchmarks

| Benchmark | Baseline | Current | Change | Status |
|-----------|----------|---------|--------|--------|
| CreateSlug_Empty_String | 268.800 ns | 268.300 ns | -0.2% | ➡️  |
| CreateSlug_Long_Text_Truncated | 7746.400 ns | 7798.800 ns | +0.7% | ➡️  |
| CreateSlug_No_Trim_Separators | 973.900 ns | 983.800 ns | +1.0% | ➡️  |
| CreateSlug_Simple_Ascii_Default | 1073.500 ns | 1096.600 ns | +2.2% | ➡️  |
| CreateSlug_Simple_Overload_Custom | 1065.900 ns | 1073.900 ns | +0.8% | ➡️  |
| CreateSlug_Special_Chars_Default | 1850.700 ns | 1805.400 ns | -2.4% | ➡️  |
| CreateSlug_Special_Chars_Extended | 1450.900 ns | 1498.300 ns | +3.3% | ➡️  |
| CreateSlug_Underscore_Separator | 739.000 ns | 742.700 ns | +0.5% | ➡️  |
| CreateSlug_Unicode_Text_Default | 2147.900 ns | 2273.000 ns | +5.8% | ⚠️ MINOR |
| CreateSlug_Unicode_Text_Unicode_Allowed | 1826.800 ns | 1828.300 ns | +0.1% | ➡️  |
| CreateSlug_Whitespace_Only | 270.000 ns | 271.700 ns | +0.6% | ➡️  |

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

### CreateSlug_Unicode_Text_Default - MINOR

- **Baseline**: 2147.900 ns (3,040 B allocated)
- **Current**: 2273.000 ns (3,040 B allocated)
- **Change**: +5.8%
- **Recommendation**: Monitor


## Action Items

- [ ] Review regression details above
- [ ] Investigate root cause of performance degradation
- [ ] Fix regression or document justification

## Conclusion

⚠️ **1 regression(s) detected with MINOR severity.** Please review and address before baseline is updated.
