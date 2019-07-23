// Eithery: Eloquent Extensions
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
    }
}
