// Eithery: Eloquent Extensions
// Class EnumerableExtensions
// Contains extension methods for IEnumerable<T> interface
//
using System.Collections.Generic;
using System.Linq;

namespace EloquentExtensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Concatenates not blank strings from a collection with optional separator
        /// </summary>
        /// <param name="source">A collection of strings</param>
        /// <param name="separator">A string used as a separator</param>
        /// <returns>A concatenated string</returns>
        public static string Join(this IEnumerable<string> source, string separator="")
        {
            Guard.NotNull(source, nameof(source));

            var parts = from s in source where s.IsNotBlank() select s;
            return parts.Any()
                ? parts.Aggregate((res, next) => res + separator + next)
                : "";
        }
    }
}
