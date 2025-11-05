# Sluggo — Design Document

## 1. Overview
**Sluggo** is a small, dependency‑free C# library for generating stable, URL/ID‑safe *slugs* and optional *hash keys* from arbitrary human‑readable strings. It targets robustness (Unicode‑aware, cross‑platform), configurability (custom mappings and separators), and performance (zero allocations beyond necessary transformations).

Typical use cases:
- Keys for databases (Cosmos DB slugs / lookup reservations).
- URL paths and SEO slugs.
- File/folder names.
- Deterministic identifiers (when combined with a hash).

---

## 2. Goals & Non‑Goals
### Goals
- **Deterministic**: same input → same output across OS/cultures.
- **Unicode‑aware**: NFKD normalization and diacritic stripping.
- **Configurable**: custom replacements (e.g., `&` → `and`), separator, max length, allowed ranges.
- **Safe output**: ASCII by default `[a-z0-9-]` with optional relaxed modes.
- **Collision‑resilience**: optional hash helpers (SHA‑256, xxHash32) with safe encodings (Base32 Crockford, Base64Url).
- **No external dependencies** (core).
- **Thread‑safe**: APIs are stateless/immutable.

### Non‑Goals
- NLP/semantic transliteration beyond basic diacritics.
- Locale‑specific grammar rules (e.g., German capitalization rules). We provide hooks to add custom mappings.

---

## 3. Public API (v1)
Namespace: `Sluggo`

```csharp
public static class Slug
{
    // Simple, opinionated default.
    public static string From(string? input, int maxLength = 120, char separator = '-');

    // Configurable pipeline.
    public static string From(string? input, SlugOptions options);
}

public sealed class SlugOptions
{
    public char Separator { get; init; } = '-';
    public int MaxLength { get; init; } = 120;
    public bool Lowercase { get; init; } = true;
    public bool AsciiOnly { get; init; } = true; // if false, keep letters/numbers from wider Unicode categories

    // Character policy
    public AllowedCharPolicy Allowed { get; init; } = AllowedCharPolicy.BasicLatinLettersDigits;

    // Replace map executed before normalization (for readability)
    public IReadOnlyDictionary<string, string> PreReplacements { get; init; } = DefaultReplacements;

    // Custom map applied after diacritics removal but before compaction
    public IReadOnlyDictionary<char, string>? CharMap { get; init; } = DefaultCharMap;

    // If true, collapse consecutive separators into one
    public bool CollapseSeparators { get; init; } = true;

    // If true, trim leading/trailing separators
    public bool TrimSeparators { get; init; } = true;
}

public enum AllowedCharPolicy
{
    BasicLatinLettersDigits,   // [a-z0-9], default
    LettersDigitsUnderscore,   // [a-z0-9_]
    UrlFriendlyExtended        // include ~._
}

public static class HashKey
{
    // sha256 over UTF8 of slug or original; returns Base32 Crockford by default (no ambiguous chars).
    public static string Sha256Base32(ReadOnlySpan<char> input, bool normalizeWithSlug = true);

    // sha256 → base64url (RFC 4648 without padding)
    public static string Sha256Base64Url(ReadOnlySpan<char> input, bool normalizeWithSlug = true);

    // Fast non-cryptographic variant (xxHash32) for short-lived keys
    public static string XxHash32Hex(ReadOnlySpan<char> input, bool normalizeWithSlug = true);
}
```

### Extension/Interop
```csharp
public static class SlugExtensions
{
    public static string ToSlug(this string s) => Slug.From(s);
    public static string ToSlug(this string s, SlugOptions options) => Slug.From(s, options);
}
```

---

## 4. Algorithm
1. **Pre‑replacement pass** on the original string (map multi‑char tokens to friendlier forms):
   - Example defaults: `&` → `and`, `@` → `at`, `’` → `'`, `–`/`—` → `-`.
2. **Unicode normalization to NFKD** to decompose characters into base + diacritics.
3. **Diacritic stripping**: drop `NonSpacingMark` categories.
4. **Character filtering and mapping**:
   - Lowercase (invariant) if configured.
   - Keep allowed characters per `AllowedCharPolicy`.
   - For unsupported characters with known fallbacks, consult `CharMap` (e.g., `ß` → `ss`, `æ` → `ae`, `œ` → `oe`).
   - Any other rune becomes a *separator* token.
5. **Separator compaction**: collapse runs (e.g., `---` → `-`).
6. **Trim** leading/trailing separators if enabled.
7. **Length enforcement** without trailing separator truncation.

Time complexity: `O(n)` over code points. Single pass over normalized input; minimal allocations with a pooled `StringBuilder` or stackalloc buffer for short strings.

---

## 5. Edge Cases & Examples
| Input | Output (default) | Notes |
|---|---|---|
| `Ridge Vineyards` | `ridge-vineyards` | Spaces → `-` |
| `Côte d'Or` | `cote-d-or` | Diacritics removed |
| `Straße` | `strasse` | `ß` → `ss` via `CharMap` |
| `Æsir & Óðinn` | `aesir-and-odinn` | `&`→`and`, ligatures split |
| `North America / United States` | `north-america-united-states` | Punct → separator |
| `  Hello—World!!  ` | `hello-world` | Normalize dashes, trim |
| `中文 标题` (AsciiOnly) | `` (empty) | Dropped (non‑ASCII). With `AsciiOnly=false`, policy would keep letters. |

---

## 6. Configuration Defaults
```csharp
var DefaultReplacements = new Dictionary<string,string>(StringComparer.Ordinal)
{
    ["&"] = " and ",
    ["@"] = " at ",
    ["’"] = "'",
    ["–"] = "-",
    ["—"] = "-"
};

var DefaultCharMap = new Dictionary<char,string>
{
    ['ß'] = "ss",
    ['æ'] = "ae",
    ['œ'] = "oe"
    // Extensible via options
};
```

---

## 7. Hash Key Design
- **When to use**: need opaque, fixed‑width keys or collision‑resilience for “name reservations”.
- **Normalization input**: `normalizeWithSlug=true` → hash the generated slug for stability; otherwise hash the raw input after trimming (documented behavior).
- **Encodings**:
  - `Base32 Crockford` (unambiguous, uppercase by convention, we’ll emit lowercase) → great for keys and URLs.
  - `Base64Url` (compact, URL‑safe, no padding).

**Security note**: choose SHA‑256 for durability; avoid using non‑crypto hashes for security‑critical keys. xxHash32 is provided strictly for speed in low‑risk contexts.

---

## 8. Package & Targeting
- **Package**: `Sluggo` (NuGet)
- **TFMs**: `net8.0`, `netstandard2.0` (broad compatibility)
- **Nullable**: `enable`
- **Analyzer**: ship a tiny analyzer in a future version to flag misuse (e.g., `maxLength < 1`).

---

## 9. API Stability & Versioning
- Semantic Versioning.
- v1 guarantees: `Slug.From(string?, int, char)` signature; default behavior stable (only additive changes).

---

## 10. Performance Considerations
- Use `StringBuilder` with capacity hints (input length).
- Avoid `ToLower()` per char when possible; use `char.ToLowerInvariant`.
- Consider `Rune` enumeration on .NET 6+ for surrogate‑safe loops (benchmarked vs simple char loop).
- Pool buffers via `ArrayPool<char>` for long inputs (optional).
- Micro‑benchmarks using `BenchmarkDotNet`:
  - Cases: ASCII, Latin‑1 with diacritics, long text (2k chars), all‑punct.
  - Metrics: ops/sec, allocations, Gen0 pressure.

---

## 11. Testing Strategy
- **Unit**: edge cases (diacritics, symbols, empty, whitespace runs, ligatures, emoji).
- **Golden tests**: snapshot expected outputs for a corpus (e.g., 500 sample titles).
- **Property tests**: idempotence (slug(slug(x)) == slug(x)), separator constraints, length limits.
- **Culture invariance**: run tests under different `CultureInfo.CurrentCulture` and `CurrentUICulture` (de, tr, ar).

---

## 12. Samples
```csharp
// Default
Slug.From("Château Mouton Rothschild 2018"); // "chateau-mouton-rothschild-2018"

// With custom options
var options = new SlugOptions
{
    Separator = '_',
    MaxLength = 64,
    Allowed = AllowedCharPolicy.LettersDigitsUnderscore,
    PreReplacements = new Dictionary<string,string> { ["&"] = " and " }
};
Slug.From("Æsir & Óðinn", options); // "aesir_and_odinn"

// Hash keys for Cosmos lookup reservation
var key = "sha256:" + HashKey.Sha256Base32("Ridge Vineyards");
```

---

## 13. Implementation Sketch
```csharp
public static string From(string? input, SlugOptions options)
{
    if (string.IsNullOrWhiteSpace(input)) return string.Empty;

    // 1) pre replacements
    var pre = ApplyPreReplacements(input.AsSpan(), options.PreReplacements).Trim();

    // 2) normalize (NFKD)
    string normalized = pre.Normalize(NormalizationForm.FormD);

    // 3) iterate code points
    var sb = new StringBuilder(normalized.Length);
    bool prevSep = false;
    foreach (var ch in normalized)
    {
        var cat = CharUnicodeInfo.GetUnicodeCategory(ch);
        if (cat == UnicodeCategory.NonSpacingMark) continue;

        char c = options.Lowercase ? char.ToLowerInvariant(ch) : ch;

        if (IsAllowedAscii(c, options.Allowed))
        {
            sb.Append(c);
            prevSep = false;
        }
        else if (options.CharMap is not null && options.CharMap.TryGetValue(c, out var mapped))
        {
            AppendMapped(sb, mapped, ref prevSep, options.Separator);
        }
        else
        {
            // treat as separator
            if (options.CollapseSeparators)
            {
                if (!prevSep && sb.Length > 0) sb.Append(options.Separator);
                prevSep = true;
            }
            else sb.Append(options.Separator);
        }
    }

    string result = options.TrimSeparators
        ? sb.ToString().Trim(options.Separator)
        : sb.ToString();

    if (result.Length > options.MaxLength)
        result = result.Substring(0, options.MaxLength).TrimEnd(options.Separator);

    return result;
}
```

---

## 14. Packaging & Repo Layout
```
/src/Sluggo
  Slug.cs
  SlugOptions.cs
  HashKey.cs
  SlugExtensions.cs
  Sluggo.csproj
/tests/Sluggo.Tests
  SlugTests.cs
  HashKeyTests.cs
/bench/Sluggo.Benchmarks
  Benchmarks.cs
/README.md
/CHANGELOG.md
/LICENSE (MIT)
```

**NuGet metadata**
- Title: *Sluggo*
- Description: *Deterministic, Unicode‑aware slug and hash key generator for .NET.*
- Tags: `slug`, `slugify`, `hash`, `url`, `cosmosdb`, `id`, `seo`
- License: MIT
- Repository URL, PackageProjectUrl set from GitHub.

---

## 15. Roadmap
- **v1.1**: Rune‑based iteration for perf, Source Generator for precompiled maps.
- **v1.2**: Optional ICU4N plugin for advanced transliteration.
- **v2.0**: Streaming API (Span<char> in/out) and `ReadOnlySpan<char>` overloads, analyzers package.

---

## 16. Risks & Mitigations
- **Ambiguous transliteration**: keep default map minimal; allow user injection.
- **Breaking behavior changes**: guard via snapshot tests; only additive changes in minor versions.
- **Security**: document that only cryptographic hashes are suitable for unguessable keys; provide safe encoders.
