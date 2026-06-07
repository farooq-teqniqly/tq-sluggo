# Performance Review Results

**Date**: 2026-06-07 22:56:31 UTC
**Baseline**: 2026-05-24T22:54:00.020653
**Commit**: bde9a706077935d6c2cfcdf127e32ebd6281e76f

## Summary

- **Total Benchmarks**: 20
- **Regressions**: 0
- **Improvements**: 0
- **Status**: ✅ PASS

## CPU Benchmarks

| Benchmark | Baseline | Current | Change | Status |
|-----------|----------|---------|--------|--------|
| CreateSlug_Empty_String | 270.800 ns | 268.800 ns | -0.7% | ➡️  |
| CreateSlug_Long_Text_Truncated | 7798.100 ns | 7746.400 ns | -0.7% | ➡️  |
| CreateSlug_No_Trim_Separators | 979.600 ns | 973.900 ns | -0.6% | ➡️  |
| CreateSlug_Simple_Ascii_Default | 1068.600 ns | 1073.500 ns | +0.5% | ➡️  |
| CreateSlug_Simple_Overload_Custom | 1074.200 ns | 1065.900 ns | -0.8% | ➡️  |
| CreateSlug_Special_Chars_Default | 1788.300 ns | 1850.700 ns | +3.5% | ➡️  |
| CreateSlug_Special_Chars_Extended | 1460.800 ns | 1450.900 ns | -0.7% | ➡️  |
| CreateSlug_Underscore_Separator | 759.400 ns | 739.000 ns | -2.7% | ➡️  |
| CreateSlug_Unicode_Text_Default | 2204.100 ns | 2147.900 ns | -2.5% | ➡️  |
| CreateSlug_Unicode_Text_Unicode_Allowed | 1833.400 ns | 1826.800 ns | -0.4% | ➡️  |
| CreateSlug_Whitespace_Only | 279.000 ns | 270.000 ns | -3.2% | ➡️  |

## Memory Benchmarks

| Benchmark | Baseline | Current | Alloc Change | Gen0/1 | Status |
|-----------|----------|---------|--------------|--------|--------|
| BulkCreateSlugs_Default_Options | 1,908,408 B | 1,908,408 B | 0.0% | 113.3/23.4 | ➡️  |
| BulkCreateSlugs_Extended_Chars | 1,908,408 B | 1,908,408 B | 0.0% | 113.3/25.4 | ➡️  |
| BulkCreateSlugs_Unicode_Allowed | 1,908,408 B | 1,908,408 B | 0.0% | 113.3/25.4 | ➡️  |
| Chained_Slug_Operations | 9,531,555 B | 9,531,555 B | 0.0% | 562.5/132.8 | ➡️  |
| Create_New_Options_Instance | 2,915,041 B | 2,915,041 B | 0.0% | 171.9/39.1 | ➡️  |
| Filter_And_Store_Slugs_With_Linq | 2,915,041 B | 2,915,041 B | 0.0% | 171.9/39.1 | ➡️  |
| Process_Large_Payload | 5,274,337 B | 5,274,337 B | 0.0% | 312.5/179.7 | ➡️  |
| Reuse_Options_Instance | 1,908,408 B | 1,908,408 B | 0.0% | 113.3/23.4 | ➡️  |
| StoreSlugs_In_Dictionary | 2,936,012 B | 2,936,012 B | 0.0% | 171.9/19.5 | ➡️  |

## Action Items

- [x] No regressions detected
- [x] Baseline will be automatically updated

## Conclusion

✅ **All benchmarks passed.** Performance is within acceptable range of baseline.
