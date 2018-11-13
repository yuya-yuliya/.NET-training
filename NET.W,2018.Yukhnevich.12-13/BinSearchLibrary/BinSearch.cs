using System;
using System.Collections.Generic;

namespace BinSearchLibrary
{
    public class BinSearch
    {
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
                int midInd = firstInd + (lastInd - firstInd) / 2;
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
