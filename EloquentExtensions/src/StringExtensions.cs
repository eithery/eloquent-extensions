// (C) Eithery
// Class StringExtensions
// Contains extension methods for System.String class
//
namespace EloquentExtensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Determines whether the given string is blank
        /// </summary>
        /// <param name="source">The source string value</param>
        /// <returns>True, if the given string is blank; otherwise, false</returns>
        public static bool IsBlank(this string source) => string.IsNullOrWhiteSpace(source);

        /// <summary>
        /// Determines whether the given string is not blank
        /// </summary>
        /// <param name="source">The source string value</param>
        /// <returns>True, if the given string is not blank; otherwise, false</returns>
        public static bool IsNotBlank(this string source) => !source.IsBlank();
    }
}
