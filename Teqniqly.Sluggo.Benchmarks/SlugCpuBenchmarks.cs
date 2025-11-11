using BenchmarkDotNet.Attributes;

namespace Teqniqly.Sluggo.Benchmarks;

/// <summary>
/// CPU benchmarks for measuring execution time of individual slug generation operations.
/// </summary>
[MemoryDiagnoser]
public class SlugCpuBenchmarks
{
    private const string EmptyString = "";
    private const string LongText =
        "This is a very long text that should be truncated when the maximum length is set to a smaller value than the generated slug would be";

    // Test data constants
    private const string SimpleAscii = "Hello World";
    private const string SpecialChars = "Test@Symbol&More#Stuff!";
    private const string UnicodeText = "Côte d'Azur & Café München";
    private const string WhitespaceOnly = "   \t\n  ";

    private readonly SlugOptions _extendedOptions = new()
    {
        Allowed = AllowedCharPolicy.UrlFriendlyExtended,
    };

    private readonly SlugOptions _noTrimOptions = new() { TrimSeparators = false };
    private readonly SlugOptions _shortLengthOptions = new() { MaxLength = 20 };
    private readonly SlugOptions _underscoreOptions = new()
    {
        Separator = '_',
        Allowed = AllowedCharPolicy.LettersDigitsUnderscore,
    };

    // Pre-configured options for different scenarios
    private readonly SlugOptions _unicodeOptions = new() { AsciiOnly = false };

    /// <summary>
    /// Benchmarks empty string input.
    /// </summary>
    [Benchmark]
    public string CreateSlug_Empty_String()
    {
        return Slug.From(EmptyString);
    }

    /// <summary>
    /// Benchmarks long text slug generation with length truncation.
    /// </summary>
    [Benchmark]
    public string CreateSlug_Long_Text_Truncated()
    {
        return Slug.From(LongText, _shortLengthOptions);
    }

    /// <summary>
    /// Benchmarks slug generation without separator trimming.
    /// </summary>
    [Benchmark]
    public string CreateSlug_No_Trim_Separators()
    {
        return Slug.From("  Test String  ", _noTrimOptions);
    }

    /// <summary>
    /// Benchmarks simple ASCII slug generation with default options.
    /// </summary>
    [Benchmark]
    public string CreateSlug_Simple_Ascii_Default()
    {
        return Slug.From(SimpleAscii);
    }

    /// <summary>
    /// Benchmarks simple overload with custom max length and separator.
    /// </summary>
    [Benchmark]
    public string CreateSlug_Simple_Overload_Custom()
    {
        return Slug.From(SimpleAscii, 50, '_');
    }

    /// <summary>
    /// Benchmarks text with special characters using default options.
    /// </summary>
    [Benchmark]
    public string CreateSlug_Special_Chars_Default()
    {
        return Slug.From(SpecialChars);
    }

    /// <summary>
    /// Benchmarks text with special characters using extended allowed characters.
    /// </summary>
    [Benchmark]
    public string CreateSlug_Special_Chars_Extended()
    {
        return Slug.From(SpecialChars, _extendedOptions);
    }

    /// <summary>
    /// Benchmarks slug generation with underscore separator.
    /// </summary>
    [Benchmark]
    public string CreateSlug_Underscore_Separator()
    {
        return Slug.From(SimpleAscii, _underscoreOptions);
    }

    /// <summary>
    /// Benchmarks Unicode text slug generation with default ASCII-only options.
    /// </summary>
    [Benchmark]
    public string CreateSlug_Unicode_Text_Default()
    {
        return Slug.From(UnicodeText);
    }

    /// <summary>
    /// Benchmarks Unicode text slug generation allowing Unicode characters.
    /// </summary>
    [Benchmark]
    public string CreateSlug_Unicode_Text_Unicode_Allowed()
    {
        return Slug.From(UnicodeText, _unicodeOptions);
    }

    /// <summary>
    /// Benchmarks whitespace-only input.
    /// </summary>
    [Benchmark]
    public string CreateSlug_Whitespace_Only()
    {
        return Slug.From(WhitespaceOnly);
    }
}
