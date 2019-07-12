// (C) Eithery
// Class ListExtensions
// Contains extension methods for IList<T> interface
//
using System.Collections.Generic;

namespace EloquentExtensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// Adds a collection of items to the given list
        /// </summary>
        /// <param name="list">A source list</param>
        /// <param name="items">A collection of items being added</param>
        public static void AddRange<T>(this IList<T> list, IEnumerable<T> items) => list.DoAddRange(items);

        /// <summary>
        /// Adds multiple items to the given list
        /// </summary>
        /// <param name="list">A source list</param>
        /// <param name="items">Items being added</param>
        public static void AddRange<T>(this IList<T> list, params T[] items) => list.DoAddRange(items);


        private static void DoAddRange<T>(this IList<T> list, IEnumerable<T> items)
        {
            Guard.NotNull(list, nameof(list));

            if (list is List<T>)
                ((List<T>)list).AddRange(items);
            else
            {
                foreach (var item in items)
                    list.Add(item);
            }
        }
    }
}
