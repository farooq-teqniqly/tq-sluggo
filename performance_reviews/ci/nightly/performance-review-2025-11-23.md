# Performance Review Results

**Date**: 2025-11-23 22:43:04 UTC
**Baseline**: 2025-11-13T05:59:57.860860
**Commit**: 3dc908fdbe0ef88b3486e5a86d51688a0d142d86

## Summary

- **Total Benchmarks**: 20
- **Regressions**: 0
- **Improvements**: 0
- **Status**: ✅ PASS

## CPU Benchmarks

| Benchmark | Baseline | Current | Change | Status |
|-----------|----------|---------|--------|--------|
| CreateSlug_Empty_String | 267.900 ns | 278.100 ns | +3.8% | ➡️  |
| CreateSlug_Long_Text_Truncated | 7758.300 ns | 7761.000 ns | +0.0% | ➡️  |
| CreateSlug_No_Trim_Separators | 996.800 ns | 1013.200 ns | +1.6% | ➡️  |
| CreateSlug_Simple_Ascii_Default | 1087.200 ns | 1078.600 ns | -0.8% | ➡️  |
| CreateSlug_Simple_Overload_Custom | 1086.600 ns | 1084.200 ns | -0.2% | ➡️  |
| CreateSlug_Special_Chars_Default | 1809.200 ns | 1789.700 ns | -1.1% | ➡️  |
| CreateSlug_Special_Chars_Extended | 1477.100 ns | 1476.200 ns | -0.1% | ➡️  |
| CreateSlug_Underscore_Separator | 747.200 ns | 747.000 ns | -0.0% | ➡️  |
| CreateSlug_Unicode_Text_Default | 2216.300 ns | 2179.200 ns | -1.7% | ➡️  |
| CreateSlug_Unicode_Text_Unicode_Allowed | 1831.100 ns | 1857.100 ns | +1.4% | ➡️  |
| CreateSlug_Whitespace_Only | 278.400 ns | 273.600 ns | -1.7% | ➡️  |

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
