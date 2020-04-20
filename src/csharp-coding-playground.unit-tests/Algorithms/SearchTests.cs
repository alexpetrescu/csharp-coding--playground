using System;
using csharp_coding_playground.Algorithms;
using NUnit.Framework;

namespace csharp_coding_playground.unit_tests.Algorithms
{
    public class SearchTests
    {
        [Test]
        public void ShouldReturnCorrectIndexOnBinarySearchWhenItemIsSomewhereInTheArray()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.AreEqual(0, Search.BinarySearch(array, 1));
            Assert.AreEqual(1, Search.BinarySearch(array, 2));
            Assert.AreEqual(2, Search.BinarySearch(array, 3));
            Assert.AreEqual(3, Search.BinarySearch(array, 4));
            Assert.AreEqual(4, Search.BinarySearch(array, 5));
            Assert.AreEqual(5, Search.BinarySearch(array, 6));
            Assert.AreEqual(6, Search.BinarySearch(array, 7));
            Assert.AreEqual(7, Search.BinarySearch(array, 8));
            Assert.AreEqual(8, Search.BinarySearch(array, 9));
        }

        [Test]
        public void ShouldReturnCorrectIndexOnBinarySearchWhenItemInTheMiddleOfArray()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.AreEqual(3, Search.BinarySearch(array, 4));
        }

        [Test]
        public void ShouldReturnCorrectIndexOnBinarySearchWhenItemAtTheStartOfArray()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.AreEqual(0, Search.BinarySearch(array, 1));
        }

        [Test]
        public void ShouldReturnCorrectIndexOnBinarySearchWhenItemAtTheEndOfArray()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.AreEqual(7, Search.BinarySearch(array, 8));
        }

        [Test]
        public void ShouldReturnMinusOneOnBinarySearchWhenItemDoesNotExistInArray()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.AreEqual(-1, Search.BinarySearch(array, 200));
        }
    }
}
