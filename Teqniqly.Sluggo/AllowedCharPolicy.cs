namespace Teqniqly.Sluggo
{
    /// <summary>
    /// Defines the policy for which ASCII characters beyond basic Latin letters and digits [a-z0-9] are allowed in generated slugs.
    /// </summary>
    public enum AllowedCharPolicy
    {
        /// <summary>
        /// Only allows basic Latin letters and digits [a-z0-9]. This is the most restrictive policy and produces the safest slugs for URLs and identifiers.
        /// </summary>
        BasicLatinLettersDigits,

        /// <summary>
        /// Allows basic Latin letters, digits, and underscores [a-z0-9_]. Suitable for identifiers that need underscores but should remain URL-safe.
        /// </summary>
        LettersDigitsUnderscore,

        /// <summary>
        /// Allows basic Latin letters, digits, underscores, dots, and tildes [a-z0-9_.~]. Provides maximum flexibility for URL-friendly characters while maintaining readability.
        /// </summary>
        UrlFriendlyExtended,
    }
}
