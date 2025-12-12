namespace UmbracoProject.Extensions;

/// <summary>
/// Extension methods for string manipulation
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Replaces special characters including line breaks, tabs, and other whitespace characters
    /// </summary>
    /// <param name="input">The input string</param>
    /// <param name="replacement">The replacement string (default is a space)</param>
    /// <returns>String with special characters replaced</returns>
    public static string? ReplaceSpecialCharacters(this string? input, string replacement = " ")
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        // Replace line breaks (Windows, Unix, and Mac styles)
        var result = input
            .Replace("\r\n", replacement) // Windows line break
            .Replace("\n", replacement)   // Unix/Linux line break
            .Replace("\r", replacement);  // Old Mac line break

        // Replace other special whitespace characters
        result = result
            .Replace("\t", replacement)   // Tab
            .Replace("\f", replacement)   // Form feed
            .Replace("\v", replacement);  // Vertical tab

        return result;
    }

    /// <summary>
    /// Replaces special characters and normalizes multiple spaces into single space
    /// </summary>
    /// <param name="input">The input string</param>
    /// <returns>String with special characters replaced and normalized whitespace</returns>
    public static string? ReplaceSpecialCharactersAndNormalize(this string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        var result = input.ReplaceSpecialCharacters(" ");
        
        if (result == null)
        {
            return null;
        }
        
        // Replace multiple spaces with a single space
        while (result.Contains("  "))
        {
            result = result.Replace("  ", " ");
        }

        return result.Trim();
    }
}
