using System;
using csharp_coding_playground.Infrastructure;

namespace csharp_coding_playground.DataStructures
{
    public class HashTable<K, T>
    {
        private const int HASH_TABLE_SIZE = 1024;

        private readonly LinkedList<HashTableEntry<K, T>>[] table = new LinkedList<HashTableEntry<K, T>>[HASH_TABLE_SIZE];

        /// <summary>
        /// Adds value for the provided key; if key already exists, updates value.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(K key, T value)
        {
            var index = GetIndex(key);
            var entryList = table[index];
            var entry = new HashTableEntry<K, T>
            {
                Key = key,
                Value = value
            };

            if (entryList == null || entryList.IsEmpty)
            {
                var list = new LinkedList<HashTableEntry<K, T>>();
                list.PushFront(entry);
                table[index] = list;
            }
            else
            {
                var list = table[index];
                for (int i = 0; i < list.Length; i++)
                {
                    var element = list.ElementAt(i);
                    if (element.Key.Equals(key))
                    {
                        list.Set(i, entry);
                        return;
                    }
                }

                list.PushFront(entry);
            }
        }

        /// <summary>
        /// Returns if the key is present in the hash table.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(K key)
        {
            var index = GetIndex(key);
            var list = table[index];

            if (list == null || list.IsEmpty)
            {
                return false;
            }

            for (int i = 0; i < list.Length; i++)
            {
                if (list.ElementAt(i).Key.Equals(key)) return true;
            }

            return false;
        }

        /// <summary>
        /// Returns the value for the give key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get(K key)
        {
            var index = GetIndex(key);
            var list = table[index];

            if (list == null || list.IsEmpty)
            {
                throw new ValidationException("Key does not exist");
            }

            for (int i = 0; i < list.Length; i++)
            {
                var element = list.ElementAt(i);
                if (element.Key.Equals(key))
                {
                    return element.Value;
                }
            }

            throw new ValidationException("Key does not exist");
        }

        /// <summary>
        /// Removes the given key from the hash table.
        /// </summary>
        /// <param name="key"></param>
        public void Remove(K key)
        {
            var index = GetIndex(key);
            var list = table[index];
            var entry = new HashTableEntry<K, T> { Key = key };

            if (list == null || list.IsEmpty)
            {
                return;
            }

            list.Remove(entry);
        }

        /// <summary>
        /// Returns the index for a given key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int GetIndex(K key)
        {
            return Math.Abs(key.GetHashCode() % HASH_TABLE_SIZE);
        }
    }
}