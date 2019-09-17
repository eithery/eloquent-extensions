// Eithery: Eloquent Extensions
// Class PropertyInfoExtensionsSpecs
// Contains unit tests/specs for PropertyInfoExtensions class
//
using System;
using System.Reflection;
using System.Threading;
using Machine.Specifications;

namespace EloquentExtensions.Specs
{
    [Subject(typeof(PropertyInfoExtensions))]
    public class PropertyInfoExtensionsSpec
    {
        class IsStatic
        {
            It returns_true_for_static_properties = () =>
            {
                GetProperty<Customer>("TotalCount").IsStatic().ShouldBeTrue();
                GetProperty<Thread>("CurrentThread").IsStatic().ShouldBeTrue();
            };

            It returns_false_for_instance_properties = () =>
            {
                GetProperty<Customer>("Name").IsStatic().ShouldBeFalse();
                GetProperty<string>("Length").IsStatic().ShouldBeFalse();
            };

            It supports_non_public_properties = () =>
            {
                GetProperty<Customer>("PrivateStaticProperty").IsStatic().ShouldBeTrue();
                GetProperty<Customer>("InternalName").IsStatic().ShouldBeFalse();
            };

            It supports_properties_with_setter_only = () =>
                GetProperty<Customer>("SetterOnlyProperty").IsStatic().ShouldBeTrue();

            It raises_an_error_for_null_property_info = () =>
            {
                PropertyInfo propertyInfo = null;
                var exception = Catch.Exception(() => propertyInfo.IsStatic());
                exception.ShouldBeOfExactType<ArgumentNullException>();
            };
        }


        private static PropertyInfo GetProperty<T>(string propertyName) =>
            typeof(T).GetProperty(propertyName,
                BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
    }
}
