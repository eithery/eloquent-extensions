// Eithery: Eloquent Extensions
// Class TypeExtensionsSpecs
// Contains unit tests/specs for TypeExtensions class
//
using System;
using System.Collections;
using System.Collections.Generic;
using Machine.Specifications;

namespace EloquentExtensions
{
    [Subject(nameof(TypeExtensions))]
    public class TypeExtensionsSpecs
    {
        class HasProperty
        {
            It returns_true_for_existing_property = () =>
            {
                typeof(Customer).HasProperty("Name").ShouldBeTrue();
                typeof(Individual).HasProperty("LastName").ShouldBeTrue();
                typeof(Individual).HasProperty("Name").ShouldBeTrue();
                typeof(string).HasProperty("Length").ShouldBeTrue();
            };

            It returns_false_for_a_missing_property = () =>
            {
                typeof(Customer).HasProperty("Missing").ShouldBeFalse();
                typeof(Individual).HasProperty("InternalName").ShouldBeFalse();
                typeof(string).HasProperty("Id").ShouldBeFalse();
            };

            It includes_non_public_properties_to_search = () =>
            {
                typeof(Customer).HasProperty("InternalName", includeNonPublic: true).ShouldBeTrue();
                typeof(Customer).HasProperty("InternalName", includeNonPublic: false).ShouldBeFalse();
                typeof(Customer).HasProperty("PrivateName", includeNonPublic: true).ShouldBeTrue();
            };

            It raises_an_exception_for_blank_property_name = () =>
            {
                var exception = Catch.Exception(() => typeof(Customer).HasProperty(null));
                exception.ShouldBeOfExactType<ArgumentNullException>();
                exception = Catch.Exception(() => typeof(Customer).HasProperty(""));
                exception.ShouldBeOfExactType<ArgumentException>();
                exception = Catch.Exception(() => typeof(Customer).HasProperty(" \t \r\n "));
                exception.ShouldBeOfExactType<ArgumentException>();
            };

            It raises_an_exception_for_null_type = () =>
            {
                Type type = null;
                var exception = Catch.Exception(() => type.HasProperty("Name"));
                exception.ShouldBeOfExactType<ArgumentNullException>();
            };
        }


        class IsEnumerable
        {
            It returns_true_for_enumerable_types_and_collections = () =>
            {
                typeof(List<Customer>).IsEnumerable().ShouldBeTrue();
                typeof(ArrayList).IsEnumerable().ShouldBeTrue();
                typeof(IList).IsEnumerable().ShouldBeTrue();
                typeof(ICollection).IsEnumerable().ShouldBeTrue();
                typeof(ICollection<>).IsEnumerable().ShouldBeTrue();
                typeof(string[]).IsEnumerable().ShouldBeTrue();
            };

            It returns_false_for_non_enumerable_types = () =>
            {
                typeof(Customer).IsEnumerable().ShouldBeFalse();
                typeof(string).IsEnumerable().ShouldBeFalse();
            };

            It raises_an_exception_for_null_type = () =>
            {
                Type type = null;
                var exception = Catch.Exception(() => type.IsEnumerable());
                exception.ShouldBeOfExactType<ArgumentNullException>();
            };
        }
    }
}
