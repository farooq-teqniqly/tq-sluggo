# Performance Review Results - Initial Baseline

**Date**: 2025-11-12 18:10:48 UTC
**Baseline**: 2025-11-12T17:53:17.277688
**Commit**: 5ed9dc3ec6f673a0aac7199a485bef269e39908c

## Summary

This is the **initial benchmark run**. No baseline exists for comparison.

- **Total Benchmarks**: 20
- **Status**: ✅ INITIAL BASELINE ESTABLISHED

## Benchmarks Recorded

The following benchmarks will serve as the baseline for future comparisons:


### Memory Benchmarks

- **CreateSlug_Empty_String**: 253.800 ns (976 B, Gen0/1: 0.1/0.0)
- **CreateSlug_Long_Text_Truncated**: 7222.200 ns (8,784 B, Gen0/1: 0.5/0.0)
- **CreateSlug_No_Trim_Separators**: 907.200 ns (1,208 B, Gen0/1: 0.1/0.0)
- **CreateSlug_Simple_Ascii_Default**: 947.200 ns (1,896 B, Gen0/1: 0.1/0.0)
- **CreateSlug_Simple_Overload_Custom**: 942.300 ns (1,896 B, Gen0/1: 0.1/0.0)
- **CreateSlug_Special_Chars_Default**: 1572.100 ns (2,792 B, Gen0/1: 0.2/0.0)
- **CreateSlug_Special_Chars_Extended**: 1308.800 ns (1,816 B, Gen0/1: 0.1/0.0)
- **CreateSlug_Underscore_Separator**: 645.600 ns (920 B, Gen0/1: 0.1/0.0)
- **CreateSlug_Unicode_Text_Default**: 1972.500 ns (2,976 B, Gen0/1: 0.2/0.0)
- **CreateSlug_Unicode_Text_Unicode_Allowed**: 1736.800 ns (2,000 B, Gen0/1: 0.1/0.0)
- **CreateSlug_Whitespace_Only**: 264.900 ns (976 B, Gen0/1: 0.1/0.0)
- **BulkCreateSlugs_Default_Options**: 1542000.000 ns (1,866,465 B, Gen0/1: 111.3/25.4)
- **BulkCreateSlugs_Extended_Chars**: 1541000.000 ns (1,866,465 B, Gen0/1: 111.3/25.4)
- **BulkCreateSlugs_Unicode_Allowed**: 1506000.000 ns (1,866,465 B, Gen0/1: 111.3/25.4)
- **Chained_Slug_Operations**: 5900000.000 ns (9,332,326 B, Gen0/1: 554.7/140.6)
- **Create_New_Options_Instance**: 1772000.000 ns (2,841,640 B, Gen0/1: 169.9/41.0)
- **Filter_And_Store_Slugs_With_Linq**: 1813000.000 ns (2,852,126 B, Gen0/1: 169.9/39.1)
- **Process_Large_Payload**: 3735000.000 ns (5,211,422 B, Gen0/1: 308.6/175.8)
- **Reuse_Options_Instance**: 1543000.000 ns (1,866,465 B, Gen0/1: 111.3/25.4)
- **StoreSlugs_In_Dictionary**: 1860000.000 ns (2,873,098 B, Gen0/1: 169.9/19.5)

## Next Steps

- [x] Initial baseline established
- [x] Future runs will compare against this baseline
- [x] Performance regressions will be automatically detected

## Conclusion

✅ **Initial baseline successfully established.** Future benchmark runs will compare against these values.
