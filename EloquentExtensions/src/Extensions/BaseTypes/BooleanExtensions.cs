// Eithery: Eloquent Extensions
// Class BooleanExtensions
// Contains extension methods for System.Boolean struct and Nullable<bool> class
//
namespace EloquentExtensions
{
    public static class BooleanExtensions
    {
        /// <summary>
        /// Converts a boolean value to 'yes/no' strings
        /// </summary>
        /// <param name="value">A boolean value</param>
        /// <returns>'yes', if the given boolean value is true; otherwise, 'no'</returns>
        public static string ToYesNo(this bool value) => value ? YES : NO;

        /// <summary>
        /// Converts a nullable boolean value to 'yes/no' strings
        /// </summary>
        /// <param name="value">A nullable boolean value</param>
        /// <param name="nullValue">A string value returned when the given boolean value is null</param>
        /// <returns>'yes', when the given boolean value is true, 'no' when false;
        /// otherwise, returns the specified value for null</returns>
        public static string ToYesNo(this bool? value, string nullValue="") =>
            value.HasValue ? value.Value.ToYesNo() : nullValue;

        /// <summary>
        /// Converts a boolean value to 1/0
        /// </summary>
        /// <param name="value">A boolean value</param>
        /// <returns>1, if the given boolean value is true, otherwise, 0</returns>
        public static int ToOneZero(this bool value) => value ? 1 : 0;

        /// <summary>
        /// Converts a nullable boolean value to 1/0
        /// </summary>
        /// <param name="value">A nullable boolean value</param>
        /// <param name="nullValue">1, when the given boolean value is true, 0 when false;
        /// otherwise, returns the specific value for null</param>
        /// <returns></returns>
        public static int? ToOneZero(this bool? value, int? nullValue=null) =>
            value.HasValue ? value.Value.ToOneZero() : nullValue;


        private const string YES = "yes";

        private const string NO = "no";
    }
}
