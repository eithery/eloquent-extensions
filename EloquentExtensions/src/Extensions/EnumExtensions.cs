// Eithery: Eloquent Extensions
// Class EnumExtensions
// Contains extension methods for enumerations
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EloquentExtensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets all attributes of the specified type for enum member
        /// </summary>
        /// <typeparam name="T">The type of attribute</typeparam>
        /// <param name="source">The enumeration member</param>
        /// <returns>A collection of attributes</returns>
        public static IEnumerable<T> GetAttributes<T>(this Enum source)
            where T : Attribute
        {
            Guard.NotNull(source, nameof(source));
            var memberInfo = source.GetFieldInfo();
            return memberInfo?.GetAttributes<T>() ?? new T[0];
        }


        private static FieldInfo GetFieldInfo(this Enum source)
        {
            var fields = source.GetType().GetFields(BindingFlags.Public | BindingFlags.Static);
            return fields.FirstOrDefault(field => Equals(field.GetValue(null), source));
        }
    }
}
