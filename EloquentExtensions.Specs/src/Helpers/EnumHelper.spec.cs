// Eithery: Eloquent Extensions
// Class EnumHelperSpecs
// Contains unit tests/specs for EnumHelper class
//
using System;
using Machine.Specifications;

namespace EloquentExtensions.Specs
{
    [Subject(typeof(EnumHelper))]
    public class EnumHelperSpec
    {
        class GetNames
        {
            It returns_names_for_all_enum_members = () =>
            {
                EnumHelper.GetNames(typeof(Seasons)).ShouldEqual(new []{
                    "Winter",
                    "Spring",
                    "Summer",
                    "Fall"
                });
                EnumHelper.GetNames(typeof(DayOfWeek)).ShouldEqual(Enum.GetNames(typeof(DayOfWeek)));
            };

            It uses_display_name_attribute_to_get_names = () =>
            {
                EnumHelper.GetNames(typeof(ActivationMode)).ShouldEqual(new [] {
                    "Undefined",
                    "Singleton mode",
                    "Single call mode",
                    "Client activation",
                    "Other",
                    "   "
                });
            };

            It raises_an_exception_for_null_enum_type = () =>
            {
                Type enumType = null;
                var exception = Catch.Exception(() => EnumHelper.GetNames(enumType));
                exception.ShouldBeOfExactType<ArgumentNullException>();
            };

            It raises_an_exception_for_when_the_type_is_not_a_enum = () =>
            {
                var exception = Catch.Exception(() => EnumHelper.GetNames(typeof(Customer)));
                exception.ShouldBeOfExactType<NotSupportedException>();
            };
        }


        class GetNames_T
        {
            It returns_names_for_all_enum_members = () =>
            {
                EnumHelper.GetNames<Seasons>().ShouldEqual(new []{
                    "Winter",
                    "Spring",
                    "Summer",
                    "Fall"
                });
                EnumHelper.GetNames<DayOfWeek>().ShouldEqual(Enum.GetNames(typeof(DayOfWeek)));
            };

            It uses_display_name_attribute_to_get_names = () =>
            {
                EnumHelper.GetNames<ActivationMode>().ShouldEqual(new [] {
                    "Undefined",
                    "Singleton mode",
                    "Single call mode",
                    "Client activation",
                    "Other",
                    "   "
                });
            };
        }
    }
}
