using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedSortLibrary.Comparators
{
    /// <summary>
    /// Class provides method to compare one-dimensional by maximum element and implements interface IComparer&ltint[]$gt
    /// </summary>
    public class MaxInArrayComparer : IComparer<int[]>
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
        /// <param name="array">One-dimensional array</param>
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
}
