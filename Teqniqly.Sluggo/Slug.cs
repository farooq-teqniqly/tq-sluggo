using System.Globalization;
using System.Text;

namespace Teqniqly.Sluggo
{
    /// <summary>
    /// Provides methods for generating URL-safe slugs from arbitrary strings.
    /// </summary>
    /// <remarks>
    /// This class implements a deterministic, Unicode-aware slug generation algorithm that:
    /// <list type="bullet">
    /// <item>Normalizes Unicode text using NFKD normalization</item>
    /// <item>Strips diacritic marks for ASCII compatibility</item>
    /// <item>Applies configurable character filtering and mapping</item>
    /// <item>Handles separator compaction and trimming</item>
    /// <item>Enforces maximum length constraints</item>
    /// </list>
    /// </remarks>
    public static class Slug
    {
        /// <summary>
        /// Generates a URL-safe slug from the specified input string using default options with custom max length and separator.
        /// </summary>
        /// <param name="input">The input string to convert to a slug. Can be null or empty.</param>
        /// <param name="maxLength">The maximum length of the generated slug. Default is 120 characters.</param>
        /// <param name="separator">The character to use as a separator. Default is '-'.</param>
        /// <returns>A URL-safe slug string, or empty string if input is null or whitespace.</returns>
        /// <example>
        /// <code>
        /// string slug = Slug.From("Hello World!");
        /// // Result: "hello-world"
        /// </code>
        /// </example>
        public static string From(string? input, int maxLength = 120, char separator = '-') =>
            From(input, new SlugOptions { MaxLength = maxLength, Separator = separator });

        /// <summary>
        /// Generates a URL-safe slug from the specified input string using the provided options.
        /// </summary>
        /// <param name="input">The input string to convert to a slug. Can be null or empty.</param>
        /// <param name="options">The configuration options for slug generation.</param>
        /// <returns>A URL-safe slug string, or empty string if input is null or whitespace.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="options"/> is null.</exception>
        /// <example>
        /// <code>
        /// var options = new SlugOptions
        /// {
        ///     Separator = '_',
        ///     MaxLength = 50,
        ///     Allowed = AllowedCharPolicy.LettersDigitsUnderscore
        /// };
        /// string slug = Slug.From("Côte d'Azur & Café", options);
        /// // Result: "cote_d_azur_and_cafe"
        /// </code>
        /// </example>
        public static string From(string? input, SlugOptions options)
        {
            ArgumentNullException.ThrowIfNull(options);

            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            var pre = ApplyPreReplacements(input, options.PreReplacements).Trim();
            var normalized = pre.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder(normalized.Length);
            var prevWasSep = false;

            for (var i = 0; i < normalized.Length; i++)
            {
                var ch = normalized[i];

                // Skip diacritic marks
                var cat = CharUnicodeInfo.GetUnicodeCategory(ch);

                if (cat == UnicodeCategory.NonSpacingMark)
                {
                    continue;
                }

                var c = options.Lowercase ? char.ToLowerInvariant(ch) : ch;

                // Fast ASCII path
                if (c <= 0x7F)
                {
                    if (IsAllowedAscii(c, options))
                    {
                        sb.Append(c);
                        prevWasSep = false;
                        continue;
                    }

                    // If not allowed ASCII, treat as separator
                    AppendSeparatorIfNeeded(
                        sb,
                        ref prevWasSep,
                        options.Separator,
                        options.CollapseSeparators
                    );
                    continue;
                }

                // Non-ASCII
                if (!options.AsciiOnly && char.IsLetterOrDigit(c))
                {
                    // If keeping wider Unicode, allow letters and digits
                    sb.Append(c);
                    prevWasSep = false;
                    continue;
                }

                // Try a CharMap fallback (e.g., 'ß'->"ss", 'æ'->"ae")
                if (
                    options.CharMap is not null
                    && (
                        options.CharMap.TryGetValue(c, out var mapped)
                        || (c != ch && options.CharMap.TryGetValue(ch, out mapped))
                    )
                )
                {
                    AppendMapped(sb, mapped, ref prevWasSep, options.Separator, options);
                    continue;
                }

                // Otherwise separator
                AppendSeparatorIfNeeded(
                    sb,
                    ref prevWasSep,
                    options.Separator,
                    options.CollapseSeparators
                );
            }

            // 4) Trim leading/trailing separators if configured
            var result = options.TrimSeparators
                ? TrimSeparators(sb.ToString(), options.Separator)
                : sb.ToString();

            // 5) Enforce max length, avoiding trailing separators
            if (result.Length > options.MaxLength && options.MaxLength > 0)
            {
                result = result[..options.MaxLength];

                if (options.TrimSeparators)
                {
                    result = TrimTrailingSeparator(result, options.Separator);
                }
            }

            return result;
        }

        /// <summary>
        /// Appends a mapped character sequence to the StringBuilder, applying the same filtering rules as the main algorithm.
        /// </summary>
        /// <param name="sb">The StringBuilder to append to.</param>
        /// <param name="mapped">The mapped string to process and append.</param>
        /// <param name="prevWasSep">Reference to flag tracking if the previous character was a separator.</param>
        /// <param name="sep">The separator character.</param>
        /// <param name="options">The slug generation options.</param>
        private static void AppendMapped(
            StringBuilder sb,
            string mapped,
            ref bool prevWasSep,
            char sep,
            SlugOptions options
        )
        {
            if (string.IsNullOrEmpty(mapped))
            {
                // Treat empty mapping as a separator
                AppendSeparatorIfNeeded(sb, ref prevWasSep, sep, options.CollapseSeparators);
                return;
            }

            for (var i = 0; i < mapped.Length; i++)
            {
                var m = options.Lowercase ? char.ToLowerInvariant(mapped[i]) : mapped[i];

                if (m <= 0x7F)
                {
                    if (IsAllowedAscii(m, options))
                    {
                        sb.Append(m);
                        prevWasSep = false;
                    }
                    else
                    {
                        AppendSeparatorIfNeeded(
                            sb,
                            ref prevWasSep,
                            sep,
                            options.CollapseSeparators
                        );
                    }
                }
                else
                {
                    if (!options.AsciiOnly && char.IsLetterOrDigit(m))
                    {
                        sb.Append(m);
                        prevWasSep = false;
                    }
                    else
                    {
                        AppendSeparatorIfNeeded(
                            sb,
                            ref prevWasSep,
                            sep,
                            options.CollapseSeparators
                        );
                    }
                }
            }
        }

        /// <summary>
        /// Appends a separator character to the StringBuilder if needed, respecting the collapse separators option.
        /// </summary>
        /// <param name="sb">The StringBuilder to append to.</param>
        /// <param name="prevWasSep">Reference to flag tracking if the previous character was a separator.</param>
        /// <param name="sep">The separator character to append.</param>
        /// <param name="collapse">Whether to collapse consecutive separators into one.</param>
        private static void AppendSeparatorIfNeeded(
            StringBuilder sb,
            ref bool prevWasSep,
            char sep,
            bool collapse
        )
        {
            if (!collapse)
            {
                sb.Append(sep);
                prevWasSep = false; // we appended explicitly (don’t treat as a “blocked” run)
                return;
            }

            if (!prevWasSep && sb.Length > 0)
            {
                sb.Append(sep);
                prevWasSep = true;
            }
        }

        /// <summary>
        /// Applies pre-replacements to the input string before normalization, replacing multi-character tokens with friendlier forms.
        /// </summary>
        /// <param name="input">The input string to process.</param>
        /// <param name="replacements">Dictionary of replacement mappings (key -> replacement value).</param>
        /// <returns>The input string with replacements applied, or the original string if no replacements are configured.</returns>
        private static string ApplyPreReplacements(
            string input,
            IReadOnlyDictionary<string, string> replacements
        )
        {
            if (replacements.Count == 0)
            {
                return input;
            }

            // Simple pass using StringBuilder; replacement keys are small and few.
            var sb = new StringBuilder(input.Length + 8);
            var i = 0;

            while (i < input.Length)
            {
                var replaced = false;

                foreach (var kvp in replacements)
                {
                    var key = kvp.Key;

                    if (string.IsNullOrEmpty(key))
                    {
                        continue;
                    }

                    if (
                        i + key.Length <= input.Length
                        && string.Compare(input, i, key, 0, key.Length, StringComparison.Ordinal)
                            == 0
                    )
                    {
                        sb.Append(kvp.Value);
                        i += key.Length;
                        replaced = true;
                        break;
                    }
                }

                if (!replaced)
                {
                    sb.Append(input[i]);
                    i++;
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Determines if an ASCII character is allowed based on the configured AllowedCharPolicy.
        /// </summary>
        /// <param name="c">The ASCII character to check.</param>
        /// <param name="options">The slug generation options containing the character policy.</param>
        /// <returns>True if the character is allowed, false otherwise.</returns>
        private static bool IsAllowedAscii(char c, SlugOptions options)
        {
            // Fast allow for digits/letters (considering case preservation setting)
            if (
                (c >= '0' && c <= '9')
                || (c >= 'a' && c <= 'z')
                || (!options.Lowercase && c >= 'A' && c <= 'Z')
            )
            {
                return true;
            }

            // Additional ASCII depending on policy
            return options.Allowed switch
            {
                AllowedCharPolicy.BasicLatinLettersDigits => false,
                AllowedCharPolicy.LettersDigitsUnderscore => c == '_',
                AllowedCharPolicy.UrlFriendlyExtended => c is '_' or '.' or '~',
                _ => false,
            };
        }

        /// <summary>
        /// Trims leading and trailing separator characters from the string.
        /// </summary>
        /// <param name="s">The string to trim.</param>
        /// <param name="sep">The separator character to trim.</param>
        /// <returns>The string with leading and trailing separators removed.</returns>
        private static string TrimSeparators(string s, char sep)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }

            var start = 0;

            while (start < s.Length && s[start] == sep)
            {
                start++;
            }

            var end = s.Length - 1;

            while (end >= start && s[end] == sep)
            {
                end--;
            }

            return (start == 0 && end == s.Length - 1) ? s : s.Substring(start, end - start + 1);
        }

        /// <summary>
        /// Trims trailing separator characters from the string, used when enforcing max length constraints.
        /// </summary>
        /// <param name="s">The string to trim.</param>
        /// <param name="sep">The separator character to trim from the end.</param>
        /// <returns>The string with trailing separators removed.</returns>
        private static string TrimTrailingSeparator(string s, char sep)
        {
            var end = s.Length - 1;

            while (end >= 0 && s[end] == sep)
            {
                end--;
            }

            if (end == s.Length - 1)
            {
                return s;
            }

            return s[..(end + 1)];
        }
    }
}
