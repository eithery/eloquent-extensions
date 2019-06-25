// (C) Eithery
// Class StringExtensionsSpecs
// Contains unit tests for StringExtensions class
//
using System;
using Machine.Specifications;

namespace EloquentExtensions
{
    [Subject(typeof(StringExtensions))]
    public class StringExtensionsSpecs
    {
        class IsBlankSpecs
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


        class IsNotBlankSpecs
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

        class IsEmptySpecs
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

        class IsNotEmptySpecs
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
    }
}
