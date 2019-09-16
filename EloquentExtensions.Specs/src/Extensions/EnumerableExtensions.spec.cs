// Eithery: Eloquent Extensions
// Class EnumerableExtensionsSpecs
// Contains unit tests/specs for EnumerableExtensions class
//
using System;
using System.Collections.Generic;
using Machine.Specifications;

namespace EloquentExtensions.Specs
{
    [Subject(typeof(EnumerableExtensions))]
    public class EnumerableExtensionsSpec
    {
        class Join
        {
            It concatenates_a_collection_of_strings = () =>
            {
                new []{ "1", "2", "3" }.Join(" ").ShouldEqual("1 2 3");
                new []{ "ClassName", "MethodName" }.Join(".").ShouldEqual("ClassName.MethodName");
                new []{ "07", "08", "1986" }.Join("/").ShouldEqual("07/08/1986");
                new []{ "1", "5" }.Join("234").ShouldEqual("12345");
            };

            It skips_nulls_and_blank_strings = () =>
            {
                new []{ "1", null, "2", "\n \r  ", "3", "" }.Join(" ").ShouldEqual("1 2 3");
                new []{ "ClassName", "", null, "\r\r\n", "MethodName" }.Join(".").ShouldEqual("ClassName.MethodName");
                new []{ "  ", "   ", " \n\r " }.Join("+").ShouldEqual("");
                new string[]{ null, null, null }.Join("*").ShouldEqual("");
            };

            It uses_an_empty_string_as_default_separator = () =>
            {
                new []{ "1", "2", "3" }.Join().ShouldEqual("123");
                new []{ "07", "08", "1986" }.Join().ShouldEqual("07081986");
            };

            It supports_a_custom_separator_for_concatenation = () =>
            {
                new []{ "1", "2", "3" }.Join(".").ShouldEqual("1.2.3");
                new []{ "1", "2", "3" }.Join(" + ").ShouldEqual("1 + 2 + 3");
            };

            It considers_null_separator_as_an_empty_string = () =>
            {
                new []{ "1", "2", "3" }.Join(null).ShouldEqual("123");
                new []{ "07", "08", "1986" }.Join(null).ShouldEqual("07081986");
                new []{ "ClassName", "MethodName" }.Join(null).ShouldEqual("ClassNameMethodName");
            };

            It raises_an_exception_for_null_string_collection = () =>
            {
                IEnumerable<string> source = null;
                var exception = Catch.Exception(() => source.Join());
                exception.ShouldBeOfExactType<ArgumentNullException>();
            };

            It returns_an_empty_string_for_empty_string_collection = () =>
            {
                new string[0].Join().ShouldEqual("");
                new string[0].Join("+++").ShouldEqual("");
            };

            It returns_a_contained_string_value_from_one_element_string_collection = () =>
            {
                new []{ "one element" }.Join().ShouldEqual("one element");
                new []{ "TEST" }.Join("+").ShouldEqual("TEST");
            };
        }
    }
}
