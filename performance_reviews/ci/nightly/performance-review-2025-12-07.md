# Performance Review Results

**Date**: 2025-12-07 22:42:27 UTC
**Baseline**: 2025-11-30T22:43:07.515167
**Commit**: db6ddaf321c661467986c9c0562247afb6f98ed8

## Summary

- **Total Benchmarks**: 20
- **Regressions**: 0
- **Improvements**: 0
- **Status**: ✅ PASS

## CPU Benchmarks

| Benchmark | Baseline | Current | Change | Status |
|-----------|----------|---------|--------|--------|
| CreateSlug_Empty_String | 276.500 ns | 270.700 ns | -2.1% | ➡️  |
| CreateSlug_Long_Text_Truncated | 7737.600 ns | 7754.200 ns | +0.2% | ➡️  |
| CreateSlug_No_Trim_Separators | 981.500 ns | 1008.400 ns | +2.7% | ➡️  |
| CreateSlug_Simple_Ascii_Default | 1069.700 ns | 1084.100 ns | +1.3% | ➡️  |
| CreateSlug_Simple_Overload_Custom | 1081.100 ns | 1074.300 ns | -0.6% | ➡️  |
| CreateSlug_Special_Chars_Default | 1806.000 ns | 1769.100 ns | -2.0% | ➡️  |
| CreateSlug_Special_Chars_Extended | 1466.000 ns | 1460.000 ns | -0.4% | ➡️  |
| CreateSlug_Underscore_Separator | 746.100 ns | 735.400 ns | -1.4% | ➡️  |
| CreateSlug_Unicode_Text_Default | 2179.700 ns | 2228.700 ns | +2.2% | ➡️  |
| CreateSlug_Unicode_Text_Unicode_Allowed | 1829.100 ns | 1816.800 ns | -0.7% | ➡️  |
| CreateSlug_Whitespace_Only | 272.500 ns | 274.100 ns | +0.6% | ➡️  |

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
