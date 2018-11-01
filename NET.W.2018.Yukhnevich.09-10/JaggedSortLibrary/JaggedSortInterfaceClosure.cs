using System;
using System.Collections.Generic;

namespace JaggedSortLibrary
{
    /// <summary>
    /// Class provides method to sort jagged array
    /// </summary>
    public class JaggedSortInterfaceClosure
    {
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
        /// Sort array using the specified comparer function
        /// </summary>
        /// <param name="comparer">Function for comparing array rows</param>
        /// <param name="jaggedArray">Jagged array to sort</param>
        public static void Sort(Func<int[], int[], int> comparer, int[][] jaggedArray)
        {
            InnerComparer innerComparer = new InnerComparer(comparer);
            Sort(innerComparer, jaggedArray);
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
        /// Inner class to encapsulate comparing function
        /// </summary>
        private class InnerComparer : IComparer<int[]>
        {
            private Func<int[], int[], int> _innerComparer;

            /// <summary>
            /// Initialize new instance of InnerComparer class with given comparing function
            /// </summary>
            /// <param name="comparer">Function for comparing array rows</param>
            public InnerComparer(Func<int[], int[], int> comparer)
            {
                _innerComparer = comparer ?? throw new ArgumentNullException();
            }

            /// <summary>
            /// Compare two one-dimensional arrays
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public int Compare(int[] x, int[] y)
            {
                return _innerComparer(x, y);
            }
        }
    }
}
