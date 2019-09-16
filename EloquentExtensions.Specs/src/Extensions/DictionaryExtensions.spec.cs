// Eithery: Eloquent Extensions
// Class DictionaryExtensionsSpecs
// Contains unit tests/specs for DictionaryExtensions class
//
using System;
using System.Collections.Generic;
using Machine.Specifications;

namespace EloquentExtensions.Specs
{
    [Subject(typeof(DictionaryExtensions))]
    public class DictionaryExtensionsSpec
    {
        class Merge
        {
            It adds_values_missing_in_the_original_dictionary = () =>
            {
                var result = OriginalDict.Merge(new Dictionary<string,string>
                {
                    { "three", "value3" },
                    { "four", "value4" }
                });

                result.Count.ShouldEqual(4);
                result["one"].ShouldEqual("value1");
                result["four"].ShouldEqual("value4");
            };


            It overrides_values_existing_in_the_original_dictionary = () =>
            {
                var result = OriginalDict.Merge(new Dictionary<string,string>
                {
                    { "one", "1" },
                    { "two", "2" }
                });

                result.Count.ShouldEqual(2);
                result["one"].ShouldEqual("1");
                result["two"].ShouldEqual("2");
            };


            It can_merge_multiple_dictionaries = () =>
            {
                var result = OriginalDict.Merge(
                    new Dictionary<string,string>
                    {
                        { "two", "2" },
                        { "three", "3" }
                    },
                    new Dictionary<string,string>
                    {
                        { "four", "4" },
                        { "five", "5" }
                    }
                );

                result.Count.ShouldEqual(5);
                result["one"].ShouldEqual("value1");
                result["two"].ShouldEqual("2");
                result["five"].ShouldEqual("5");
            };


            It returns_the_original_dictionary_with_all_merged_values = () =>
            {
                var dict = new Dictionary<string,string>();
                var result = dict.Merge(new Dictionary<string,string>
                {
                    { "one", "1" },
                    { "two", "2" }
                });

                result.ShouldBeTheSameAs(dict);
                result["one"].ShouldEqual("1");
                dict["one"].ShouldEqual("1");
            };


            It raises_an_exception_for_null_dictionary = () =>
            {
                IDictionary<string,string> dict = null;
                var exception = Catch.Exception(() => dict.Merge(OriginalDict));
                exception.ShouldBeOfExactType<ArgumentNullException>();
            };


            It raises_an_exception_for_null_argument = () =>
            {
                var exception = Catch.Exception(() => OriginalDict.Merge(null));
                exception.ShouldBeOfExactType<ArgumentNullException>();
            };


            It do_nothing_when_no_arguments_specified = () =>
            {
                var result = OriginalDict.Merge();
                result.Count.ShouldEqual(2);
                result["one"].ShouldEqual("value1");
            };


            private static IDictionary<string,string> OriginalDict => new Dictionary<string,string>
            {
                { "one", "value1" },
                { "two", "value2" }
            };
        }
    }
}
