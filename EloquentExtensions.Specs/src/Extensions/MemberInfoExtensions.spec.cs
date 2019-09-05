// Eithery: Eloquent Extensions
// Class MemberInfoExtensionsSpecs
// Contains unit tests/specs for MemberInfoExtensions class
//
using System;
using System.Reflection;
using Machine.Specifications;

namespace EloquentExtensions
{
    [Subject(nameof(MemberInfoExtensions))]
    public class MemberInfoExtensionsSpecs
    {
        class DisplayName
        {
            It returns_a_name_defined_by_the_attribute = () =>
            {
                typeof(Customer).DisplayName().ShouldEqual("Dummy customer");
                typeof(ActivationMode).DisplayName().ShouldEqual("Available activation modes");
                typeof(Individual).GetProperty("LastName").DisplayName().ShouldEqual("Customer last name");
            };

            It returns_a_display_name_defined_on_the_base_class = () =>
            {
                typeof(Individual).DisplayName(inherit: true).ShouldEqual("Dummy customer");
                typeof(Individual).DisplayName(inherit: false).ShouldEqual("Individual");
            };

            It returns_a_default_member_name_when_not_marked_by_attribute = () =>
            {
                typeof(Customer).GetProperty("Name").DisplayName().ShouldEqual("Name");
                typeof(SampleAttribute).DisplayName().ShouldEqual("SampleAttribute");
            };

            It raises_an_exception_for_null_source = () =>
            {
                MemberInfo memberInfo = null;
                var exception = Catch.Exception(() => memberInfo.DisplayName());
                exception.ShouldBeOfExactType<ArgumentNullException>();
            };
        }
    }
}
