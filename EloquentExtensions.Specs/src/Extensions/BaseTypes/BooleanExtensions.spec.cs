// Eithery: Eloquent Extensions
// Class BooleanExtensionsSpecs
// Contains unit tests/specs for BooleanExtensions class
//
using Machine.Specifications;

namespace EloquentExtensions.Specs
{
    [Subject(typeof(BooleanExtensions))]
    public class BooleanExtensionsSpec
    {
        class ToYesNo
        {
            It returns_yes_when_true = () => true.ToYesNo().ShouldEqual("yes");

            It returns_no_when_false = () => false.ToYesNo().ShouldEqual("no");
        }


        class ToYesNo_Nullable
        {
            It returns_yes_for_true = () =>
            {
                bool? value = true;
                value.ToYesNo().ShouldEqual("yes");
                value.ToYesNo("undefined").ShouldEqual("yes");
            };

            It returns_no_for_false = () =>
            {
                bool? value = false;
                value.ToYesNo().ShouldEqual("no");
                value.ToYesNo("undefined").ShouldEqual("no");
            };

            It returns_empty_string_for_null = () =>
            {
                bool? value = null;
                value.ToYesNo().ShouldBeEmpty();
                value.ToYesNo().ShouldEqual("");
            };

            It returns_nullValue_argument_for_null = () =>
            {
                bool? value = null;
                value.ToYesNo("undefined").ShouldEqual("undefined");
                value.ToYesNo("").ShouldEqual("");
                value.ToYesNo("").ShouldBeEmpty();
                value.ToYesNo(null).ShouldBeNull();
            };
        }


        class ToOneZero
        {
            It returns_1_for_true = () => true.ToOneZero().ShouldEqual(1);

            It returns_0_for_false = () => false.ToOneZero().ShouldEqual(0);
        }


        class ToOneZero_Nullable
        {
            It returns_1_for_true = () =>
            {
                bool? value = true;
                value.ToOneZero().ShouldEqual(1);
                value.ToOneZero(-1).ShouldEqual(1);
            };

            It returns_0_for_false = () =>
            {
                bool? value = false;
                value.ToOneZero().ShouldEqual(0);
                value.ToOneZero(-1).ShouldEqual(0);
            };

            It returns_null_for_null = () =>
            {
                bool? value = null;
                value.ToOneZero().ShouldBeNull();
            };

            It returns_nullValue_argument_for_null = () =>
            {
                bool? value = null;
                value.ToOneZero(-1).ShouldEqual(-1);
                value.ToOneZero(null).ShouldBeNull();
                value.ToOneZero(1).ShouldEqual(1);
            };
        }
    }
}
