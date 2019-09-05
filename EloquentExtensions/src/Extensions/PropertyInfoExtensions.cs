// Eithery: Eloquent Extensions
// Class PropertyInfoExtensions
// Contains extension methods for System.Reflection.PropertyInfo class
//
using System.Reflection;

namespace EloquentExtensions
{
    public static class PropertyInfoExtensions
    {
        public static bool IsStatic(this PropertyInfo propertyInfo)
        {
            Guard.NotNull(propertyInfo, nameof(propertyInfo));
            var getMethod = propertyInfo.GetGetMethod(true);
            return getMethod.IsStatic;
        }
    }
}
