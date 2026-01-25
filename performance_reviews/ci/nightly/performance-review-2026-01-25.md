# Performance Review Results

**Date**: 2026-01-25 22:44:49 UTC
**Baseline**: 2026-01-18T22:44:09.144171
**Commit**: 5a66653bbadd8a39da32853870de8815a4811944

## Summary

- **Total Benchmarks**: 20
- **Regressions**: 0
- **Improvements**: 0
- **Status**: ✅ PASS

## CPU Benchmarks

| Benchmark | Baseline | Current | Change | Status |
|-----------|----------|---------|--------|--------|
| CreateSlug_Empty_String | 274.000 ns | 275.200 ns | +0.4% | ➡️  |
| CreateSlug_Long_Text_Truncated | 7573.100 ns | 7891.900 ns | +4.2% | ➡️  |
| CreateSlug_No_Trim_Separators | 965.800 ns | 1008.300 ns | +4.4% | ➡️  |
| CreateSlug_Simple_Ascii_Default | 1074.400 ns | 1100.300 ns | +2.4% | ➡️  |
| CreateSlug_Simple_Overload_Custom | 1057.600 ns | 1087.200 ns | +2.8% | ➡️  |
| CreateSlug_Special_Chars_Default | 1769.700 ns | 1777.800 ns | +0.5% | ➡️  |
| CreateSlug_Special_Chars_Extended | 1465.000 ns | 1474.800 ns | +0.7% | ➡️  |
| CreateSlug_Underscore_Separator | 733.400 ns | 744.400 ns | +1.5% | ➡️  |
| CreateSlug_Unicode_Text_Default | 2147.900 ns | 2166.300 ns | +0.9% | ➡️  |
| CreateSlug_Unicode_Text_Unicode_Allowed | 1882.100 ns | 1850.000 ns | -1.7% | ➡️  |
| CreateSlug_Whitespace_Only | 272.600 ns | 272.200 ns | -0.1% | ➡️  |

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

## Action Items

- [x] No regressions detected
- [x] Baseline will be automatically updated

## Conclusion

✅ **All benchmarks passed.** Performance is within acceptable range of baseline.
