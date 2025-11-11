using System.Globalization;
using System.Text;

namespace Teqniqly.Sluggo
{
    public static class Slug
    {
        public static string From(string? input, int maxLength = 120, char separator = '-') =>
            From(input, new SlugOptions { MaxLength = maxLength, Separator = separator });

        public static string From(string? input, SlugOptions options)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            ArgumentNullException.ThrowIfNull(options);

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

        private static bool IsAllowedAscii(char c, SlugOptions options)
        {
            // Fast allow for digits/letters (lowercase already applied if options.Lowercase == true)
            if (c is >= 'a' and <= 'z' or >= '0' and <= '9')
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
