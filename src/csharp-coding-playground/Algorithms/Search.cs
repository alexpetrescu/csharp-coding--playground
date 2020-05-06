using System;
namespace csharp_coding_playground.Algorithms
{
    public static class Search
    {
        /// <summary>
        /// Performs recursive binary search on a sorted array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">Sorted array</param>
        /// <param name="value">Searched value</param>
        /// <returns>The index of the element; -1 if the element does not exist</returns>
        public static int BinarySearch<T>(T[] array, T value)
            where T : IComparable
        {
            return BinarySearch(array, value, 0, array.Length - 1);
        }

        /// <summary>
        /// Performs recursive binary search on a sorted array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">Sorted array</param>
        /// <param name="value">Searched value</param>
        /// <param name="l">Lower bound</param>
        /// <param name="r">Upper bound</param>
        /// <returns>The index of the element; -1 if the element does not exist</returns>
        private static int BinarySearch<T>(T[] array, T value, int l, int r)
            where T : IComparable
        {
            if (l > r)
            {
                return -1;
            }

            int m = (l + r) / 2;
            var compareResult = array[m].CompareTo(value);

            if (compareResult == 0)
            {
                return m;
            }

            if (compareResult < 0)
            {
                return BinarySearch(array, value, m + 1, r);
            }

            return BinarySearch(array, value, l, m - 1);
        }
    }
}