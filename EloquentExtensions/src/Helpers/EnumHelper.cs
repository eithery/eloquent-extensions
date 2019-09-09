// Eithery: Eloquent Extensions
// Class EnumHelper
// Contains enumeration helper methods
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EloquentExtensions
{
    public static class EnumHelper
    {
        /// <summary>
        /// Gets all enum names from the given enum type
        /// </summary>
        /// <param name="enumType">The type of enumeration</param>
        /// <returns>A collection of all enum member names</returns>
        public static IEnumerable<string> GetNames(Type enumType)
        {
            Guard.NotNull(enumType, nameof(enumType));
            if (!enumType.IsEnum)
                throw new NotSupportedException("This operation is supported only for enums");
            return from field in GetEnumFields(enumType) select field.GetDisplayName();
        }


        /// <summary>
        /// Gets all enum names from the given enum type
        /// </summary>
        /// <typeparam name="T">The type of enumetation</typeparam>
        /// <returns>A collection of all enum member names</returns>
        public static IEnumerable<string> GetNames<T>() where T : Enum => GetNames(typeof(T));


        internal static IEnumerable<FieldInfo> GetEnumFields(Type enumType) =>
            enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
    }
}
