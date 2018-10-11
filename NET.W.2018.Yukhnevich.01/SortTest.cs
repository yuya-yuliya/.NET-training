using NUnit.Framework;
using System;
using Sort;

namespace Test
{
  [TestFixture]
  public class Sort_test
  {
    [Test]
    public void MergeSortTest()
    {
      int[][] testArrs =
      {
        new int[0],
        new int[] { 1, 2, 3, 4, 5},
        new int[] { 5, 4, 3, 2, 1},
        new int[] { 1, 1, 1},
        new int[] { 3, 7, 1, 9, 20, -4}
      };

      foreach (int[] arr in testArrs)
      {
        int[] expected = new int[arr.Length];
        Array.Copy(arr, expected, arr.Length);
        Array.Sort(expected);
        MergeSort.Sort(arr);
        Assert.AreEqual(expected, arr);
      }
    }

    [Test]
    public void QuickSortTest()
    {
      int[][] testArrs =
      {
        new int[0],
        new int[] { 1, 2, 3, 4, 5},
        new int[] { 5, 4, 3, 2, 1},
        new int[] { 1, 1, 1},
        new int[] { 3, 7, 1, 9, 20, -4}
      };

      foreach (int[] arr in testArrs)
      {
        int[] expected = new int[arr.Length];
        Array.Copy(arr, expected, arr.Length);
        Array.Sort(expected);
        QuickSort.Sort(arr);
        Assert.AreEqual(expected, arr);
      }
    }

    [Test]
    public void SortTestArgumentNull()
    {
      Assert.Throws(typeof(ArgumentNullException), () => { MergeSort.Sort(null); });
      Assert.Throws(typeof(ArgumentNullException), () => { QuickSort.Sort(null); });
    }
  }
}
