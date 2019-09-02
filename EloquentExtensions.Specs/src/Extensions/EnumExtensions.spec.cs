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
            It gets_a_collection_of_attributes = () =>
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
    }
}
