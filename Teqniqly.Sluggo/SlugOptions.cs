namespace Teqniqly.Sluggo
{
    /// <summary>
    /// Configuration options for customizing slug generation behavior in the Slug class.
    /// </summary>
    /// <remarks>
    /// <para>
    /// SlugOptions provides fine-grained control over how slugs are generated from input strings.
    /// All properties are immutable (init-only) to ensure thread safety and prevent modification after creation.
    /// </para>
    /// <para>
    /// The default configuration produces URL-safe slugs using only lowercase letters, digits, and hyphens [a-z0-9-].
    /// </para>
    /// </remarks>
    /// <example>
    /// <code>
    /// // Basic usage with defaults
    /// var slug1 = Slug.From("Hello World!");
    /// // Result: "hello-world"
    ///
    /// // Custom configuration
    /// var options = new SlugOptions
    /// {
    ///     Separator = '_',
    ///     MaxLength = 50,
    ///     Allowed = AllowedCharPolicy.LettersDigitsUnderscore,
    ///     AsciiOnly = false // Allow Unicode letters
    /// };
    /// var slug2 = Slug.From("Côte d'Azur & Café", options);
    /// // Result: "côte_d_azur_and_café"
    /// </code>
    /// </example>
    public sealed class SlugOptions
    {
        /// <summary>
        /// Gets or sets the policy for which ASCII characters beyond basic Latin letters and digits [a-z0-9] are allowed in the generated slug.
        /// </summary>
        /// <value>The default value is <see cref="AllowedCharPolicy.BasicLatinLettersDigits"/>.</value>
        /// <remarks>
        /// <para>This setting controls which additional ASCII characters can appear in slugs:</para>
        /// <list type="bullet">
        /// <item><see cref="AllowedCharPolicy.BasicLatinLettersDigits"/>: Only [a-z0-9] (most restrictive)</item>
        /// <item><see cref="AllowedCharPolicy.LettersDigitsUnderscore"/>: Allows [a-z0-9_] for identifiers</item>
        /// <item><see cref="AllowedCharPolicy.UrlFriendlyExtended"/>: Allows [a-z0-9_.~] for maximum URL compatibility</item>
        /// </list>
        /// </remarks>
        public AllowedCharPolicy Allowed { get; init; } = AllowedCharPolicy.BasicLatinLettersDigits;

        /// <summary>
        /// Gets or sets a value indicating whether to restrict output to ASCII characters only.
        /// </summary>
        /// <value><c>true</c> to allow only ASCII characters; <c>false</c> to permit Unicode letters and digits. The default value is <c>true</c>.</value>
        /// <remarks>
        /// <para>When <c>true</c>, only ASCII letters, digits, and characters allowed by <see cref="Allowed"/> will appear in the output.</para>
        /// <para>When <c>false</c>, Unicode letters and digits (after diacritic stripping) are preserved, making slugs more readable for non-English content.</para>
        /// <para>Note: Characters not allowed by the current policy or not found in <see cref="CharMap"/> will still be replaced with separators.</para>
        /// </remarks>
        public bool AsciiOnly { get; init; } = true;

        /// <summary>
        /// Gets or sets a dictionary of single-character transliteration mappings applied after diacritic stripping.
        /// </summary>
        /// <value>A dictionary mapping characters to their replacement strings. The default includes common European character mappings.</value>
        /// <remarks>
        /// <para>This dictionary provides fallback transliterations for characters that don't have direct ASCII equivalents.</para>
        /// <para>The mappings are applied after Unicode normalization and diacritic removal, so both the original character and its decomposed form are checked.</para>
        /// <para>Empty string values in the mapping are treated as separators. Set to <c>null</c> to disable all character mappings.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var options = new SlugOptions
        /// {
        ///     CharMap = new Dictionary<char, string>
        ///     {
        ///         ['ß'] = "ss",
        ///         ['æ'] = "ae",
        ///         ['ø'] = "o",
        ///         ['€'] = "eur" // Custom mapping
        ///     }
        /// };
        /// </code>
        /// </example>
        public IReadOnlyDictionary<char, string>? CharMap { get; init; } =
            new Dictionary<char, string>
            {
                ['ß'] = "ss",
                ['æ'] = "ae",
                ['Æ'] = "AE",
                ['œ'] = "oe",
                ['Œ'] = "OE",
                ['ð'] = "d",
            };

        /// <summary>
        /// Gets or sets a value indicating whether consecutive separator characters should be collapsed into a single separator.
        /// </summary>
        /// <value><c>true</c> to collapse multiple consecutive separators; <c>false</c> to preserve them. The default value is <c>true</c>.</value>
        /// <remarks>
        /// <para>When <c>true</c>, sequences like "---" become "-", preventing excessive separator repetition.</para>
        /// <para>When <c>false</c>, each separator-triggering character results in a separator, which can be useful for maintaining character positions.</para>
        /// </remarks>
        public bool CollapseSeparators { get; init; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether the generated slug should be converted to lowercase.
        /// </summary>
        /// <value><c>true</c> to convert to lowercase; <c>false</c> to preserve case. The default value is <c>true</c>.</value>
        /// <remarks>
        /// Uses <see cref="char.ToLowerInvariant"/> for culture-invariant lowercase conversion, ensuring consistent results across different system locales.
        /// </remarks>
        public bool Lowercase { get; init; } = true;

        /// <summary>
        /// Gets or sets the maximum length of the generated slug.
        /// </summary>
        /// <value>The maximum number of characters in the slug. Values less than or equal to 0 disable length limiting. The default value is 120.</value>
        /// <remarks>
        /// <para>If the generated slug exceeds this length, it will be truncated.</para>
        /// <para>When <see cref="TrimSeparators"/> is <c>true</c>, trailing separators are removed after truncation to avoid ending with a separator.</para>
        /// <para>Set to 0 or a negative value to disable length limiting entirely.</para>
        /// </remarks>
        public int MaxLength { get; init; } = 120;

        /// <summary>
        /// Gets or sets a dictionary of multi-character replacement mappings applied before Unicode normalization.
        /// </summary>
        /// <value>A dictionary mapping strings to their replacement strings. The default includes common symbol replacements for readability.</value>
        /// <remarks>
        /// <para>These replacements are applied to the raw input string before any Unicode processing, making them useful for expanding abbreviations or improving readability.</para>
        /// <para>The replacements use ordinal string comparison for performance and predictability.</para>
        /// <para>Null or empty keys will cause an <see cref="ArgumentException"/> to be thrown to prevent infinite loops. Empty values are allowed and will be used as empty string replacements.</para>
        /// <para>Set to an empty dictionary to disable all pre-replacements.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var options = new SlugOptions
        /// {
        ///     PreReplacements = new Dictionary<string, string>
        ///     {
        ///         ["&"] = " and ",
        ///         ["@"] = " at ",
        ///         ["Inc."] = "incorporated",
        ///         ["Dr."] = "doctor"
        ///     }
        /// };
        /// </code>
        /// </example>
        public IReadOnlyDictionary<string, string> PreReplacements { get; init; } =
            new Dictionary<string, string>(StringComparer.Ordinal)
            {
                ["&"] = " and ",
                ["@"] = " at ",
                ["’"] = "'",
                ["–"] = "-",
                ["—"] = "-",
            };

        /// <summary>
        /// Gets or sets the character used as a separator between words in the generated slug.
        /// </summary>
        /// <value>The separator character. The default value is <c>'-'</c>.</value>
        /// <remarks>
        /// <para>Any Unicode character can be used as a separator, but common choices are <c>'-'</c>, <c>'_'</c>, or <c>' '</c>.</para>
        /// <para>The separator character itself will be treated as a literal separator and won't trigger additional separator insertion.</para>
        /// <para>Consider the impact on URL encoding - some characters may require percent-encoding in URLs.</para>
        /// </remarks>
        public char Separator { get; init; } = '-';

        /// <summary>
        /// Gets or sets a value indicating whether leading and trailing separator characters should be trimmed from the final slug.
        /// </summary>
        /// <value><c>true</c> to trim separators; <c>false</c> to preserve them. The default value is <c>true</c>.</value>
        /// <remarks>
        /// <para>When <c>true</c>, separators at the beginning and end of the slug are removed, preventing slugs like "-hello-world-".</para>
        /// <para>When <c>false</c>, leading and trailing separators are preserved, which may be desired for concatenation scenarios.</para>
        /// <para>This setting also affects length truncation - when truncating a long slug, trailing separators are removed if this is <c>true</c>.</para>
        /// </remarks>
        public bool TrimSeparators { get; init; } = true;
    }
}
