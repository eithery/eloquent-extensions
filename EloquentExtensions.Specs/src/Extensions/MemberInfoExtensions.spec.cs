// Eithery: Eloquent Extensions
// Class MemberInfoExtensionsSpecs
// Contains unit tests/specs for MemberInfoExtensions class
//
using System;
using System.Reflection;
using Machine.Specifications;

namespace EloquentExtensions.Specs
{
    [Subject(nameof(MemberInfoExtensions))]
    public class MemberInfoExtensionsSpec
    {
        class GetDisplayName
        {
            It returns_a_name_defined_by_the_attribute = () =>
            {
                typeof(Customer).GetDisplayName().ShouldEqual("Dummy customer");
                typeof(ActivationMode).GetDisplayName().ShouldEqual("Available activation modes");
                typeof(Individual).GetProperty("LastName").GetDisplayName().ShouldEqual("Customer last name");
            };

            It returns_a_display_name_defined_on_the_base_class = () =>
            {
                typeof(Individual).GetDisplayName(inherit: true).ShouldEqual("Dummy customer");
                typeof(Individual).GetDisplayName(inherit: false).ShouldEqual("Individual");
            };

            It returns_a_default_member_name_when_not_marked_by_attribute = () =>
            {
                typeof(Customer).GetProperty("Name").GetDisplayName().ShouldEqual("Name");
                typeof(SampleAttribute).GetDisplayName().ShouldEqual("SampleAttribute");
            };

            It raises_an_exception_for_null_member_info = () =>
            {
                MemberInfo memberInfo = null;
                var exception = Catch.Exception(() => memberInfo.GetDisplayName());
                exception.ShouldBeOfExactType<ArgumentNullException>();
            };
        }
    }
}
