// Eithery: Eloquent Extensions
// Class StringExtensions
// Contains extension methods for System.String class
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EloquentExtensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Determines whether the given string is blank
        /// </summary>
        /// <param name="str">A string value</param>
        /// <returns>True, if the given string is blank; otherwise, false</returns>
        public static bool IsBlank(this string str) => string.IsNullOrWhiteSpace(str);

        /// <summary>
        /// Determines whether the given string is not blank
        /// </summary>
        /// <param name="str">A string value</param>
        /// <returns>True, if the given string is not blank; otherwise, false</returns>
        public static bool IsNotBlank(this string str) => !str.IsBlank();

        /// <summary>
        /// Determines whether the given string is empty
        /// </summary>
        /// <param name="str">A string value</param>
        /// <returns>True, if the given string is empty; otherwise, false</returns>
        public static bool IsEmpty(this string str) => string.IsNullOrEmpty(str);

        /// <summary>
        /// Determines whether the given string is not empty
        /// </summary>
        /// <param name="str">A string value</param>
        /// <returns>True, if the given string is not empty; otherwise, false</returns>
        public static bool IsNotEmpty(this string str) => !str.IsEmpty();


        /// <summary>
        /// Determines whether the given string is equivalent of the specified string value
        /// </summary>
        /// <param name="str">A string value</param>
        /// <param name="value">Another string value to check equivalency</param>
        /// <param name="ignoreCase">Determines whether casing is ignored during equivalency check</param>
        /// <param name="trim">Determines whether both strings should be trimmed before equivalency check</param>
        /// <returns>True, if both strings are equivaleng within the specified context; otherwise, false</returns>
        public static bool IsEquivalentOf(this string str, string value, bool ignoreCase=true, bool trim=true)
        {
            if (str == null)
                return trim ? value.IsBlank() : string.IsNullOrEmpty(value);
            if (value == null)
                return trim ? str.IsBlank() : string.IsNullOrEmpty(str);
            if (trim)
            {
                str = str.Trim();
                value = value.Trim();
            }
            var comparisonType = ignoreCase ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture;
            return string.Compare(str, value, comparisonType) == 0;
        }


        /// <summary>
        /// Converts the first character of a string to upper case
        /// </summary>
        /// <param name="str">The string to convert</param>
        /// <returns>The converted string</returns>
        public static string UpperFirst(this string str)
        {
            Guard.NotNull(str, nameof(str));
            return str.Length > 0 ? str.Substring(0, 1).ToUpper() + str.Substring(1) : str;
        }


        /// <summary>
        /// Converts the first character of string to upper case and the remaining to lower case
        /// </summary>
        /// <param name="str">The string to capitalize</param>
        /// <returns>The capitalized string</returns>
        public static string Capitalize(this string str) => UpperFirst(str.ToLower());


        /// <summary>
        /// Converts a string to camel case
        /// </summary>
        /// <param name="str">The string to convert</param>
        /// <returns>The camel cased string</returns>
        public static string Camelize(this string str)
        {
            return null;
        }


        /// <summary>
        /// Splits a string into an array of its words
        /// </summary>
        /// <param name="text">The string to split</param>
        /// <returns>The words of the given string</returns>
        public static IEnumerable<string> Words(this string str) =>
            Regex.Matches(str, @"\w+[^\s]*\w+|\w").OfType<Match>().Select(m => m.Value);
    }
}
