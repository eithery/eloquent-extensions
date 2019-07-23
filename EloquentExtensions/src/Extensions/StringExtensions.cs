// Eithery: Eloquent Extensions
// Class StringExtensions
// Contains extension methods for System.String class
//
using System;

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
    }
}
