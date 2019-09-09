// Eithery: Eloquent Extensions
// Class ExpressionExtensionsSpecs
// Contains unit tests/specs for ExpressionExtensions class
//
using System;
using System.Linq.Expressions;
using Machine.Specifications;

namespace EloquentExtensions
{
    [Subject(typeof(ExpressionExtensions))]
    public class ExpressionExtensionsSpecs
    {
        class GetPropertyName
        {
            It gets_a_property_name_from_an_expression = () =>
            {
                var customer = new Customer();
                Expression<Func<string>> personalManagerProperty = () => customer.PersonalManager;
                Expression<Func<int>> ageProperty = () => customer.Age;
                Expression<Func<bool?>> isFinraMemberProperty = () => customer.IsFinraMember;
                Expression<Func<Address>> addressProperty = () => customer.Address;
                Expression<Func<ActivationMode>> activationModeProperty = () => customer.ActivationMode;

                personalManagerProperty.GetPropertyName().ShouldEqual("PersonalManager");
                ageProperty.GetPropertyName().ShouldEqual("Age");
                isFinraMemberProperty.GetPropertyName().ShouldEqual("IsFinraMember");
                addressProperty.GetPropertyName().ShouldEqual("Address");
                activationModeProperty.GetPropertyName().ShouldEqual("ActivationMode");
            };

            It raises_an_exception_for_null_expression = () =>
            {
                Expression<Func<string>> nullExpression = null;
                var exception = Catch.Exception(() => nullExpression.GetPropertyName());
                exception.ShouldBeOfExactType<ArgumentNullException>();
            };

            It raises_an_exception_for_not_member_access_expressions = () =>
            {
                Expression<Func<string>> notMemberExpression = () => "Some string";
                var exception = Catch.Exception(() => notMemberExpression.GetPropertyName());
                exception.ShouldBeOfExactType<ArgumentException>();
                exception.ShouldContainErrorMessage("The expression is not a property access expression");
            };


            It raises_an_exception_for_field_access_expressions = () =>
            {
                Expression<Func<string>> fieldExpression = () => new Customer().name;
                var exception = Catch.Exception(() => fieldExpression.GetPropertyName());
                exception.ShouldBeOfExactType<ArgumentException>();
                exception.ShouldContainErrorMessage("The expression is not a property access expression");
            };

            It raises_an_error_for_static_property_expressions = () =>
            {
                Expression<Func<int>> staticPropertyExpression = () => Customer.TotalCount;
                var exception = Catch.Exception(() => staticPropertyExpression.GetPropertyName());
                exception.ShouldBeOfExactType<ArgumentException>();
                exception.ShouldContainErrorMessage("The property expression should not be static");
            };
        }
    }
}
