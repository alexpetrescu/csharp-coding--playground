using System;
using csharp_coding_playground.Algorithms;
using NUnit.Framework;

namespace csharp_coding_playground.unit_tests.Algorithms
{
    public class SortTests
    {
        [Test]
        public void ShouldSortCorrectlyOnMergeSortWhenArrayIsEmpty()
        {
            var array = new int[] { };
            Sort.MergeSort(array);

            Assert.AreEqual(0, array.Length);
        }

        [Test]
        public void ShouldSortCorrectlyOnMergeSortWhenArrayHasOneElement()
        {
            var array = new int[] { 10 };
            Sort.MergeSort(array);

            Assert.AreEqual(1, array.Length);
            Assert.AreEqual(10, array[0]);
        }

        [Test]
        public void ShouldSortCorrectlyOnMergeSortWhenArrayIsTotallyUnordered()
        {
            var array = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            Sort.MergeSort(array);

            Assert.AreEqual(0, array[0]);
            Assert.AreEqual(1, array[1]);
            Assert.AreEqual(2, array[2]);
            Assert.AreEqual(3, array[3]);
            Assert.AreEqual(4, array[4]);
            Assert.AreEqual(5, array[5]);
            Assert.AreEqual(6, array[6]);
            Assert.AreEqual(7, array[7]);
            Assert.AreEqual(8, array[8]);
            Assert.AreEqual(9, array[9]);
        }

        [Test]
        public void ShouldSortCorrectlyOnMergeSortWhenArrayIsUnordered()
        {
            var array = new int[] { 0, 8, 6, 7, 3, 5, 2, 4, 1, 9 };
            Sort.MergeSort(array);

            Assert.AreEqual(0, array[0]);
            Assert.AreEqual(1, array[1]);
            Assert.AreEqual(2, array[2]);
            Assert.AreEqual(3, array[3]);
            Assert.AreEqual(4, array[4]);
            Assert.AreEqual(5, array[5]);
            Assert.AreEqual(6, array[6]);
            Assert.AreEqual(7, array[7]);
            Assert.AreEqual(8, array[8]);
            Assert.AreEqual(9, array[9]);
        }

        [Test]
        public void ShouldSortCorrectlyOnMergeSortWhenArrayIsOrdered()
        {
            var array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Sort.MergeSort(array);

            Assert.AreEqual(0, array[0]);
            Assert.AreEqual(1, array[1]);
            Assert.AreEqual(2, array[2]);
            Assert.AreEqual(3, array[3]);
            Assert.AreEqual(4, array[4]);
            Assert.AreEqual(5, array[5]);
            Assert.AreEqual(6, array[6]);
            Assert.AreEqual(7, array[7]);
            Assert.AreEqual(8, array[8]);
            Assert.AreEqual(9, array[9]);
        }

        [Test]
        public void ShouldSortCorrectlyOnQuickSortWhenArrayIsEmpty()
        {
            var array = new int[] { };
            Sort.QuickSort(array);

            Assert.AreEqual(0, array.Length);
        }

        [Test]
        public void ShouldSortCorrectlyOnQuickSortWhenArrayHasOneElement()
        {
            var array = new int[] { 10 };
            Sort.MergeSort(array);

            Assert.AreEqual(1, array.Length);
            Assert.AreEqual(10, array[0]);
        }

        [Test]
        public void ShouldSortCorrectlyOnQuickSortWhenArrayIsTotallyUnordered()
        {
            var array = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            Sort.QuickSort(array);

            Assert.AreEqual(0, array[0]);
            Assert.AreEqual(1, array[1]);
            Assert.AreEqual(2, array[2]);
            Assert.AreEqual(3, array[3]);
            Assert.AreEqual(4, array[4]);
            Assert.AreEqual(5, array[5]);
            Assert.AreEqual(6, array[6]);
            Assert.AreEqual(7, array[7]);
            Assert.AreEqual(8, array[8]);
            Assert.AreEqual(9, array[9]);
        }

        [Test]
        public void ShouldSortCorrectlyOnQuickSortWhenArrayIsUnordered()
        {
            var array = new int[] { 0, 8, 6, 7, 3, 5, 2, 4, 1, 9 };
            Sort.QuickSort(array);

            Assert.AreEqual(0, array[0]);
            Assert.AreEqual(1, array[1]);
            Assert.AreEqual(2, array[2]);
            Assert.AreEqual(3, array[3]);
            Assert.AreEqual(4, array[4]);
            Assert.AreEqual(5, array[5]);
            Assert.AreEqual(6, array[6]);
            Assert.AreEqual(7, array[7]);
            Assert.AreEqual(8, array[8]);
            Assert.AreEqual(9, array[9]);
        }

        [Test]
        public void ShouldSortCorrectlyOnQuickSortWhenArrayIsOrdered()
        {
            var array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Sort.QuickSort(array);

            Assert.AreEqual(0, array[0]);
            Assert.AreEqual(1, array[1]);
            Assert.AreEqual(2, array[2]);
            Assert.AreEqual(3, array[3]);
            Assert.AreEqual(4, array[4]);
            Assert.AreEqual(5, array[5]);
            Assert.AreEqual(6, array[6]);
            Assert.AreEqual(7, array[7]);
            Assert.AreEqual(8, array[8]);
            Assert.AreEqual(9, array[9]);
        }
    }
}
