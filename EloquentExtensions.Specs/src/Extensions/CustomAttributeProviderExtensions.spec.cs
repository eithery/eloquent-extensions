// Eithery: Eloquent Extensions
// Class CustomAttributeProviderExtensionsSpecs
// Contains unit tests/specs for CustomAttributeProviderExtensions class
//
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Machine.Specifications;

namespace EloquentExtensions
{
    [Subject(nameof(CustomAttributeProviderExtensions))]
    public class CustomAttributeProviderExtensionsSpecs
    {
        static PropertyInfo nameProperty;

        Establish context = () => nameProperty = typeof(Customer).GetProperty("Name");

        class HasAttribute
        {
            It returns_true_for_existing_attribute = () =>
            {
                typeof(Customer).HasAttribute<SampleAttribute>().ShouldBeTrue();
                typeof(Customer).HasAttribute<DisplayNameAttribute>().ShouldBeTrue();
                typeof(Customer).HasAttribute<TypeConverterAttribute>().ShouldBeTrue();
                nameProperty.HasAttribute<BrowsableAttribute>().ShouldBeTrue();
            };

            It returns_false_for_missing_attribute = () =>
            {
                typeof(Customer).HasAttribute<BrowsableAttribute>().ShouldBeFalse();
                typeof(Individual).HasAttribute<DisplayNameAttribute>().ShouldBeFalse();
                nameProperty.HasAttribute<DisplayNameAttribute>().ShouldBeFalse();
            };

            It finds_attributes_defined_on_the_base_class = () =>
            {
                typeof(Individual).HasAttribute<DisplayNameAttribute>(inherit: true).ShouldBeTrue();
                typeof(Individual).HasAttribute<SampleAttribute>(inherit: true).ShouldBeTrue();
                typeof(Individual).HasAttribute<SampleAttribute>(inherit: false).ShouldBeFalse();
            };

            It raises_an_exception_for_null_source = () =>
            {
                ICustomAttributeProvider source = null;
                var exception = Catch.Exception(() => source.HasAttribute<DisplayNameAttribute>());
                exception.ShouldBeOfExactType<ArgumentNullException>();
            };

            private PropertyInfo NameProperty(Type type) => type.GetProperty("Name");
        }


        class GetAttribute
        {
            It returns_the_given_attribute_instance = () =>
            {
                var attr = typeof(Customer).GetAttribute<DisplayNameAttribute>();
                attr.ShouldNotBeNull();
                attr.ShouldBeOfExactType<DisplayNameAttribute>();
                attr.DisplayName.ShouldEqual("Dummy customer");

                var browsableAttr = nameProperty.GetAttribute<BrowsableAttribute>();
                browsableAttr.ShouldNotBeNull();
                browsableAttr.Browsable.ShouldBeFalse();
            };

            It returns_the_given_attribute_defined_on_the_base_class = () =>
            {
                var sampleAttribute = typeof(Individual).GetAttribute<SampleAttribute>(inherit: true);
                sampleAttribute.ShouldNotBeNull();
                sampleAttribute.ShouldBeOfExactType<SampleAttribute>();
                sampleAttribute.DummyProperty.ShouldEqual("Sample1");

                var attr = typeof(Individual).GetAttribute<SampleAttribute>(inherit: false);
                attr.ShouldBeNull();
            };

            It returns_null_when_the_given_attribute_is_missing = () =>
            {
                typeof(Customer).GetAttribute<BrowsableAttribute>().ShouldBeNull();
                typeof(Individual).GetAttribute<DisplayNameAttribute>().ShouldBeNull();
                nameProperty.HasAttribute<DisplayNameAttribute>().ShouldBeFalse();
            };

            It raises_an_exception_for_null_source = () =>
            {
                ICustomAttributeProvider source = null;
                var exception = Catch.Exception(() => source.GetAttribute<DisplayNameAttribute>());
                exception.ShouldBeOfExactType<ArgumentNullException>();
            };
        }


        class GetAttributes
        {
            It returns_a_collection_of_attributes = () =>
            {
                var attributes = typeof(Customer).GetAttributes<SampleAttribute>();
                attributes.ShouldNotBeEmpty();
                attributes.Count().ShouldEqual(2);
                attributes.Select(a => a.DummyProperty).ShouldEqual(new []{ "Sample1", "Sample2" });

                var browsableAttrs = nameProperty.GetAttributes<BrowsableAttribute>();
                browsableAttrs.ShouldNotBeEmpty();
                browsableAttrs.First().Browsable.ShouldBeFalse();
            };

            It returns_attributes_defined_on_the_base_class = () =>
            {
                var attributes = typeof(Individual).GetAttributes<DisplayNameAttribute>(inherit: true);
                attributes.ShouldNotBeEmpty();
                attributes.Count().ShouldEqual(1);
                attributes.First().DisplayName.ShouldEqual("Dummy customer");

                attributes = typeof(Individual).GetAttributes<DisplayNameAttribute>(inherit: false);
                attributes.ShouldBeEmpty();
            };

            It returns_an_empty_collection_for_missing_attributes = () =>
            {
                typeof(Individual).GetAttributes<DisplayNameAttribute>().ShouldBeEmpty();
                nameProperty.GetAttributes<DisplayNameAttribute>().ShouldBeEmpty();
            };

            It raises_an_exception_for_null_source = () =>
            {
                ICustomAttributeProvider source = null;
                var exception = Catch.Exception(() => source.GetAttributes<DisplayNameAttribute>());
                exception.ShouldBeOfExactType<ArgumentNullException>();
            };
        }


        class IsBrowsable
        {
            It returns_the_value_of_browsable_attribute = () =>
            {
                typeof(Individual).IsBrowsable().ShouldBeTrue();
                nameProperty.IsBrowsable().ShouldBeFalse();
            };

            It returns_true_for_a_property_not_marked_by_browsable_attribute = () =>
            {
                typeof(Customer).IsBrowsable().ShouldBeTrue();
                var lastNameProperty = typeof(Individual).GetProperty("LastName");
                lastNameProperty.IsBrowsable().ShouldBeTrue();
            };

            It raises_an_exception_for_null_source = () =>
            {
                ICustomAttributeProvider source = null;
                var exception = Catch.Exception(() => source.IsBrowsable());
                exception.ShouldBeOfExactType<ArgumentNullException>();
            };
        }
    }
}
