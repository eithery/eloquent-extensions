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
        /// Gets all enum names from the given enum type
        /// </summary>
        /// <param name="enumType">The type of enumeration</param>
        /// <returns>A collection of all enum member names</returns>
        public static IEnumerable<string> GetEnumNames(Type enumType)
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
        public static IEnumerable<string> GetEnumNames<T>() where T : Enum => GetEnumNames(typeof(T));


        /// <summary>
        /// Gets a display name of the given enum member
        /// </summary>
        /// <param name="source">The enum member</param>
        /// <returns>A display name of the enum member</returns>
        public static string GetDisplayName(this Enum source) =>
            source.GetFieldInfo()?.GetDisplayName();


        private static IEnumerable<FieldInfo> GetEnumFields(Type enumType) =>
            enumType.GetFields(BindingFlags.Public | BindingFlags.Static);


        private static FieldInfo GetFieldInfo(this Enum source)
        {
            Guard.NotNull(source, nameof(source));
            var fields = GetEnumFields(source.GetType());
            return fields.FirstOrDefault(field => Equals(field.GetValue(null), source));
        }
    }
}
