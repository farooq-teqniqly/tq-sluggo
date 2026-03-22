# Performance Review Results

**Date**: 2026-03-22 22:48:25 UTC
**Baseline**: 2026-02-08T22:49:54.298174
**Commit**: c91cb85edc0a0237ad42fafaebacb26fb84a2a2e

## Summary

- **Total Benchmarks**: 20
- **Regressions**: 0
- **Improvements**: 0
- **Status**: ✅ PASS

## CPU Benchmarks

| Benchmark | Baseline | Current | Change | Status |
|-----------|----------|---------|--------|--------|
| CreateSlug_Empty_String | 270.200 ns | 269.700 ns | -0.2% | ➡️  |
| CreateSlug_Long_Text_Truncated | 7598.200 ns | 7613.800 ns | +0.2% | ➡️  |
| CreateSlug_No_Trim_Separators | 971.100 ns | 987.900 ns | +1.7% | ➡️  |
| CreateSlug_Simple_Ascii_Default | 1073.000 ns | 1084.400 ns | +1.1% | ➡️  |
| CreateSlug_Simple_Overload_Custom | 1043.900 ns | 1077.300 ns | +3.2% | ➡️  |
| CreateSlug_Special_Chars_Default | 1864.500 ns | 1883.200 ns | +1.0% | ➡️  |
| CreateSlug_Special_Chars_Extended | 1452.700 ns | 1469.300 ns | +1.1% | ➡️  |
| CreateSlug_Underscore_Separator | 735.700 ns | 741.600 ns | +0.8% | ➡️  |
| CreateSlug_Unicode_Text_Default | 2169.500 ns | 2161.000 ns | -0.4% | ➡️  |
| CreateSlug_Unicode_Text_Unicode_Allowed | 1810.000 ns | 1830.200 ns | +1.1% | ➡️  |
| CreateSlug_Whitespace_Only | 271.300 ns | 271.600 ns | +0.1% | ➡️  |

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
