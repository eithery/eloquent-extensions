// Eithery: Eloquent Extensions
// Class TypeExtensions
// Contains extension methods for System.Reflection.Type class
//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace EloquentExtensions
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Determines whether the given type has the specified property
        /// </summary>
        /// <param name="type">The type instance to check</param>
        /// <param name="propertyName">The property name</param>
        /// <param name="includeNonPublic">Determines whether non public properties
        /// included to search</param>
        /// <returns>True, if the specified property contained in the given type; otherwise, false</returns>
        public static bool HasProperty(this Type type, string propertyName, bool includeNonPublic=false)
        {
            Guard.NotNull(type, nameof(type));
            Guard.NotBlank(propertyName, nameof(propertyName));

            var bindingFlags = BindingFlags.Instance | BindingFlags.Public;
            if (includeNonPublic)
                bindingFlags |= BindingFlags.NonPublic;
            return type.GetProperty(propertyName.Trim(), bindingFlags) != null;
        }


        /// <summary>
        /// Determines whether the given type is a enumerable type or collection
        /// </summary>
        /// <param name="type">The type to check</param>
        /// <returns>True, if the specified type represents a collection; otherwise, false</returns>
        public static bool IsEnumerable(this Type type)
        {
            Guard.NotNull(type, nameof(type));
            if (type == typeof(string))
                return false;
            return typeof(IEnumerable<>).IsAssignableFrom(type) ||
                typeof(IEnumerable).IsAssignableFrom(type);
        }
    }
}
