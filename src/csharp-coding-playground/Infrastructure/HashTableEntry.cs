using System.Diagnostics.CodeAnalysis;

namespace csharp_coding_playground.Infrastructure
{
    [ExcludeFromCodeCoverage]
    internal class HashTableEntry<K, T>
    {
        public K Key { get; set; }

        public T Value { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is HashTableEntry<T, K>) return ((HashTableEntry<T, K>)obj).Key.Equals(Key);
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
