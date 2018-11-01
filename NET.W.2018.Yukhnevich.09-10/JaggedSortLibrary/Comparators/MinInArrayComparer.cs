using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedSortLibrary.Comparators
{
    /// <summary>
    /// Class provides method to compare one-dimensional by minimum element and implements interface IComparer&ltint[]$gt
    /// </summary>
    public class MinInArrayComparer : IComparer<int[]>
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
        /// <param name="array">One-dimensional array</param>
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
