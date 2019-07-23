// Eithery: Eloquent Extensions
// Class StringExtensionsSpecs
// Contains unit tests/specs for StringExtensions class
//
using System;
using Machine.Specifications;

namespace EloquentExtensions
{
    [Subject(typeof(StringExtensions))]
    public class StringExtensionsSpecs
    {
        class IsBlank
        {
            It should_be_true_for_blank_string = () =>
            {
                "".IsBlank().ShouldBeTrue();
                "   ".IsBlank().ShouldBeTrue();
                " \t\r\n  \n".IsBlank().ShouldBeTrue();
            };

            It should_be_false_for_non_blank_string = () =>
            {
                "Some string".IsBlank().ShouldBeFalse();
                ".".IsBlank().ShouldBeFalse();
            };

            It should_be_true_for_null_string = () =>
            {
                string str = null;
                str.IsBlank().ShouldBeTrue();
            };
        }


        class IsNotBlank
        {
            It should_be_true_for_non_blank_string = () =>
            {
                "Some string".IsNotBlank().ShouldBeTrue();
                ".".IsNotBlank().ShouldBeTrue();
            };

            It should_be_false_for_blank_string = () =>
            {
                "".IsNotBlank().ShouldBeFalse();
                "   ".IsNotBlank().ShouldBeFalse();
                " \t\r\n  \n".IsNotBlank().ShouldBeFalse();
            };

            It should_be_false_for_null_string = () =>
            {
                string str = null;
                str.IsNotBlank().ShouldBeFalse();
            };
        }


        class IsEmpty
        {
            It should_be_true_for_empty_string = () =>
            {
                "".IsEmpty().ShouldBeTrue();
                String.Empty.IsEmpty().ShouldBeTrue();
            };

            It should_be_false_for_non_empty_string = () =>
            {
                "Some string".IsEmpty().ShouldBeFalse();
                " ".IsEmpty().ShouldBeFalse();
                "\n".IsEmpty().ShouldBeFalse();
            };

            It should_be_true_for_null_string = () =>
            {
                string str = null;
                str.IsEmpty().ShouldBeTrue();
            };
        }


        class IsNotEmpty
        {
            It should_be_true_for_non_empty_string = () =>
            {
                "Some string".IsNotEmpty().ShouldBeTrue();
                " ".IsNotEmpty().ShouldBeTrue();
                "\n".IsNotEmpty().ShouldBeTrue();
            };

            It should_be_false_for_empty_string = () =>
            {
                "".IsNotEmpty().ShouldBeFalse();
                String.Empty.IsNotEmpty().ShouldBeFalse();
            };

            It should_be_false_for_null_string = () =>
            {
                string str = null;
                str.IsNotEmpty().ShouldBeFalse();
            };
        }


        class IsEquivalentOf
        {
            class When_strings_are_case_sensitive
            {
                class And_trimmed
                {
                    It considered_to_be_equivalent = () =>
                    {
                        "some string".IsEquivalentOf("some string", ignoreCase: false).ShouldBeTrue();
                        "some string".IsEquivalentOf("\r\n some string \t ", ignoreCase: false).ShouldBeTrue();
                        "  a   ".IsEquivalentOf("a", ignoreCase: false).ShouldBeTrue();
                    };

                    It considered_to_not_be_equivalent = () =>
                    {
                        "some string".IsEquivalentOf("Some string", ignoreCase: false).ShouldBeFalse();
                        "abba".IsEquivalentOf("ABBA", ignoreCase: false).ShouldBeFalse();
                        "  abba \r\n".IsEquivalentOf("ABBA", ignoreCase: false).ShouldBeFalse();
                        "ABBA".IsEquivalentOf("  abba \r\n", ignoreCase: false).ShouldBeFalse();
                    };
                }


                class And_not_trimmed
                {
                    It considered_to_be_equivalent = () =>
                    {
                        "some string".IsEquivalentOf("some string", ignoreCase: false, trim: false).ShouldBeTrue();
                    };

                    It considered_to_not_be_equivalent = () =>
                    {
                        "some string".IsEquivalentOf("\r\n some string \t ", ignoreCase: false, trim: false).ShouldBeFalse();
                        "  a   ".IsEquivalentOf("a", ignoreCase: false, trim: false).ShouldBeFalse();
                        "abba".IsEquivalentOf("ABBA", ignoreCase: false, trim: false).ShouldBeFalse();
                        "  abba \r\n".IsEquivalentOf("ABBA", ignoreCase: false, trim: false).ShouldBeFalse();
                        "ABBA".IsEquivalentOf("  abba \r\n", ignoreCase: false, trim: false).ShouldBeFalse();
                    };
                }
            }


            class When_strings_are_case_insensitive
            {
                class And_trimmed
                {
                    It considered_to_be_equivalent = () =>
                    {
                        "some string".IsEquivalentOf("some string").ShouldBeTrue();
                        "some string".IsEquivalentOf("\r\n some string \t ").ShouldBeTrue();
                        "  a   ".IsEquivalentOf("a").ShouldBeTrue();
                        "abba".IsEquivalentOf("ABBA").ShouldBeTrue();
                        "  abba \r\n".IsEquivalentOf("ABBA").ShouldBeTrue();
                        "ABBA".IsEquivalentOf("  abba \r\n").ShouldBeTrue();
                    };

                    It considered_to_not_be_equivalent = () => "one".IsEquivalentOf("one.").ShouldBeFalse();
                }


                class And_not_trimmed
                {
                    It considered_to_be_equivalent = () =>
                    {
                        "some string".IsEquivalentOf("some string", trim: false).ShouldBeTrue();
                        "abba".IsEquivalentOf("ABBA", trim: false).ShouldBeTrue();
                    };

                    It considered_to_not_be_equivalent = () =>
                    {
                        "some string".IsEquivalentOf("\r\n some string \t ", trim: false).ShouldBeFalse();
                        "  a   ".IsEquivalentOf("a", trim: false).ShouldBeFalse();
                        "  abba \r\n".IsEquivalentOf("ABBA", trim: false).ShouldBeFalse();
                        "ABBA".IsEquivalentOf("  abba \r\n", trim: false).ShouldBeFalse();
                    };
                }
            }


            class For_blank_and_null_strings
            {
                It considered_to_be_equivalent = () =>
                {
                    "".IsEquivalentOf("").ShouldBeTrue();
                    "".IsEquivalentOf(null).ShouldBeTrue();
                   "".IsEquivalentOf(null, trim: false).ShouldBeTrue();
                    "  \r\n".IsEquivalentOf("").ShouldBeTrue();
                    "".IsEquivalentOf(" \r\n ").ShouldBeTrue();
                    ((string)null).IsEquivalentOf("").ShouldBeTrue();
                    ((string)null).IsEquivalentOf("", trim: false).ShouldBeTrue();
                    ((string)null).IsEquivalentOf(" \n \r").ShouldBeTrue();
                    "  \r\n".IsEquivalentOf(null).ShouldBeTrue();
                    ((string)null).IsEquivalentOf(null).ShouldBeTrue();
                    ((string)null).IsEquivalentOf(null, trim: false).ShouldBeTrue();
                };

                It considered_to_not_be_equivalent = () =>
                {
                    "  \r\n".IsEquivalentOf("", trim: false).ShouldBeFalse();
                    "".IsEquivalentOf(" \r\n ", trim: false).ShouldBeFalse();
                    ((string)null).IsEquivalentOf(" \n \r", trim: false).ShouldBeFalse();
                    "  \r\n".IsEquivalentOf(null, trim: false).ShouldBeFalse();
                };
            }
        }
    }
}
