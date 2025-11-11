namespace Teqniqly.Sluggo
{
    public enum AllowedCharPolicy
    {
        BasicLatinLettersDigits, // [a-z0-9]
        LettersDigitsUnderscore, // [a-z0-9_]
        UrlFriendlyExtended, // [a-z0-9_.~]
    }
}