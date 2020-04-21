using System;
namespace csharp_coding_playground.Algorithms
{
    public static class Sort
    {
        /// <summary>
        /// Performs merge sort on the given array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        public static void MergeSort<T>(T[] array)
            where T: IComparable
        {
            MergeSortRecursive(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Performs quick sort on the given array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        public static void QuickSort<T>(T[] array)
            where T : IComparable
        {
            QuickSortRecursive(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Performs quick sort on the given array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        private static void QuickSortRecursive<T>(T[] array, int l, int r)
            where T: IComparable
        {
            if (l < r)
            {
                int pivot = r;
                int check = 0;
                while (pivot > check)
                {
                    var compare = array[pivot].CompareTo(array[check]);
                    if (compare < 0)
                    {
                        T temp = array[check];
                        array[check] = array[pivot - 1];
                        array[pivot - 1] = array[pivot];
                        array[pivot] = temp;
                        pivot--;
                    }
                    else
                    {
                        check++;
                    }
                }

                QuickSortRecursive(array, l, pivot - 1);
                QuickSortRecursive(array, pivot + 1, r);
            }
        }

        /// <summary>
        /// Performs merge sort on the given array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        private static void MergeSortRecursive<T>(T[] array, int l, int r)
            where T : IComparable
        {
            if (l < r)
            {
                int m = (l + r) / 2;

                MergeSortRecursive(array, l, m);
                MergeSortRecursive(array, m + 1, r);

                Merge(array, l, r);
            }
        }

        /// <summary>
        /// Merges two arrays for merge sort.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        private static void Merge<T>(T[] array, int l, int r)
            where T: IComparable
        {
            int m = (l + r) / 2;
            T[] merge = new T[r - l + 1];
            int k = 0;
            int i = l;
            int j = m + 1;

            while (i <= m && j < r + 1)
            {
                var compare = array[i].CompareTo(array[j]);
                if (compare < 0)
                {
                    merge[k] = array[i];
                    i++;
                }
                else
                {
                    merge[k] = array[j];
                    j++;
                }
                k++;
            }

            while (i <= m)
            {
                merge[k] = array[i];
                i++;
                k++;
            }

            while (j < r + 1)
            {
                merge[k] = array[j];
                j++;
                k++;
            }

            for (int h = 0; h < r - l + 1; h++)
            {
                array[l+h] = merge[h];
            }
        }
    }
}