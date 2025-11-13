# Performance Review Results - Initial Baseline

**Date**: 2025-11-13 05:59:57 UTC
**Baseline**: Initial Run
**Commit**: 9639a206c94c92626901f593a39da8d33714a9a8

## Summary

This is the **initial benchmark run**. No baseline exists for comparison.

- **Total Benchmarks**: 20
- **Status**: ✅ INITIAL BASELINE ESTABLISHED

## Benchmarks Recorded

The following benchmarks will serve as the baseline for future comparisons:


### CPU Benchmarks

- **CreateSlug_Empty_String**: 267.900 ns (976 B)
- **CreateSlug_Long_Text_Truncated**: 7758.300 ns (8824 B)
- **CreateSlug_No_Trim_Separators**: 996.800 ns (1248 B)
- **CreateSlug_Simple_Ascii_Default**: 1087.200 ns (1960 B)
- **CreateSlug_Simple_Overload_Custom**: 1086.600 ns (1960 B)
- **CreateSlug_Special_Chars_Default**: 1809.200 ns (2856 B)
- **CreateSlug_Special_Chars_Extended**: 1477.100 ns (1856 B)
- **CreateSlug_Underscore_Separator**: 747.200 ns (960 B)
- **CreateSlug_Unicode_Text_Default**: 2216.300 ns (3040 B)
- **CreateSlug_Unicode_Text_Unicode_Allowed**: 1831.100 ns (2040 B)
- **CreateSlug_Whitespace_Only**: 278.400 ns (976 B)

### Memory Benchmarks

- **BulkCreateSlugs_Default_Options**: 1712000.000 ns (1,908,408 B, Gen0/1: 113.3/25.4)
- **BulkCreateSlugs_Extended_Chars**: 1785000.000 ns (1,908,408 B, Gen0/1: 113.3/25.4)
- **BulkCreateSlugs_Unicode_Allowed**: 1714000.000 ns (1,908,408 B, Gen0/1: 113.3/25.4)
- **Chained_Slug_Operations**: 6664000.000 ns (9,531,555 B, Gen0/1: 562.5/132.8)
- **Create_New_Options_Instance**: 2061000.000 ns (2,915,041 B, Gen0/1: 171.9/39.1)
- **Filter_And_Store_Slugs_With_Linq**: 2071000.000 ns (2,915,041 B, Gen0/1: 171.9/39.1)
- **Process_Large_Payload**: 4113000.000 ns (5,274,337 B, Gen0/1: 312.5/179.7)
- **Reuse_Options_Instance**: 1661000.000 ns (1,908,408 B, Gen0/1: 113.3/27.3)
- **StoreSlugs_In_Dictionary**: 2068000.000 ns (2,936,012 B, Gen0/1: 171.9/19.5)

## Next Steps

- [x] Initial baseline established
- [x] Future runs will compare against this baseline
- [x] Performance regressions will be automatically detected

## Conclusion

✅ **Initial baseline successfully established.** Future benchmark runs will compare against these values.
