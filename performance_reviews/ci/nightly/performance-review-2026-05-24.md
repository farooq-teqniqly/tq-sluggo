# Performance Review Results

**Date**: 2026-05-24 22:54:00 UTC
**Baseline**: 2026-04-12T22:51:10.890819
**Commit**: 1abc6858dcb5218ff2b82dca081641eb48c9f396

## Summary

- **Total Benchmarks**: 20
- **Regressions**: 0
- **Improvements**: 0
- **Status**: ✅ PASS

## CPU Benchmarks

| Benchmark | Baseline | Current | Change | Status |
|-----------|----------|---------|--------|--------|
| CreateSlug_Empty_String | 264.800 ns | 270.800 ns | +2.3% | ➡️  |
| CreateSlug_Long_Text_Truncated | 7782.800 ns | 7798.100 ns | +0.2% | ➡️  |
| CreateSlug_No_Trim_Separators | 991.200 ns | 979.600 ns | -1.2% | ➡️  |
| CreateSlug_Simple_Ascii_Default | 1087.500 ns | 1068.600 ns | -1.7% | ➡️  |
| CreateSlug_Simple_Overload_Custom | 1066.300 ns | 1074.200 ns | +0.7% | ➡️  |
| CreateSlug_Special_Chars_Default | 1792.000 ns | 1788.300 ns | -0.2% | ➡️  |
| CreateSlug_Special_Chars_Extended | 1461.000 ns | 1460.800 ns | -0.0% | ➡️  |
| CreateSlug_Underscore_Separator | 739.500 ns | 759.400 ns | +2.7% | ➡️  |
| CreateSlug_Unicode_Text_Default | 2233.700 ns | 2204.100 ns | -1.3% | ➡️  |
| CreateSlug_Unicode_Text_Unicode_Allowed | 1830.900 ns | 1833.400 ns | +0.1% | ➡️  |
| CreateSlug_Whitespace_Only | 272.900 ns | 279.000 ns | +2.2% | ➡️  |

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
