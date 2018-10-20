using System;
using System.Collections.Generic;

namespace JaggedSortLibrary
{
    /// <summary>
    /// Class provides method to sort jagged array
    /// </summary>
    public class JaggedSort
    {
        /// <summary>
        /// Sort jagged array by sum of elements in row
        /// </summary>
        /// <param name="jaggedArray">Jagged array to sort</param>
        public static void SumSort(int[][] jaggedArray)
        {
            Sort(new ArraySumComparer(), jaggedArray);
        }

        /// <summary>
        /// Sort jagged array by max element in row
        /// </summary>
        /// <param name="jaggedArray">Jagged array to sort</param>
        public static void MaxElementSort(int[][] jaggedArray)
        {
            Sort(new MaxInArrayComparer(), jaggedArray);
        }

        /// <summary>
        /// Sort array by min element in row
        /// </summary>
        /// <param name="jaggedArray">Jagged array to sort</param>
        public static void MinElementSort(int[][] jaggedArray)
        {
            Sort(new MinInArrayComparer(), jaggedArray);
        }

        /// <summary>
        /// Sort array using the specified comparer
        /// </summary>
        /// <param name="comparer">The implementation to use when comparing elements</param>
        /// <param name="jaggedArray">Jagged array to sort</param>
        /// <exception cref="ArgumentNullException">Argument comparer or jaggedArray is null</exception>
        public static void Sort(IComparer<int[]> comparer, int[][] jaggedArray)
        {
            if (jaggedArray == null || comparer == null)
            {
                throw new ArgumentNullException("Arguments must be initialized");
            }
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length - 1; j++)
                {
                    if (comparer.Compare(jaggedArray[j], jaggedArray[j + 1]) < 0)
                    {
                        Swap(jaggedArray, j, j + 1);
                    }
                }
            }
        }

        /// <summary>
        /// Swap elements in array
        /// </summary>
        /// <param name="jaggedArray">Jagged array contains elements</param>
        /// <param name="ind1">Index of element</param>
        /// <param name="ind2">Index of element</param>
        private static void Swap(int[][] jaggedArray, int ind1, int ind2)
        {
            int[] temp = jaggedArray[ind1];
            jaggedArray[ind1] = jaggedArray[ind2];
            jaggedArray[ind2] = temp;
        }

        /// <summary>
        /// Class provides method to compare one-dimensional by sum of elements and implements interface IComparer&ltint[]$gt
        /// </summary>
        class ArraySumComparer : IComparer<int[]>
        {
            /// <summary>
            /// Compare two one-dimensional arrays by sum of elements
            /// </summary>
            /// <param name="x">One-dimensional array</param>
            /// <param name="y">One-dimensional array</param>
            /// <returns>1 if sum of array x greater than sum of array y. -1 if sum of array x less than sum of array y. 0 if sums of arrays are equals</returns>
            /// <exception cref="ArgumentNullException">One of array isn't initialized</exception>
            public int Compare(int[] x, int[] y)
            {
                if (x == null || y == null)
                {
                    throw new ArgumentNullException("Arrays must be initialized");
                }

                int xSum = CountSum(x), ySum = CountSum(y);
                if (xSum < ySum)
                {
                    return 1;
                }
                else if (xSum > ySum)
                {
                    return -1;
                }
                return 0;
            }

            /// <summary>
            /// Count sum of array elements
            /// </summary>
            /// <param name="array">One-demensional array</param>
            /// <returns>Sum of array elements</returns>
            private int CountSum(int[] array)
            {
                int sum = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    sum += array[i];
                }
                return sum;
            }
        }

        /// <summary>
        /// Class provides method to compare one-dimensional by maximum element and implements interface IComparer&ltint[]$gt
        /// </summary>
        class MaxInArrayComparer : IComparer<int[]>
        {
            /// <summary>
            /// Compare two one-dimensional arrays by maximum element
            /// </summary>
            /// <param name="x">One-dimensional array</param>
            /// <param name="y">One-dimensional array</param>
            /// <returns>1 if maximum element of array x greater than maximum element of array y. -1 if maximum element of array x less than maximum element of array y. 0 if maximum elements of arrays are equals</returns>
            /// <exception cref="ArgumentNullException">One of array isn't initialized</exception>
            public int Compare(int[] x, int[] y)
            {
                if (x == null || y == null)
                {
                    throw new ArgumentNullException("Arrays must be initialized");
                }

                int xMax = GetMaxValue(x), yMax = GetMaxValue(y);
                if (xMax < yMax)
                {
                    return 1;
                }
                else if (xMax > yMax)
                {
                    return -1;
                }
                return 0;
            }

            /// <summary>
            /// Get value of maximum element in array
            /// </summary>
            /// <param name="array">One-demensional array</param>
            /// <returns>Value of maximum element</returns>
            /// <exception cref="ArgumentException">Array has no elements</exception>
            private int GetMaxValue(int[] array)
            {
                if (array.Length == 0)
                {
                    throw new ArgumentException("Array must contain at least one element");
                }
                int max = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] > max)
                    {
                        max = array[i];
                    }
                }
                return max;
            }
        }

        /// <summary>
        /// Class provides method to compare one-dimensional by minimum element and implements interface IComparer&ltint[]$gt
        /// </summary>
        class MinInArrayComparer : IComparer<int[]>
        {
            /// <summary>
            /// Compare two one-dimensional arrays by minimum element
            /// </summary>
            /// <param name="x">One-dimensional array</param>
            /// <param name="y">One-dimensional array</param>
            /// <returns>1 if minimum element of array x greater than minimum element of array y. -1 if minimum element of array x less than minimum element of array y. 0 if minimum elements of arrays are equals</returns>
            /// <exception cref="ArgumentNullException">One of array isn't initialized</exception>
            public int Compare(int[] x, int[] y)
            {
                if (x == null || y == null)
                {
                    throw new ArgumentNullException("Arrays must be initialized");
                }

                int xMin = GetMinValue(x), yMin = GetMinValue(y);
                if (xMin < yMin)
                {
                    return 1;
                }
                else if (xMin > yMin)
                {
                    return -1;
                }
                return 0;
            }

            /// <summary>
            /// Get value of minimum element in array
            /// </summary>
            /// <param name="array">One-demensional array</param>
            /// <returns>Value of minimum element</returns>
            /// <exception cref="ArgumentException">Array has no elements</exception>
            private int GetMinValue(int[] array)
            {
                if (array.Length == 0)
                {
                    throw new ArgumentException("Array must contain at least one element");
                }
                int min = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] < min)
                    {
                        min = array[i];
                    }
                }
                return min;
            }
        }
    }
}
