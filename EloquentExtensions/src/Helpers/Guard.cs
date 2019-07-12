// (C) Eithery
// Class Guard
// Performs some checks of method arguments
//
using System;

namespace EloquentExtensions
{
    public static class Guard
    {
        /// <summary>
        /// Checks and raises an exception when the specified argument value is null
        /// </summary>
        /// <param name="argumentValue">An argument value being checked</param>
        /// <param name="argumentName">An argument name</param>
        /// <param name="exceptionMessage">An exception message</param>
        public static void NotNull<T>(T argumentValue, string argumentName, string exceptionMessage=null)
        {
            if (argumentValue == null)
            {
                if (exceptionMessage.IsBlank())
                    throw new ArgumentNullException(argumentName);
                else
                    throw new ArgumentNullException(argumentName, exceptionMessage);
            }
        }


        /// <summary>
        /// Checks and raises an exception when the specified string argument is blank
        /// </summary>
        /// <param name="value">A string value being checked</param>
        /// <param name="argumentName">An argument name</param>
        /// <param name="exceptionMessage">An exception message</param>
        public static void NotBlank(string value, string argumentName, string exceptionMessage=null)
        {
            NotNull<string>(value, argumentName, exceptionMessage);
            if (value.IsBlank())
            {
                var message = exceptionMessage ?? "Value cannot be a blank string.";
                throw new ArgumentException(message, argumentName);
            }
        }
    }
}
