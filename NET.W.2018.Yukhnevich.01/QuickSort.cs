using System;

namespace Sort
{
  /// <summary>
  /// Provides method to sort array by quick sort method
  /// </summary>
  public class QuickSort
  {
    /// <summary>
    /// Quick sort of array
    /// </summary>
    /// <param name="array">Array to sort</param>
    public static void Sort(int[] array)
    {
      if (array == null)
      {
        throw new ArgumentNullException("Expected integer array, but was null");
      }
      PartSort(array, 0, array.Length - 1);
    }

    /// <summary>
    /// Quick sort part of array
    /// </summary>
    /// <param name="array">Array to sort</param>
    /// <param name="startInd">Start index of part</param>
    /// <param name="endInd">End index of part</param>
    private static void PartSort(int[] array, int startInd, int endInd)
    {
      if (startInd < endInd)
      {
        int boundaryInd = Partition(array, startInd, endInd);
        PartSort(array, startInd, boundaryInd);
        PartSort(array, boundaryInd + 1, endInd);
      }
    }

    /// <summary>
    /// Reorder the part of array
    /// </summary>
    /// <remarks>
    /// Less than pivot element before boundary. Other elements - after boudary.
    /// Used Hoare partition scheme.
    /// </remarks>
    /// <param name="array">Array to partition</param>
    /// <param name="startInd">Start index of processing part</param>
    /// <param name="endInd">End index of processing part</param>
    /// <returns>Boundary index</returns>
    private static int Partition(int[] array, int startInd, int endInd)
    {
      int leftInd = startInd - 1, rightInd = endInd + 1, pivot = array[startInd];
      while (leftInd < rightInd)
      {
        do
        {
          leftInd++;
        }
        while (array[leftInd] < pivot);
        do
        {
          rightInd--;
        }
        while (array[rightInd] > pivot);
        if (leftInd < rightInd)
        {
          Swap(array, leftInd, rightInd);
        }
      }
      return rightInd;
    }

    /// <summary>
    /// Swap two elements in array
    /// </summary>
    /// <param name="array"></param>
    /// <param name="ind1"></param>
    /// <param name="ind2"></param>
    private static void Swap(int[] array, int ind1, int ind2)
    {
      int temp = array[ind1];
      array[ind1] = array[ind2];
      array[ind2] = temp;
    }
  }
}
