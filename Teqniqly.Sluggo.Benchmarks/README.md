# Teqniqly.Sluggo.Benchmarks

This project contains CPU and memory benchmarks for the Teqniqly.Sluggo library using BenchmarkDotNet.

## Overview

The benchmarks measure the performance characteristics of the Slug library across various scenarios:

### SlugCpuBenchmarks

CPU performance benchmarks focusing on execution speed:

-   **Simple ASCII slug generation**: Benchmarks basic slug creation with default options
-   **Unicode text processing**: Benchmarks handling of Unicode characters with and without ASCII-only mode
-   **Long text truncation**: Benchmarks slug generation with length limits and truncation
-   **Special characters**: Benchmarks processing of various special characters with different policies
-   **Configuration variations**: Benchmarks different separator characters, trimming options, and overloads
-   **Edge cases**: Benchmarks empty strings and whitespace-only inputs

### SlugMemoryBenchmarks

Memory allocation benchmarks focusing on real-world usage patterns and optimization opportunities:

-   **Bulk operations**: Memory impact of processing multiple strings in batches
-   **Collection storage**: Memory behavior when storing results in lists and dictionaries
-   **Unicode vs ASCII**: Memory differences between ASCII-only and Unicode-allowed processing
-   **Chained operations**: Memory usage during sequential slug processing
-   **Large payloads**: Memory allocation patterns for processing many strings
-   **Object reuse**: Comparing memory usage when reusing vs creating new option instances

## Running the Benchmarks

### Quick Run

To run all benchmarks with default settings:

```bash
dotnet run -c Release --project Teqniqly.Sluggo.Benchmarks/Teqniqly.Sluggo.Benchmarks.csproj
```

### Run Specific Benchmark Class

To run only CPU benchmarks:

```bash
dotnet run -c Release --project Teqniqly.Sluggo.Benchmarks/Teqniqly.Sluggo.Benchmarks.csproj -- --filter *SlugCpuBenchmarks*
```

To run only memory benchmarks:

```bash
dotnet run -c Release --project Teqniqly.Sluggo.Benchmarks/Teqniqly.Sluggo.Benchmarks.csproj -- --filter *SlugMemoryBenchmarks*
```

### Run Specific Benchmark Method

To run a specific benchmark method:

```bash
dotnet run -c Release --project Teqniqly.Sluggo.Benchmarks/Teqniqly.Sluggo.Benchmarks.csproj -- --filter *CreateSlug_Simple_Ascii_Default*
```

## Understanding the Results

### CPU Benchmarks

CPU benchmark results include:

-   **Mean**: Average execution time
-   **Error**: Half of 99.9% confidence interval
-   **StdDev**: Standard deviation of all measurements
-   **Allocated**: Memory allocated per operation

### Memory Benchmarks

Memory benchmark results include:

-   **Gen0**: Number of Gen 0 collections per 1000 operations
-   **Gen1**: Number of Gen 1 collections per 1000 operations
-   **Allocated**: Total memory allocated

## Benchmark Configuration

The benchmarks use the following BenchmarkDotNet configurations:

-   **MemoryDiagnoser**: Enabled on all benchmarks to track memory allocations
-   **SimpleJob** (Memory benchmarks only): 3 warmup iterations, 10 measurement iterations for consistent memory measurements

## Output

Results are saved in `BenchmarkDotNet.Artifacts` directory:

-   **results/**: Contains detailed benchmark results in various formats (HTML, Markdown, CSV)
-   **logs/**: Execution logs for debugging
-   **bin/**: Compiled benchmark executables

## Performance Considerations

When analyzing benchmark results, consider:

1.   **CPU Performance**: Lower execution times indicate better performance
2.   **Memory Allocations**: Fewer allocations reduce GC pressure
3.   **GC Collections**: Fewer collections (especially Gen1+) indicate better memory efficiency
4.   **Unicode Impact**: Unicode processing typically takes longer than ASCII-only
5.   **Configuration Trade-offs**: Different options have different performance characteristics

## Baseline Results

### CPU Benchmarks

**Key Takeaways:**

-   Simple ASCII slug generation is extremely fast (~1.1-2.3 μs)
-   Unicode processing adds significant overhead (~2.3 μs vs ~1.1 μs for ASCII)
-   Long text truncation is expensive due to string operations (~9.5 μs)
-   Memory allocation is minimal for most operations (1896-2976 B)
-   Empty/whitespace inputs are very fast (~200-211 ns)

### Memory Benchmarks

**Key Takeaways:**

-   **Bulk operations are efficient**: Processing 1000 strings takes ~1.8-2.0 ms
-   **Unicode processing saves memory**: Unicode-allowed mode uses slightly less memory than ASCII-only
-   **Collection storage overhead**: Lists are efficient (~1.78 MB for 1000 strings), dictionaries add overhead (~2.74 MB)
-   **Chained operations are expensive**: Processing 128 chained operations takes ~7.3 ms and allocates ~8.9 MB
-   **Large payloads scale well**: Processing 1000 strings takes ~4.7 ms with ~5 MB allocation
-   **Object reuse is beneficial**: Reusing option instances saves memory vs creating new ones

## Best Practices for Running Benchmarks

1.   **Close unnecessary applications** to reduce system noise
2.   **Run in Release configuration** (never Debug) for accurate results
3.   **Allow benchmarks to complete** without interruption
4.   **Run multiple times** to verify consistency
5.   **Compare relative performance** rather than absolute numbers across different machines

## Contributing New Benchmarks

When adding new benchmarks:

1.   Add methods to existing benchmark classes or create new ones
2.   Use `[Benchmark]` attribute on benchmark methods
3.   Include XML documentation explaining what is being measured
4.   Use descriptive method names (underscores are allowed for readability)
5.   Follow the existing naming patterns for consistency

## Implementation Details

### Test Data

Benchmarks use realistic test data including:

-   Simple ASCII strings ("Hello World")
-   Unicode text with diacritics ("Côte d'Azur & Café München")
-   Special characters and symbols ("Test@Symbol&More#Stuff!")
-   Long text for truncation testing
-   Empty strings and whitespace-only inputs

### Configuration Options Tested

-   Default settings (ASCII-only, hyphen separator, trimming enabled)
-   Unicode-allowed mode
-   Different separators (hyphen, underscore)
-   Extended character policies
-   Length truncation
-   Separator trimming disabled
-   Various option combinations

### Iteration Counts

-   CPU benchmarks: Single operations (measured individually)
-   Memory benchmarks: 1000 iterations for bulk operations, 128 iterations for chained operations
