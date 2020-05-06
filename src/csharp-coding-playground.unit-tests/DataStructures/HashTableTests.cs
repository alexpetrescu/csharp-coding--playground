using csharp_coding_playground.DataStructures;
using csharp_coding_playground.Infrastructure;
using NUnit.Framework;

namespace csharp_coding_playground.unit_tests.DataStructures
{
    public class HashTableTests
    {
        [Test]
        public void ShouldAddElementAtKeyOnAddWhenKeyDoesNotExist()
        {
            var hashTable = new HashTable<string, string>();

            hashTable.Add("foo", "bar");
            Assert.AreEqual("bar", hashTable.Get("foo"));
        }

        [Test]
        public void ShouldOverrideElementAtKeyOnAddWhenKeyAlreadyExists()
        {
            var hashTable = new HashTable<string, string>();

            hashTable.Add("foo", "bar");
            Assert.AreEqual("bar", hashTable.Get("foo"));

            hashTable.Add("foo", "snackbar");
            Assert.AreEqual("snackbar", hashTable.Get("foo"));
        }

        [Test]
        public void ShouldReturnTrueOnContainsKeyWhenHashTableContainsKey()
        {
            var hashTable = new HashTable<string, string>();

            hashTable.Add("foo", "bar");
            Assert.IsTrue(hashTable.ContainsKey("foo"));
            Assert.AreEqual("bar", hashTable.Get("foo"));
        }

        [Test]
        public void ShouldReturnFalseOnContainsKeyWhenHashTableDoesNotContainKey()
        {
            var hashTable = new HashTable<string, string>();

            Assert.IsFalse(hashTable.ContainsKey("foo"));
        }

        [Test]
        public void ShouldThrowExceptionOnGetWhenKeyDoesNotExist()
        {
            var hashTable = new HashTable<string, string>();

            Assert.Throws<ValidationException>(() => hashTable.Get("foo"));
        }

        [Test]
        public void ShouldReturnCorrectValueOnGetWhenKeyExists()
        {
            var hashTable = new HashTable<string, string>();

            hashTable.Add("foo", "bar");
            Assert.IsTrue(hashTable.ContainsKey("foo"));
            Assert.AreEqual("bar", hashTable.Get("foo"));
        }

        [Test]
        public void ShouldNotThrowExceptionOnRemoveWhenKeyDoesNotExist()
        {
            var hashTable = new HashTable<string, string>();

            Assert.DoesNotThrow(() => hashTable.Remove("foo"));
        }

        [Test]
        public void ShouldRemoveCorrectKeyOnGetWhenKeyExists()
        {
            var hashTable = new HashTable<string, string>();

            hashTable.Add("foo", "bar");
            Assert.IsTrue(hashTable.ContainsKey("foo"));
            Assert.AreEqual("bar", hashTable.Get("foo"));

            hashTable.Remove("foo");
            Assert.IsFalse(hashTable.ContainsKey("foo"));
        }

        [Test]
        public void ShouldResolveCollisionOnAddWhenTwoKeysResolveToTheSameIndex()
        {
            var hashTable = new HashTable<HashCustomTableKey, string>();

            hashTable.Add(new HashCustomTableKey { HashCode = 1024, Key = "foo" }, "foo");
            hashTable.Add(new HashCustomTableKey { HashCode = 1024, Key = "bar" }, "bar");

            Assert.AreEqual("foo", hashTable.Get(new HashCustomTableKey { HashCode = 1024, Key = "foo" }));
            Assert.AreEqual("bar", hashTable.Get(new HashCustomTableKey { HashCode = 1024, Key = "bar" }));
        }

        [Test]
        public void ShouldResolveCollisionOnContainsKeyWhenTwoKeysResolveToTheSameIndex()
        {
            var hashTable = new HashTable<HashCustomTableKey, string>();

            hashTable.Add(new HashCustomTableKey { HashCode = 1024, Key = "foo" }, "foo");
            hashTable.Add(new HashCustomTableKey { HashCode = 1024, Key = "bar" }, "bar");

            Assert.IsTrue(hashTable.ContainsKey(new HashCustomTableKey { HashCode = 1024, Key = "foo" }));
            Assert.IsTrue(hashTable.ContainsKey(new HashCustomTableKey { HashCode = 1024, Key = "bar" }));
        }

        [Test]
        public void ShouldThrowExceptionOnGetWhenCollisionButKeyDoesNotExist()
        {
            var hashTable = new HashTable<HashCustomTableKey, string>();

            hashTable.Add(new HashCustomTableKey { HashCode = 1024, Key = "foo" }, "foo");
            hashTable.Add(new HashCustomTableKey { HashCode = 1024, Key = "bar" }, "bar");

            Assert.AreEqual("foo", hashTable.Get(new HashCustomTableKey { HashCode = 1024, Key = "foo" }));
            Assert.AreEqual("bar", hashTable.Get(new HashCustomTableKey { HashCode = 1024, Key = "bar" }));
            Assert.Throws<ValidationException>(() => hashTable.Get(new HashCustomTableKey { HashCode = 1024, Key = "baz" }));
        }

        [Test]
        public void ShouldReturnFalseOnContainsKeyWhenCollisionButKeyDoesNotExist()
        {
            var hashTable = new HashTable<HashCustomTableKey, string>();

            hashTable.Add(new HashCustomTableKey { HashCode = 1024, Key = "foo" }, "foo");
            hashTable.Add(new HashCustomTableKey { HashCode = 1024, Key = "bar" }, "bar");

            Assert.IsTrue(hashTable.ContainsKey(new HashCustomTableKey { HashCode = 1024, Key = "foo" }));
            Assert.IsTrue(hashTable.ContainsKey(new HashCustomTableKey { HashCode = 1024, Key = "bar" }));
            Assert.IsFalse(hashTable.ContainsKey(new HashCustomTableKey { HashCode = 1024, Key = "baz" }));
        }

        private class HashCustomTableKey
        {
            public string Key { get; set; }

            public int HashCode { get; set; }

            public override bool Equals(object obj)
            {
                var customTableKey = obj as HashCustomTableKey;
                if (customTableKey != null)
                {
                    return customTableKey.Key == Key;
                }

                return false;
            }

            public override int GetHashCode()
            {
                return HashCode;
            }
        }
    }
}