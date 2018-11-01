using System;
using System.Collections.Generic;

namespace JaggedSortLibrary.Comparators
{
    /// <summary>
    /// Class provides method to compare one-dimensional by sum of elements and implements interface IComparer&ltint[]$gt
    /// </summary>
    public class ArraySumComparer : IComparer<int[]>
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
        /// <param name="array">One-dimensional array</param>
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
}
