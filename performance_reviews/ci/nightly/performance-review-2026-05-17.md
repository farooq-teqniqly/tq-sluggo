# Performance Review Results

**Date**: 2026-05-17 22:53:47 UTC
**Baseline**: 2026-04-12T22:51:10.890819
**Commit**: 611d838433f6f5529acf0516b5cbc0ab8f5cad60

## Summary

- **Total Benchmarks**: 20
- **Regressions**: 1
- **Improvements**: 0
- **Status**: ⚠️ REGRESSIONS FOUND (MINOR)

## CPU Benchmarks

| Benchmark | Baseline | Current | Change | Status |
|-----------|----------|---------|--------|--------|
| CreateSlug_Empty_String | 264.800 ns | 271.000 ns | +2.3% | ➡️  |
| CreateSlug_Long_Text_Truncated | 7782.800 ns | 7832.500 ns | +0.6% | ➡️  |
| CreateSlug_No_Trim_Separators | 991.200 ns | 992.100 ns | +0.1% | ➡️  |
| CreateSlug_Simple_Ascii_Default | 1087.500 ns | 1080.700 ns | -0.6% | ➡️  |
| CreateSlug_Simple_Overload_Custom | 1066.300 ns | 1094.200 ns | +2.6% | ➡️  |
| CreateSlug_Special_Chars_Default | 1792.000 ns | 1816.900 ns | +1.4% | ➡️  |
| CreateSlug_Special_Chars_Extended | 1461.000 ns | 1457.300 ns | -0.3% | ➡️  |
| CreateSlug_Underscore_Separator | 739.500 ns | 793.000 ns | +7.2% | ⚠️ MINOR |
| CreateSlug_Unicode_Text_Default | 2233.700 ns | 2180.100 ns | -2.4% | ➡️  |
| CreateSlug_Unicode_Text_Unicode_Allowed | 1830.900 ns | 1843.000 ns | +0.7% | ➡️  |
| CreateSlug_Whitespace_Only | 272.900 ns | 278.800 ns | +2.2% | ➡️  |

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

- **Baseline**: 739.500 ns (960 B allocated)
- **Current**: 793.000 ns (960 B allocated)
- **Change**: +7.2%
- **Recommendation**: Monitor


## Action Items

- [ ] Review regression details above
- [ ] Investigate root cause of performance degradation
- [ ] Fix regression or document justification

## Conclusion

⚠️ **1 regression(s) detected with MINOR severity.** Please review and address before baseline is updated.
