using System;

namespace Sort
{
  /// <summary>
  /// Provides method to sort array by merge sort method
  /// </summary>
  public class MergeSort
  {
    /// <summary>
    /// Merge sort of array
    /// </summary>
    /// <param name="array">Array to sort</param>
    public static void Sort(int[] array)
    {
      if (array == null)
      {
        throw new ArgumentNullException("Expected integer array, but was null");
      }
      var buffer = new int[array.Length];
      for (int length = 1; length < array.Length; length *= 2)
      {
        for (int i = 0; i < array.Length / length; i += 2)
        {
          MergeRuns(array, i * length, Math.Min((i + 1) * length, array.Length), Math.Min((i + 2) * length, array.Length), buffer);
        }
        Array.Copy(buffer, array, array.Length);
      }
    }

    /// <summary>
    /// Merge of runs
    /// </summary>
    /// <param name="array">Array containing runs (left run array[firstInd1, firstInd2 - 1], right run array[firstInd2, endInd2 - 1])</param>
    /// <param name="firstInd1">Left run array[firstInd1, firstInd2 - 1]</param>
    /// <param name="firstInd2">Left run array[firstInd1, firstInd2 - 1], right run array[firstInd2, endInd2 - 1]</param>
    /// <param name="endInd2">Right run array[firstInd2, endInd2 - 1]</param>
    /// <param name="buffer">Array containing merge runs</param>
    private static void MergeRuns(int[] array, int firstInd1, int firstInd2, int endInd2, int[] buffer)
    {
      int currInd1 = firstInd1, currInd2 = firstInd2;
      for (int i = firstInd1; i < endInd2; i++)
      {
        if (currInd1 < firstInd2 && (currInd2 >= endInd2 || array[currInd1] < array[currInd2]))
        {
          buffer[i] = array[currInd1++];
        }
        else
        {
          buffer[i] = array[currInd2++];
        }
      }
    }
  }
}
