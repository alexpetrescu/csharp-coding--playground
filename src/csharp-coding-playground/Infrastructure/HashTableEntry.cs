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
            var entry = obj as HashTableEntry<T, K>;
            if (entry != null)
            {
                return entry.Key.Equals(Key);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}