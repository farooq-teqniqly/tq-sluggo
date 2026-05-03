# Performance Review Results

**Date**: 2026-05-03 22:52:00 UTC
**Baseline**: 2026-04-12T22:51:10.890819
**Commit**: d4cc3aca15c0cfe5ba0fd3eaa5143e865e4207db

## Summary

- **Total Benchmarks**: 20
- **Regressions**: 1
- **Improvements**: 0
- **Status**: ⚠️ REGRESSIONS FOUND (MINOR)

## CPU Benchmarks

| Benchmark | Baseline | Current | Change | Status |
|-----------|----------|---------|--------|--------|
| CreateSlug_Empty_String | 264.800 ns | 271.200 ns | +2.4% | ➡️  |
| CreateSlug_Long_Text_Truncated | 7782.800 ns | 7763.400 ns | -0.2% | ➡️  |
| CreateSlug_No_Trim_Separators | 991.200 ns | 1019.500 ns | +2.9% | ➡️  |
| CreateSlug_Simple_Ascii_Default | 1087.500 ns | 1083.000 ns | -0.4% | ➡️  |
| CreateSlug_Simple_Overload_Custom | 1066.300 ns | 1072.000 ns | +0.5% | ➡️  |
| CreateSlug_Special_Chars_Default | 1792.000 ns | 1870.800 ns | +4.4% | ➡️  |
| CreateSlug_Special_Chars_Extended | 1461.000 ns | 1443.500 ns | -1.2% | ➡️  |
| CreateSlug_Underscore_Separator | 739.500 ns | 785.800 ns | +6.3% | ⚠️ MINOR |
| CreateSlug_Unicode_Text_Default | 2233.700 ns | 2235.200 ns | +0.1% | ➡️  |
| CreateSlug_Unicode_Text_Unicode_Allowed | 1830.900 ns | 1833.400 ns | +0.1% | ➡️  |
| CreateSlug_Whitespace_Only | 272.900 ns | 274.600 ns | +0.6% | ➡️  |

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
- **Current**: 785.800 ns (960 B allocated)
- **Change**: +6.3%
- **Recommendation**: Monitor


## Action Items

- [ ] Review regression details above
- [ ] Investigate root cause of performance degradation
- [ ] Fix regression or document justification

## Conclusion

⚠️ **1 regression(s) detected with MINOR severity.** Please review and address before baseline is updated.
