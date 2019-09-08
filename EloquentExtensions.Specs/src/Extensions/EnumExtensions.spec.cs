// Eithery: Eloquent Extensions
// Class EnumExtensionsSpecs
// Contains unit tests/specs for EnumExtensions class
//
using System;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;
using Machine.Specifications;

namespace EloquentExtensions
{
    [Subject(typeof(EnumExtensions))]
    public class EnumExtensionsSpecs
    {
        class GetAttributes
        {
            It returns_a_collection_of_attributes = () =>
            {
                var attributes = ActivationMode.Singleton.GetAttributes<DisplayNameAttribute>();
                attributes.ShouldNotBeEmpty();
                attributes.Count().ShouldEqual(1);
                attributes.First().DisplayName.ShouldEqual("Singleton mode");
            };

            It returns_multiple_attributes = () =>
            {
                var attributes = ActivationMode.Client.GetAttributes<XmlElementAttribute>();
                attributes.ShouldNotBeEmpty();
                attributes.Count().ShouldEqual(3);
                attributes.ShouldEqual(new []{
                    new XmlElementAttribute(),
                    new XmlElementAttribute("SomeName"),
                    new XmlElementAttribute(typeof(ActivationMode))
                });
            };

            It returns_an_empty_collection_if_no_attributes_defined = () =>
            {
                DayOfWeek.Sunday.GetAttributes<DisplayNameAttribute>().ShouldBeEmpty();
                ActivationMode.SingleCall.GetAttributes<XmlElementAttribute>().ShouldBeEmpty();
            };

            It returns_an_empty_collection_for_out_of_range_enum_element = () =>
            {
                const DayOfWeek day = (DayOfWeek)224;
                const ActivationMode activationMode = (ActivationMode)(-123);
                day.GetAttributes<DisplayNameAttribute>().ShouldBeEmpty();
                activationMode.GetAttributes<DisplayNameAttribute>().ShouldBeEmpty();
            };

            It raises_an_exception_for_null_source = () =>
            {
                var exception = Catch.Exception(() => EnumExtensions.GetAttributes<DisplayNameAttribute>(null));
                exception.ShouldBeOfExactType<ArgumentNullException>();
            };
        }


        class GetEnumNames
        {
            It returns_names_for_all_enum_members = () =>
            {
                EnumExtensions.GetEnumNames(typeof(Seasons)).ShouldEqual(new []{
                    "Winter",
                    "Spring",
                    "Summer",
                    "Fall"
                });
                EnumExtensions.GetEnumNames(typeof(DayOfWeek)).ShouldEqual(Enum.GetNames(typeof(DayOfWeek)));
            };

            It uses_display_name_attribute_to_get_names = () =>
            {
                EnumExtensions.GetEnumNames(typeof(ActivationMode)).ShouldEqual(new [] {
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
                var exception = Catch.Exception(() => EnumExtensions.GetEnumNames(enumType));
                exception.ShouldBeOfExactType<ArgumentNullException>();
            };

            It raises_an_exception_for_when_the_type_is_not_a_enum = () =>
            {
                var exception = Catch.Exception(() => EnumExtensions.GetEnumNames(typeof(Customer)));
                exception.ShouldBeOfExactType<NotSupportedException>();
            };
        }


        class GetEnumNames_T
        {
            It returns_names_for_all_enum_members = () =>
            {
                EnumExtensions.GetEnumNames<Seasons>().ShouldEqual(new []{
                    "Winter",
                    "Spring",
                    "Summer",
                    "Fall"
                });
                EnumExtensions.GetEnumNames<DayOfWeek>().ShouldEqual(Enum.GetNames(typeof(DayOfWeek)));
            };

            It uses_display_name_attribute_to_get_names = () =>
            {
                EnumExtensions.GetEnumNames<ActivationMode>().ShouldEqual(new [] {
                    "Undefined",
                    "Singleton mode",
                    "Single call mode",
                    "Client activation",
                    "Other",
                    "   "
                });
            };
        }


        class GetDisplayName
        {
            It returns_display_name_for_the_enum_member = () =>
            {
                DayOfWeek.Sunday.GetDisplayName().ShouldEqual("Sunday");
            };

            It uses_display_name_attribute_to_get_a_name = () =>
            {
                ActivationMode.SingleCall.GetDisplayName().ShouldEqual("Single call mode");
                ActivationMode.Failed.GetDisplayName().ShouldEqual("   ");
            };

            It raises_an_exception_for_null_source = () =>
            {
                Enum enumMember = null;
                var exception = Catch.Exception(() => enumMember.GetDisplayName());
                exception.ShouldBeOfExactType<ArgumentNullException>();
            };

            It returns_null_when_enum_member_does_not_have_corresponding_field = () =>
            {
                const DayOfWeek day = (DayOfWeek)224;
                const ActivationMode activationMode = (ActivationMode)(-123);
                day.GetDisplayName().ShouldBeNull();
                activationMode.GetDisplayName().ShouldBeNull();
            };
        }
    }
}
