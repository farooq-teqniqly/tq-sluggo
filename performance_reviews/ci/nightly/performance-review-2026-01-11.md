# Performance Review Results

**Date**: 2026-01-11 22:44:06 UTC
**Baseline**: 2025-12-28T22:44:06.103674
**Commit**: e94bbf5269bba851c239ecda97fb813dbbf0a3d7

## Summary

- **Total Benchmarks**: 20
- **Regressions**: 0
- **Improvements**: 0
- **Status**: ✅ PASS

## CPU Benchmarks

| Benchmark | Baseline | Current | Change | Status |
|-----------|----------|---------|--------|--------|
| CreateSlug_Empty_String | 264.600 ns | 277.100 ns | +4.7% | ➡️  |
| CreateSlug_Long_Text_Truncated | 7736.400 ns | 7756.200 ns | +0.3% | ➡️  |
| CreateSlug_No_Trim_Separators | 976.700 ns | 1021.700 ns | +4.6% | ➡️  |
| CreateSlug_Simple_Ascii_Default | 1071.900 ns | 1082.100 ns | +1.0% | ➡️  |
| CreateSlug_Simple_Overload_Custom | 1070.900 ns | 1101.400 ns | +2.8% | ➡️  |
| CreateSlug_Special_Chars_Default | 1774.600 ns | 1787.600 ns | +0.7% | ➡️  |
| CreateSlug_Special_Chars_Extended | 1458.200 ns | 1478.300 ns | +1.4% | ➡️  |
| CreateSlug_Underscore_Separator | 735.100 ns | 751.900 ns | +2.3% | ➡️  |
| CreateSlug_Unicode_Text_Default | 2177.600 ns | 2169.700 ns | -0.4% | ➡️  |
| CreateSlug_Unicode_Text_Unicode_Allowed | 1823.800 ns | 1903.800 ns | +4.4% | ➡️  |
| CreateSlug_Whitespace_Only | 276.600 ns | 279.500 ns | +1.0% | ➡️  |

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
