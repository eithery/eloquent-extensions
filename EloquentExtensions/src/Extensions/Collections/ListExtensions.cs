// Eithery: Eloquent Extensions
// Class ListExtensions
// Contains extension methods for IList<T> interface
//
using System;
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


        /// <summary>
        /// Adds an element to the end of the given list if the specified condition predicate returns true
        /// </summary>
        /// <param name="list">A source list</param>
        /// <param name="value">An element to be added to a list</param>
        /// <param name="condition">Determines whether an element should be added to the list</param>
        /// <returns>True, if the specified element added to the list; otherwise, false</returns>
        public static bool AddIf<T>(this IList<T> list, T value, Func<IList<T>,T,bool> condition)
        {
            Guard.NotNull(list, nameof(list));
            Guard.NotNull(condition, nameof(condition));

            var toBeAdded = condition(list, value);
            if (toBeAdded)
                list.Add(value);
            return toBeAdded;
        }


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
