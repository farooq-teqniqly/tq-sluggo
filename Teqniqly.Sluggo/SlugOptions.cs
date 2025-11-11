namespace Teqniqly.Sluggo
{
    public sealed class SlugOptions
    {
        /// <summary>
        /// Which ASCII characters beyond [a-z0-9] are allowed.
        /// </summary>
        public AllowedCharPolicy Allowed { get; init; } = AllowedCharPolicy.BasicLatinLettersDigits;
        public bool AsciiOnly { get; init; } = true;

        /// <summary>
        /// Single-character fallbacks (applied post-diacritic stripping).
        /// </summary>
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
        /// Collapse consecutive separators into one.
        /// </summary>
        public bool CollapseSeparators { get; init; } = true;
        public bool Lowercase { get; init; } = true;
        public int MaxLength { get; init; } = 120;

        /// <summary>
        /// Multi-character replacements applied before normalization (readability).
        /// </summary>
        public IReadOnlyDictionary<string, string> PreReplacements { get; init; } =
            new Dictionary<string, string>(StringComparer.Ordinal)
            {
                ["&"] = " and ",
                ["@"] = " at ",
                ["’"] = "'",
                ["–"] = "-",
                ["—"] = "-",
            };
        public char Separator { get; init; } = '-';

        /// <summary>
        /// Trim leading/trailing separators.
        /// </summary>
        public bool TrimSeparators { get; init; } = true;
    }
}
