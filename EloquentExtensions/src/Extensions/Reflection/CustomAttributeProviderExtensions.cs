// Eithery: Eloquent Extensions
// Class CustomAttributeProviderExtensions
// Contains extension methods for System.Reflection.ICustomAttributeProvider interface
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace EloquentExtensions
{
    public static class CustomAttributeProviderExtensions
    {
        /// <summary>
        /// Determines whether the given object is marked by the specified attribute
        /// </summary>
        /// <typeparam name="T">The attribute type</typeparam>
        /// <param name="source">The custom attribute provider</param>
        /// <param name="inherit">Determines whether to search specified member's
        /// inheritance chain to find the attributes</param>
        /// <returns>True, if the object is marked by the specified attribute; otherwise, false</returns>
        public static bool HasAttribute<T>(this ICustomAttributeProvider source, bool inherit=false)
            where T : Attribute => source.GetAttributes<T>(inherit).Any();


        /// <summary>
        /// Gets the given attribute instance from the specified type or member info
        /// </summary>
        /// <typeparam name="T">The attribute type</typeparam>
        /// <param name="source">The custom attribute provider</param>
        /// <param name="inherit">Determines whether to search specified member's
        /// inheritance chain to find the attributes</param>
        /// <returns>An attribute instance</returns>
        public static T GetAttribute<T>(this ICustomAttributeProvider source, bool inherit=false)
            where T : Attribute => source.GetAttributes<T>(inherit).FirstOrDefault();


        /// <summary>
        /// Gets all attributes of the specified type from the type or member info
        /// </summary>
        /// <typeparam name="T">The attribute type</typeparam>
        /// <param name="source">The custom attribute provider</param>
        /// <param name="inherit">Determines whether to search specified member's
        /// inheritance chain to find the attributes</param>
        /// <returns>A collection of attributes</returns>
        public static IEnumerable<T> GetAttributes<T>(
            this ICustomAttributeProvider source,
            bool inherit=false)
            where T : Attribute =>
            source.GetCustomAttributes<T>(inherit).OfType<T>();


        /// <summary>
        /// Determines whether the given type or member is browsable
        /// </summary>
        /// <param name="source">The custom attribute provider</param>
        /// <returns>True, if the type or member is browsable; otherwise, false</returns>
        public static bool IsBrowsable(this ICustomAttributeProvider source)
        {
            var browsableAttribute = source.GetAttribute<BrowsableAttribute>();
            return browsableAttribute?.Browsable ?? true;
        }


        private static object[] GetCustomAttributes<T>(this ICustomAttributeProvider source, bool inherit)
        {
            Guard.NotNull(source, nameof(source));
            return source.GetCustomAttributes(typeof(T), inherit);
        }
    }
}
