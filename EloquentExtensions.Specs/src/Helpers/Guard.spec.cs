// Eithery: Eloquent Extensions
// Class GuardSpecs
// Contains unit tests/specs for Guard class
//
using System;
using Machine.Specifications;

namespace EloquentExtensions.Specs
{
    [Subject(typeof(Guard))]
    public class GuardSpec
    {
        private const string PARAMETER_NAME = "Parameter name: parameterName";
        private const string VALUE_CANNOT_BE_NULL = "Value cannot be null.";
        private const string VALUE_CANNOT_BE_BLANK = "Value cannot be a blank string.";

        private static Exception exception;

        class NotNull
        {
            It does_nothing_for_not_null_argument = () =>
            {
                exception = Catch.Exception(() => Guard.NotNull<string>("valid string", "parameterName"));
                exception.ShouldBeNull();
                exception = Catch.Exception(() => Guard.NotNull<int?>(123, "parameterName"));
                exception.ShouldBeNull();
            };

            It raises_an_exception_for_null_argument_value = () =>
            {
                exception = Catch.Exception(() => Guard.NotNull<string>(null, "parameterName"));
                exception.ShouldBeOfExactType<ArgumentNullException>();
                exception.Message.ShouldContain(VALUE_CANNOT_BE_NULL);
                exception.Message.ShouldContain(PARAMETER_NAME);

                exception = Catch.Exception(() => Guard.NotNull<int?>(null, "parameterName"));
                exception.ShouldBeOfExactType<ArgumentNullException>();
                exception.Message.ShouldContain(VALUE_CANNOT_BE_NULL);
                exception.Message.ShouldContain(PARAMETER_NAME);
            };

            It uses_a_passed_exception_message = () =>
            {
                const string expectedMessage = "Something wrong happens";
                exception = Catch.Exception(() => Guard.NotNull<string>(null, "parameterName", expectedMessage));
                exception.Message.ShouldContain(expectedMessage);
                exception.Message.ShouldContain(PARAMETER_NAME);
            };
        }


        class NotBlank
        {
            It does_nothing_for_non_blank_string_value = () =>
            {
                exception = Catch.Exception(() => Guard.NotBlank("valid string", "parameterName"));
                exception.ShouldBeNull();
            };

            It raises_an_exception_for_null_string_argument_value = () =>
            {
                exception = Catch.Exception(() => Guard.NotBlank(null, "parameterName"));
                exception.ShouldBeOfExactType<ArgumentNullException>();
                exception.Message.ShouldContain(VALUE_CANNOT_BE_NULL);
                exception.Message.ShouldContain(PARAMETER_NAME);
            };

            It raises_an_exception_for_blank_string_argument_value = () =>
            {
                exception = Catch.Exception(() => Guard.NotBlank("\t  \r\n ", "parameterName"));
                exception.ShouldBeOfExactType<ArgumentException>();
                exception.Message.ShouldContain(VALUE_CANNOT_BE_BLANK);
                exception.Message.ShouldContain(PARAMETER_NAME);
            };

            It uses_a_passed_exception_message = () =>
            {
                const string expectedMessage = "Something wrong happens";
                exception = Catch.Exception(() => Guard.NotBlank("", "parameterName", expectedMessage));
                exception.Message.ShouldContain(expectedMessage);
                exception.Message.ShouldContain(PARAMETER_NAME);
            };
        }
    }
}
