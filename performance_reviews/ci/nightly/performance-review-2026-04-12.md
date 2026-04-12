# Performance Review Results

**Date**: 2026-04-12 22:51:10 UTC
**Baseline**: 2026-04-05T22:50:33.356166
**Commit**: 6e003716d0cd44d00b379ab41c73c4dacecfdd56

## Summary

- **Total Benchmarks**: 20
- **Regressions**: 0
- **Improvements**: 0
- **Status**: ✅ PASS

## CPU Benchmarks

| Benchmark | Baseline | Current | Change | Status |
|-----------|----------|---------|--------|--------|
| CreateSlug_Empty_String | 268.700 ns | 264.800 ns | -1.5% | ➡️  |
| CreateSlug_Long_Text_Truncated | 7853.900 ns | 7782.800 ns | -0.9% | ➡️  |
| CreateSlug_No_Trim_Separators | 991.000 ns | 991.200 ns | +0.0% | ➡️  |
| CreateSlug_Simple_Ascii_Default | 1076.800 ns | 1087.500 ns | +1.0% | ➡️  |
| CreateSlug_Simple_Overload_Custom | 1101.500 ns | 1066.300 ns | -3.2% | ➡️  |
| CreateSlug_Special_Chars_Default | 1807.900 ns | 1792.000 ns | -0.9% | ➡️  |
| CreateSlug_Special_Chars_Extended | 1452.700 ns | 1461.000 ns | +0.6% | ➡️  |
| CreateSlug_Underscore_Separator | 743.800 ns | 739.500 ns | -0.6% | ➡️  |
| CreateSlug_Unicode_Text_Default | 2193.900 ns | 2233.700 ns | +1.8% | ➡️  |
| CreateSlug_Unicode_Text_Unicode_Allowed | 1827.800 ns | 1830.900 ns | +0.2% | ➡️  |
| CreateSlug_Whitespace_Only | 277.100 ns | 272.900 ns | -1.5% | ➡️  |

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
