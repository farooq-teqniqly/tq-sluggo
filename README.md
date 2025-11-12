# Teqniqly.Sluggo

[![NuGet Version](https://img.shields.io/nuget/v/Teqniqly.Sluggo.svg)](https://www.nuget.org/packages/Teqniqly.Sluggo/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Teqniqly.Sluggo.svg)](https://www.nuget.org/packages/Teqniqly.Sluggo/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![Build Status](https://img.shields.io/github/actions/workflow/status/farooq-teqniqly/tq-sluggo/ci.yml)](https://github.com/farooq-teqniqly/tq-sluggo/actions)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=farooq-teqniqly_tq-sluggo&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=farooq-teqniqly_tq-sluggo)

A fast, dependency-free C# library for generating deterministic, URL-safe slugs from arbitrary strings with Unicode support.

## Table of Contents

-   [Overview](#overview)
-   [The Problem](#the-problem)
-   [The Solution](#the-solution)
-   [Installation](#installation)
-   [Quick Start](#quick-start)
-   [API Reference](#api-reference)
-   [Configuration](#configuration)
-   [Examples](#examples)
-   [Performance](#performance)
-   [License](#license)

## Overview

Teqniqly.Sluggo is a high-performance .NET library that converts human-readable text into URL-safe, SEO-friendly slugs.
It handles Unicode characters, diacritics, and special symbols while providing extensive customization options.

### Key Features

-   **Unicode-aware**: Proper handling of international characters and diacritics
-   **Deterministic**: Same input always produces the same output
-   **Configurable**: Extensive options for separators, character policies, and transformations
-   **High-performance**: Minimal allocations and fast execution
-   **Thread-safe**: All operations are stateless and safe for concurrent use
-   **No dependencies**: Pure .NET implementation

## The Problem

Web applications often need to generate clean, URL-safe identifiers from user-provided text. Common challenges include:

-   Handling special characters and symbols that break URLs
-   Managing Unicode text with diacritics and international characters
-   Ensuring consistent, deterministic output across different environments
-   Balancing readability with URL safety requirements
-   Performance concerns when processing large amounts of text

Traditional approaches often fail with Unicode text, produce inconsistent results, or have poor performance characteristics.

## The Solution

Teqniqly.Sluggo provides a robust, configurable solution that:

-   Uses Unicode NFKD normalization to handle diacritics properly
-   Applies customizable character filtering and mapping
-   Supports multiple character policies for different use cases
-   Offers extensive configuration options while maintaining sensible defaults
-   Delivers excellent performance with minimal memory allocations

## Installation

Install via NuGet Package Manager:

```bash
dotnet add package Teqniqly.Sluggo
```

Or using the NuGet CLI:

```bash
nuget install Teqniqly.Sluggo
```

### Requirements

-   .NET 8.0 or later
-   .NET Standard 2.0 compatible frameworks

## Quick Start

```csharp
using Teqniqly.Sluggo;

// Basic usage with defaults
string slug = Slug.From("Hello World!");
// Result: "hello-world"

// Custom separator and length
string slug2 = Slug.From("Côte d'Azur & Café", maxLength: 50, separator: '_');
// Result: "cote_d_azur_and_cafe"

// Advanced configuration
var options = new SlugOptions
{
    Separator = '-',
    MaxLength = 100,
    AsciiOnly = false, // Keep Unicode letters
    Allowed = AllowedCharPolicy.BasicLatinLettersDigits
};

string slug3 = Slug.From("中文 标题 – V2!", options);
// Result: "中文-标题-v2"
```

## API Reference

### Core Methods

#### `Slug.From(string? input, int maxLength = 120, char separator = '-')`

Generates a slug using default options with custom length and separator.

**Parameters:**

-   `input`: The string to convert (can be null or empty)
-   `maxLength`: Maximum slug length (default: 120)
-   `separator`: Separator character (default: '-')

**Returns:** URL-safe slug string, or empty string if input is null/whitespace

#### `Slug.From(string? input, SlugOptions options)`

Generates a slug with full configuration control.

**Parameters:**

-   `input`: The string to convert (can be null or empty)
-   `options`: Configuration options

**Returns:** URL-safe slug string, or empty string if input is null/whitespace

**Throws:** `ArgumentNullException` if options is null

### Configuration Options

#### `SlugOptions` Class

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `Separator` | `char` | `'-'` | Character used to separate words |
| `MaxLength` | `int` | `120` | Maximum slug length (0 = unlimited) |
| `Lowercase` | `bool` | `true` | Convert to lowercase |
| `AsciiOnly` | `bool` | `true` | Restrict to ASCII characters only |
| `Allowed` | `AllowedCharPolicy` | `BasicLatinLettersDigits` | Additional allowed characters |
| `CollapseSeparators` | `bool` | `true` | Collapse consecutive separators |
| `TrimSeparators` | `bool` | `true` | Trim leading/trailing separators |
| `PreReplacements` | `IReadOnlyDictionary<string, string>` | Common symbols | Multi-character replacements |
| `CharMap` | `IReadOnlyDictionary<char, string>?` | European chars | Single-character mappings |

#### `AllowedCharPolicy` Enum

-   `BasicLatinLettersDigits`: `[a-z0-9]` - Most restrictive, URL-safe
-   `LettersDigitsUnderscore`: `[a-z0-9_]` - For identifiers
-   `UrlFriendlyExtended`: `[a-z0-9_.~]` - Maximum URL compatibility

## Configuration

### Basic Configuration

```csharp
// URL-friendly slugs
var urlOptions = new SlugOptions
{
    Separator = '-',
    MaxLength = 80,
    Allowed = AllowedCharPolicy.BasicLatinLettersDigits
};

// Identifier-friendly slugs
var idOptions = new SlugOptions
{
    Separator = '_',
    MaxLength = 50,
    Allowed = AllowedCharPolicy.LettersDigitsUnderscore
};

// Unicode-preserving slugs
var unicodeOptions = new SlugOptions
{
    AsciiOnly = false,
    Separator = '-',
    MaxLength = 100
};
```

### Advanced Character Mapping

```csharp
var customOptions = new SlugOptions
{
    // Custom pre-replacements
    PreReplacements = new Dictionary<string, string>
    {
        ["&"] = " and ",
        ["@"] = " at ",
        ["Inc."] = " incorporated ",
        ["Dr."] = " doctor "
    },

    // Custom character mappings
    CharMap = new Dictionary<char, string>
    {
        ['ß'] = "ss",
        ['æ'] = "ae",
        ['ø'] = "o",
        ['€'] = "eur",
        ['™'] = "tm"
    }
};
```

## Examples

### Basic Examples

```csharp
// Simple ASCII text
Slug.From("Hello World!");                    // "hello-world"
Slug.From("Ridge Vineyards");                 // "ridge-vineyards"

// Unicode and diacritics
Slug.From("Côte d'Azur");                     // "cote-d-azur"
Slug.From("Straße");                          // "strasse"
Slug.From("Æsir & Óðinn");                    // "aesir-and-odinn"

// Special characters
Slug.From("North America / United States");   // "north-america-united-states"
Slug.From("Château Mouton Rothschild 2018");  // "chateau-mouton-rothschild-2018"

// Edge cases
Slug.From("  Hello—World!!  ");              // "hello-world"
Slug.From("___A---B___");                     // "a-b"
```

### Advanced Examples

```csharp
// Custom separator
var options = new SlugOptions { Separator = '_' };
Slug.From("Hello World!", options);           // "hello_world"

// Unicode preservation
var unicodeOpts = new SlugOptions { AsciiOnly = false };
Slug.From("中文 标题 – V2!", unicodeOpts);    // "中文-标题-v2"

// Extended character policy
var extendedOpts = new SlugOptions
{
    Allowed = AllowedCharPolicy.UrlFriendlyExtended
};
Slug.From("file_v1.0~backup", extendedOpts);  // "file_v1.0~backup"

// Length limiting
Slug.From("This is a very long title that should be truncated", maxLength: 20);
// "this-is-a-very-long"
```

### Real-World Usage Patterns

```csharp
// URL generation
public string GenerateUrlSlug(string title)
{
    return Slug.From(title, maxLength: 80);
}

// Database keys
public string GenerateDbKey(string name)
{
    var options = new SlugOptions
    {
        Separator = '_',
        MaxLength = 64,
        Allowed = AllowedCharPolicy.LettersDigitsUnderscore
    };
    return Slug.From(name, options);
}

// File names
public string GenerateFileName(string title, string extension)
{
    var slug = Slug.From(title, maxLength: 100);
    return $"{slug}.{extension}";
}

// API identifiers
public string GenerateApiId(string displayName)
{
    return Slug.From(displayName, maxLength: 50, separator: '-');
}
```

## Performance

Teqniqly.Sluggo is designed for high performance with minimal memory allocations:

### Benchmark Results (Approximate)

| Operation | Mean Time | Memory Allocated |
|-----------|-----------|------------------|
| Simple ASCII | ~1.1 μs | ~1.9 KB |
| Unicode text | ~2.3 μs | ~3.0 KB |
| Long text (truncated) | ~9.5 μs | ~4.0 KB |
| Empty input | ~200 ns | ~0.2 KB |

### Performance Characteristics

-   **O(n) time complexity** where n is input string length
-   **Minimal allocations** using StringBuilder pooling
-   **Culture-invariant** operations for consistent results
-   **Thread-safe** with no shared state

### Memory Benchmarks

-   Bulk processing (1000 strings): ~1.8-2.0 ms
-   Collection storage efficient: ~1.78 MB for 1000 strings
-   Unicode processing uses slightly less memory than ASCII-only mode

For detailed performance analysis, see the [benchmarks README](Teqniqly.Sluggo.Benchmarks/README.md).

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

**Teqniqly.Sluggo** - Making URL slugs simple, fast, and Unicode-aware.
