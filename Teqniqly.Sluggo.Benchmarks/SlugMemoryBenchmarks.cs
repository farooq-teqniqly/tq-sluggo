using BenchmarkDotNet.Attributes;
using Teqniqly.Sluggo;

namespace Teqniqly.Sluggo.Benchmarks;

/// <summary>
/// Memory benchmarks for measuring allocation patterns in realistic slug generation scenarios.
/// </summary>
[MemoryDiagnoser]
public class SlugMemoryBenchmarks
{
    // Iteration count for bulk operations
    private const int IterationCount = 1000;

    // Pre-configured options for different scenarios
    private readonly SlugOptions _defaultOptions = new();

    private readonly SlugOptions _extendedOptions = new()
    {
        Allowed = AllowedCharPolicy.UrlFriendlyExtended,
    };

    // Test data for bulk operations
    private readonly string[] _testStrings =
    [
        "Hello World",
        "Côte d'Azur & Café München",
        "Test@Symbol&More#Stuff!",
        "Simple text",
        "Unicode: naïve résumé",
        "Long text that should be processed efficiently",
        "Short",
        "Another test case with special chars: @#$%^&*()",
        "Mixed content: 123 ABC def",
        "Edge case:   multiple   spaces   ",
    ];
    private readonly SlugOptions _unicodeOptions = new() { AsciiOnly = false };

    /// <summary>
    /// Benchmarks bulk slug generation with default options, storing results in a list.
    /// </summary>
    [Benchmark]
    public List<string> BulkCreateSlugs_Default_Options()
    {
        var results = new List<string>(IterationCount);

        for (var i = 0; i < IterationCount; i++)
        {
            var input = _testStrings[i % _testStrings.Length];
            results.Add(Slug.From(input, _defaultOptions));
        }

        return results;
    }

    /// <summary>
    /// Benchmarks bulk slug generation with extended allowed characters, storing results in a list.
    /// </summary>
    [Benchmark]
    public List<string> BulkCreateSlugs_Extended_Chars()
    {
        var results = new List<string>(IterationCount);

        for (var i = 0; i < IterationCount; i++)
        {
            var input = _testStrings[i % _testStrings.Length];
            results.Add(Slug.From(input, _extendedOptions));
        }

        return results;
    }

    /// <summary>
    /// Benchmarks bulk slug generation allowing Unicode characters, storing results in a list.
    /// </summary>
    [Benchmark]
    public List<string> BulkCreateSlugs_Unicode_Allowed()
    {
        var results = new List<string>(IterationCount);

        for (var i = 0; i < IterationCount; i++)
        {
            var input = _testStrings[i % _testStrings.Length];
            results.Add(Slug.From(input, _unicodeOptions));
        }

        return results;
    }

    /// <summary>
    /// Benchmarks chained slug operations simulating real-world usage patterns.
    /// </summary>
    [Benchmark]
    public List<string> Chained_Slug_Operations()
    {
        var results = new List<string>(IterationCount);

        for (var i = 0; i < IterationCount; i++)
        {
            var input = _testStrings[i % _testStrings.Length];

            // Chain multiple operations
            var slug1 = Slug.From(input);
            var slug2 = Slug.From(slug1 + " suffix");
            var slug3 = Slug.From(slug2, 50, '_');

            results.Add(slug3);
        }

        return results;
    }

    /// <summary>
    /// Benchmarks creating new options instances for each operation.
    /// </summary>
    [Benchmark]
    public List<string> Create_New_Options_Instance()
    {
        var results = new List<string>(IterationCount);

        for (var i = 0; i < IterationCount; i++)
        {
            var input = _testStrings[i % _testStrings.Length];
            var options = new SlugOptions { MaxLength = 100, Separator = '-' };
            results.Add(Slug.From(input, options));
        }

        return results;
    }

    /// <summary>
    /// Benchmarks filtering and storing slugs using LINQ operations.
    /// </summary>
    [Benchmark]
    public List<string> Filter_And_Store_Slugs_With_Linq()
    {
        var results = new List<string>();

        for (var i = 0; i < IterationCount; i++)
        {
            var input = _testStrings[i % _testStrings.Length];
            var slug = Slug.From(input);

            // Simulate LINQ-like filtering
            if (slug.Length > 5)
            {
                results.Add(slug);
            }
        }

        return results;
    }

    /// <summary>
    /// Benchmarks processing large payloads with many strings.
    /// </summary>
    [Benchmark]
    public List<string> Process_Large_Payload()
    {
        var largeInputs = new string[IterationCount];

        for (var i = 0; i < IterationCount; i++)
        {
            largeInputs[i] =
                $"Input {i}: {_testStrings[i % _testStrings.Length]} with additional content";
        }

        var results = new List<string>(IterationCount);

        foreach (var input in largeInputs)
        {
            results.Add(Slug.From(input));
        }

        return results;
    }

    /// <summary>
    /// Benchmarks object reuse vs new instance creation patterns.
    /// </summary>
    [Benchmark]
    public List<string> Reuse_Options_Instance()
    {
        var results = new List<string>(IterationCount);
        var options = new SlugOptions { MaxLength = 100, Separator = '-' };

        for (var i = 0; i < IterationCount; i++)
        {
            var input = _testStrings[i % _testStrings.Length];
            results.Add(Slug.From(input, options));
        }

        return results;
    }

    /// <summary>
    /// Benchmarks storing slug results in a dictionary with string keys.
    /// </summary>
    [Benchmark]
    public Dictionary<string, string> StoreSlugs_In_Dictionary()
    {
        var results = new Dictionary<string, string>(IterationCount);

        for (var i = 0; i < IterationCount; i++)
        {
            var input = _testStrings[i % _testStrings.Length];
            var slug = Slug.From(input);
            results[input] = slug;
        }

        return results;
    }
}
