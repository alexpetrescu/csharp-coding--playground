using System.Diagnostics.CodeAnalysis;

namespace csharp_coding_playground.Infrastructure
{
    [ExcludeFromCodeCoverage]
    internal class BinarySearchTreeNode<T>
    {
        public BinarySearchTreeNode<T> Left { get; set; }

        public BinarySearchTreeNode<T> Right { get; set; }

        public T Value { get; set; }
    }
}