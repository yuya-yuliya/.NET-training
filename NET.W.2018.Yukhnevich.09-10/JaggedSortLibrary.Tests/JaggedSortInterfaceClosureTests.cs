using JaggedSortLibrary.Comparators;
using NUnit.Framework;
using System.Collections.Generic;

namespace JaggedSortLibrary.Tests
{
    [TestFixture]
    public class JaggedSortInterfaceClosureTests
    {
        static int[] array1 = { 1, 4 };
        static int[] array2 = { 7, 3, 4, 8, 11 };
        static int[] array3 = { 5, 9, 20, 95 };
        static int[] array4 = { 12 };
        static int[][] jaggedArray =
        {
                array1,
                array2,
                array3,
                array4
        };

        static object[] SortCases =
        {
            new object[] { new ArraySumComparer(), jaggedArray, new int[][] { array1, array4, array2, array3 } },
            new object[] { new MaxInArrayComparer(), jaggedArray, new int[][] { array1, array2, array4, array3 } },
            new object[] { new MinInArrayComparer(), jaggedArray, new int[][] { array1, array2, array3, array4 } }
        };

        [TestCaseSource("SortCases")]
        public void Sort_IComparerArgument_ValidReselt(IComparer<int[]> comparer, int[][] array, int[][] expected)
        {
            JaggedSortInterfaceClosure.Sort(comparer, array);
            Assert.AreEqual(expected, array);
        }

        [TestCaseSource("SortCases")]
        public void Sort_FuncArgument_ValidReselt(IComparer<int[]> comparer, int[][] array, int[][] expected)
        {
            JaggedSortInterfaceClosure.Sort(comparer.Compare, array);
            Assert.AreEqual(expected, array);
        }
    }
}
