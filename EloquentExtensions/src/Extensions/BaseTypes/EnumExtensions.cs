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
        /// Gets all attributes of the specified type from the given enum member
        /// </summary>
        /// <typeparam name="T">The attribute type</typeparam>
        /// <param name="source">The enum member</param>
        /// <returns>A collection of attributes</returns>
        public static IEnumerable<T> GetAttributes<T>(this Enum source)
            where T : Attribute
        {
            var memberInfo = source.GetFieldInfo();
            return memberInfo?.GetAttributes<T>() ?? new T[0];
        }


        /// <summary>
        /// Gets a display name of the given enum member
        /// </summary>
        /// <param name="source">The enum member</param>
        /// <returns>A display name of the enum member</returns>
        public static string GetDisplayName(this Enum source) =>
            source.GetFieldInfo()?.GetDisplayName();


        private static FieldInfo GetFieldInfo(this Enum source)
        {
            Guard.NotNull(source, nameof(source));
            var fields = EnumHelper.GetEnumFields(source.GetType());
            return fields.FirstOrDefault(field => Equals(field.GetValue(null), source));
        }
    }
}
