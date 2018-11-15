using System;
using System.Collections.Generic;

namespace BinSearchLibrary
{
    /// <summary>
    /// Provides static method for finding index of element in sorted array
    /// </summary>
    public class BinSearch
    {
        /// <summary>
        /// Finds index of element in sorted array
        /// </summary>
        /// <typeparam name="T">Type of elements</typeparam>
        /// <param name="array">Sorted array</param>
        /// <param name="item">Element to find</param>
        /// <returns>Index of element in array if array contains this element, otherwise -1</returns>
        public static int FindIndex<T>(T[] array, T item)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (!(item is ValueType) && (item == null))
            {
                throw new ArgumentNullException(nameof(item));
            }

            Comparer<T> defComparer = Comparer<T>.Default;
            if ((array.Length == 0) || (defComparer.Compare(item, array[0]) < 0) || (defComparer.Compare(array[array.Length - 1], item) < 0))
            {
                return -1;
            }

            int firstInd = 0;
            int lastInd = array.Length;

            while (firstInd < lastInd)
            {
                if (defComparer.Compare(array[firstInd], array[lastInd - 1]) > 0)
                {
                    throw new ArgumentException($"{nameof(array)} must be sorted");
                }

                int midInd = firstInd + ((lastInd - firstInd) / 2);
                if (defComparer.Compare(item, array[midInd]) <= 0)
                {
                    lastInd = midInd;
                }
                else
                {
                    firstInd = midInd + 1;
                }
            }

            if (defComparer.Compare(array[lastInd], item) == 0)
            {
                return lastInd;
            }

            return -1;
        }
    }
}
