# Performance Review Results

**Date**: 2026-04-05 22:50:33 UTC
**Baseline**: 2026-03-22T22:48:25.782249
**Commit**: 06a4d320cf31329f5e7f626517bebe2d2b111402

## Summary

- **Total Benchmarks**: 20
- **Regressions**: 0
- **Improvements**: 0
- **Status**: ✅ PASS

## CPU Benchmarks

| Benchmark | Baseline | Current | Change | Status |
|-----------|----------|---------|--------|--------|
| CreateSlug_Empty_String | 269.700 ns | 268.700 ns | -0.4% | ➡️  |
| CreateSlug_Long_Text_Truncated | 7613.800 ns | 7853.900 ns | +3.2% | ➡️  |
| CreateSlug_No_Trim_Separators | 987.900 ns | 991.000 ns | +0.3% | ➡️  |
| CreateSlug_Simple_Ascii_Default | 1084.400 ns | 1076.800 ns | -0.7% | ➡️  |
| CreateSlug_Simple_Overload_Custom | 1077.300 ns | 1101.500 ns | +2.2% | ➡️  |
| CreateSlug_Special_Chars_Default | 1883.200 ns | 1807.900 ns | -4.0% | ➡️  |
| CreateSlug_Special_Chars_Extended | 1469.300 ns | 1452.700 ns | -1.1% | ➡️  |
| CreateSlug_Underscore_Separator | 741.600 ns | 743.800 ns | +0.3% | ➡️  |
| CreateSlug_Unicode_Text_Default | 2161.000 ns | 2193.900 ns | +1.5% | ➡️  |
| CreateSlug_Unicode_Text_Unicode_Allowed | 1830.200 ns | 1827.800 ns | -0.1% | ➡️  |
| CreateSlug_Whitespace_Only | 271.600 ns | 277.100 ns | +2.0% | ➡️  |

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
