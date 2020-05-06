using System;
using System.Diagnostics.CodeAnalysis;

namespace csharp_coding_playground.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public class ValidationException : Exception
    {
        public ValidationException() : base("A validation error ocurred")
        {
        }

        public ValidationException(string message) : base(message)
        {
        }
    }
}