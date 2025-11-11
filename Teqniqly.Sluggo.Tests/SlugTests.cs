using System.Globalization;

namespace Teqniqly.Sluggo.Tests
{
    public sealed class SlugTests
    {
        [Fact]
        public void From_Given_Custom_CharMap_Should_Slugify_String()
        {
            var options = new SlugOptions
            {
                CharMap = new Dictionary<char, string>
                {
                    ['ß'] = "ss",
                    ['ø'] = "o",
                    ['Ω'] = "o",
                    ['ω'] = "o",
                },
            };

            var actual = Slug.From("Bøt Ωmega Straße", options);

            Assert.Equal("bot-omega-strasse", actual);
        }

        [Fact]
        public void From_Given_Custom_Options_AsciiOnly_False_Keeps_Unicode_Letters()
        {
            var options = new SlugOptions { AsciiOnly = false };

            Assert.Equal("中文-标题-v2", Slug.From("中文 标题 – V2!", options));
        }

        [Fact]
        public void From_Given_Custom_Options_NoCollapseSeparators_Preserves_Runs()
        {
            var options = new SlugOptions { CollapseSeparators = false, TrimSeparators = false };

            Assert.Equal("a--b", Slug.From("A  B", options));
        }

        [Fact]
        public void From_Given_Custom_Options_Underscore_And_AllowedPolicy_Should_Slugify_String()
        {
            var options = new SlugOptions
            {
                Separator = '_',
                Allowed = AllowedCharPolicy.LettersDigitsUnderscore,
            };

            Assert.Equal("hello_world", Slug.From("Hello World!", options));
        }

        [Fact]
        public void From_Given_Default_Options_Collapses_And_Trims_Separators()
        {
            Assert.Equal("a-b", Slug.From("___A---B___"));
        }

        [Fact]
        public void From_Given_Default_Options_Discards_Unicode_Letters()
        {
            var after = Slug.From("中文 标题 – V2!");
            Assert.Equal("v2", after);
        }

        [Theory]
        [InlineData("Ridge Vineyards", "ridge-vineyards")]
        [InlineData("  Hello—World!!  ", "hello-world")]
        [InlineData("North America / United States", "north-america-united-states")]
        [InlineData("Côte d'Or", "cote-d-or")]
        [InlineData("Straße", "strasse")]
        [InlineData("Æsir & Óðinn", "aesir-and-odinn")]
        [InlineData("Château Mouton Rothschild 2018", "chateau-mouton-rothschild-2018")]
        public void From_Given_Default_Options_Should_Slugify_String(string before, string after)
        {
            Assert.Equal(after, Slug.From(before));
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void From_Given_Null_Or_Empty_String_Returns_Empty_String(string? input)
        {
            Assert.Equal(string.Empty, Slug.From(input));
        }

        [Fact]
        public void From_Is_Culture_Invariant()
        {
            var prevCulture = CultureInfo.CurrentCulture;
            var prevUiCulture = CultureInfo.CurrentUICulture;

            try
            {
                CultureInfo.CurrentCulture = new CultureInfo("tr-TR");
                CultureInfo.CurrentUICulture = new CultureInfo("tr-TR");

                // Turkish 'I' casing should not affect invariant lower
                var actual = Slug.From("INTERCITY");
                Assert.Equal("intercity", actual);
            }
            finally
            {
                CultureInfo.CurrentCulture = prevCulture;
                CultureInfo.CurrentUICulture = prevUiCulture;
            }
        }

        [Theory]
        [InlineData("Château Mouton Rothschild 2018")]
        [InlineData("Æsir & Óðinn")]
        [InlineData("North America / United States")]
        public void From_Is_Idempotent(string input)
        {
            var once = Slug.From(input);
            var twice = Slug.From(once);

            Assert.Equal(once, twice);
        }

        [Theory]
        [InlineData("ABC", "ABC")]
        [InlineData("Test", "Test")]
        [InlineData("UPPERCASE", "UPPERCASE")]
        [InlineData("Mixed123", "Mixed123")]
        public void From_When_Lowercase_False_Preserves_Case_For_ASCII_Letters(
            string input,
            string expected
        )
        {
            var options = new SlugOptions { Lowercase = false };

            // All ASCII letters should be preserved with original case when Lowercase = false
            var actual = Slug.From(input, options);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void From_When_Lowercase_False_Preserves_Uppercase_Letters()
        {
            var options = new SlugOptions { Lowercase = false };

            // Uppercase ASCII letters should be preserved when Lowercase = false
            // Currently this fails due to a bug where uppercase letters are treated as separators
            var actual = Slug.From("Abc", options);
            Assert.Equal("Abc", actual); // Expected: "Abc", but bug causes "bc" (leading 'A' treated as separator)
        }

        [Fact]
        public void From_When_Options_Null_Throws_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => Slug.From(string.Empty, null!));
        }

        [Fact]
        public void From_When_String_Greater_Than_Max_Length_Truncates_String()
        {
            var before = "A B C D E F";
            var after = Slug.From(before, maxLength: 7);
            Assert.Equal("a-b-c-d", after);
        }
    }
}
