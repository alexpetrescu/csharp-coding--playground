using System.Diagnostics.CodeAnalysis;

namespace csharp_coding_playground.Infrastructure
{
    [ExcludeFromCodeCoverage]
    internal class LinkedListNode<T>
    {
        public T Value { get; set; }

        public LinkedListNode<T> Next { get; set; }
    }
}