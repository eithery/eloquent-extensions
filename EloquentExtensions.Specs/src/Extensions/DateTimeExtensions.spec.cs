// Eithery: Eloquent Extensions
// Class DateTimeExtensionsSpecs
// Contains unit tests/specs for DateTimeExtensions class
//
using System;
using System.Globalization;
using System.Threading;
using Machine.Specifications;

namespace EloquentExtensions.Specs
{
    [Subject(typeof(DateTimeExtensions))]
    public class DateTimeExtensionsSpec
    {
        class ToShortDateString
        {
            private static DateTime? date;

            Establish context = () => date = new DateTime(1953, 3, 24);

            It returns_a_date_string_representation = () =>
                date.ToShortDateString().ShouldEqual(new DateTime(1953, 3, 24).ToShortDateString());

            It returns_an_empty_string_when_the_given_date_is_null = () =>
            {
                DateTime? nullDate = null;
                nullDate.ToShortDateString().ShouldBeEmpty();
                nullDate.ToShortDateString(invariantCulture: true).ShouldBeEmpty();
                nullDate.ToShortDateString(invariantCulture: false).ShouldBeEmpty();
            };

            It supports_invariant_culture_for_date_string_representation = () =>
                date.ToShortDateString(invariantCulture: true).ShouldEqual("03/24/1953");

            It supports_current_culture_for_date_sting_representation = () =>
            {
                var thread = Thread.CurrentThread;
                var currentCulture = thread.CurrentCulture;
                thread.CurrentCulture = new CultureInfo("ru-RU");
                date.ToShortDateString(invariantCulture: false).ShouldEqual("24.03.1953");
                thread.CurrentCulture = currentCulture;
            };
        }


        class Age
        {
            It returns_age_in_years_between_the_current_and_given_dates = () =>
            {
                var from = DateTime.Today - TimeSpan.FromDays(365 * 10 + 2);
                from.Age().ShouldEqual(10);
                DateTime.Today.Age().ShouldEqual(0);
                (DateTime.Today - TimeSpan.FromDays(366)).Age().ShouldEqual(1);
            };

            It calculates_age_in_years_between_two_dates = () =>
            {
                new DateTime(1937, 4, 12).Age(new DateTime(1937, 4, 13)).ShouldEqual(0);
                new DateTime(1937, 4, 12).Age(new DateTime(1938, 4, 12)).ShouldEqual(1);
                new DateTime(1937, 4, 12).Age(new DateTime(1938, 4, 11)).ShouldEqual(0);
                new DateTime(1937, 4, 12).Age(new DateTime(2019, 9, 9)).ShouldEqual(82);
            };

            It returns_zero_when_the_given_date_later_than_current_date = () =>
                new DateTime(2050, 1, 12).Age().ShouldEqual(0);

            It returns_zero_when_the_start_date_greater_than_the_end_date = () =>
                new DateTime(2050, 1, 12).Age(new DateTime(2010, 1, 12)).ShouldEqual(0);
        }
    }
}
