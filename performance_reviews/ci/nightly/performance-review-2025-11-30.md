# Performance Review Results

**Date**: 2025-11-30 22:43:07 UTC
**Baseline**: 2025-11-23T22:43:04.102537
**Commit**: 6a5789d43e49253d0ab71f5ed264279a0285c71d

## Summary

- **Total Benchmarks**: 20
- **Regressions**: 0
- **Improvements**: 0
- **Status**: ✅ PASS

## CPU Benchmarks

| Benchmark | Baseline | Current | Change | Status |
|-----------|----------|---------|--------|--------|
| CreateSlug_Empty_String | 278.100 ns | 276.500 ns | -0.6% | ➡️  |
| CreateSlug_Long_Text_Truncated | 7761.000 ns | 7737.600 ns | -0.3% | ➡️  |
| CreateSlug_No_Trim_Separators | 1013.200 ns | 981.500 ns | -3.1% | ➡️  |
| CreateSlug_Simple_Ascii_Default | 1078.600 ns | 1069.700 ns | -0.8% | ➡️  |
| CreateSlug_Simple_Overload_Custom | 1084.200 ns | 1081.100 ns | -0.3% | ➡️  |
| CreateSlug_Special_Chars_Default | 1789.700 ns | 1806.000 ns | +0.9% | ➡️  |
| CreateSlug_Special_Chars_Extended | 1476.200 ns | 1466.000 ns | -0.7% | ➡️  |
| CreateSlug_Underscore_Separator | 747.000 ns | 746.100 ns | -0.1% | ➡️  |
| CreateSlug_Unicode_Text_Default | 2179.200 ns | 2179.700 ns | +0.0% | ➡️  |
| CreateSlug_Unicode_Text_Unicode_Allowed | 1857.100 ns | 1829.100 ns | -1.5% | ➡️  |
| CreateSlug_Whitespace_Only | 273.600 ns | 272.500 ns | -0.4% | ➡️  |

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
