// Eithery: Eloquent Extensions
// Class DateTimeExtensions
// Contains extension methods for System.DateTime struct and Nullable<DateTime> class
//
using System;
using System.Globalization;

namespace EloquentExtensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Returns a string representation of the given nullable date
        /// </summary>
        /// <param name="date">A date instance</param>
        /// <returns>A string representation of date</returns>
        public static string ToShortDateString(this DateTime? date) => date?.ToShortDateString() ?? "";


        /// <summary>
        /// Returns a string representation of the given nullable date
        /// </summary>
        /// <param name="date">A date instance</param>
        /// <param name="invariantCulture">Determines whether invariant culture is used</param>
        /// <returns>A string representation of date</returns>
        public static string ToShortDateString(this DateTime? date, bool invariantCulture)
        {
            var culture = invariantCulture ? DateTimeFormatInfo.InvariantInfo : DateTimeFormatInfo.CurrentInfo;
            return date?.ToString("d", culture) ?? "";
        }


        /// <summary>
        /// Calculates age in years between the current and given dates
        /// </summary>
        /// <param name="from">The date age calculated from</param>
        /// <returns>Age in years by the current date</returns>
        public static int Age(this DateTime from) => from.Age(DateTime.Today);


        /// <summary>
        /// Calculates age in years between two dates
        /// </summary>
        /// <param name="from">The date age calculated from</param>
        /// <param name="to">The date age calculated to</param>
        /// <returns>Age in years between two dates</returns>
        public static int Age(this DateTime from, DateTime to)
        {
            if (from > to)
                return 0;
            var age = to.Year - from.Year;
            if (from > to.AddYears(-age))
                age--;
            return age;
        }
    }
}
