// Eithery: Eloquent Extensions
// Class MemberInfoExtensions
// Contains extension methods for System.Reflection.MemberInfo class
//
using System.ComponentModel;
using System.Reflection;

namespace EloquentExtensions
{
    public static class MemberInfoExtensions
    {
        /// <summary>
        /// Gets a display name of the given member info
        /// </summary>
        /// <param name="memberInfo">The member info</param>
        /// <param name="inherit">Determines whether to search specified member's
        /// inheritance chain to find the attributes</param>
        /// <returns>A string display name</returns>
        public static string DisplayName(this MemberInfo memberInfo, bool inherit=false)
        {
            var attr = memberInfo.GetAttribute<DisplayNameAttribute>(inherit);
            return attr?.DisplayName ?? memberInfo.Name;
        }
    }
}
