// Eithery: Eloquent Extensions
// Class DictionaryExtensions
// Contains extension methods for IDictionary<TKey,TVal> interface
//
using System.Collections.Generic;

namespace EloquentExtensions
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Merges a collection of dictionaries into the specified source dictionary
        /// </summary>
        /// <param name="dict">A source dictionary containing the merge result</param>
        /// <param name="dictsToMerge">A collection of dictionaries to be merged</param>
        /// <returns>A source dictionary containing all values from dictionaries being merged</returns>
        public static IDictionary<TKey,TValue> Merge<TKey,TValue>(this IDictionary<TKey,TValue> dict,
            params IDictionary<TKey,TValue>[] dictsToMerge)
        {
            Guard.NotNull(dict, nameof(dict));
            Guard.NotNull(dictsToMerge, nameof(dictsToMerge));

            foreach (var d in dictsToMerge)
            {
                foreach (var key in d.Keys)
                    dict[key] = d[key];
            }
            return dict;
        }
    }
}
