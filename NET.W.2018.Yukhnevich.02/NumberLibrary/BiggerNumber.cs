using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NumberLibrary
{
    /// <summary>
    /// Class provide method to find next bigger number contains all digits from source number
    /// </summary>
    public class BiggerNumber
    {
        private const int SystemBase = 10;

        /// <summary>
        /// Find next bigger number contains all digits from source number
        /// </summary>
        /// <param name="number">Source number</param>
        /// <returns>Next bigger number</returns>
        public static int FindNextBiggerNumber(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException("Argument must be positive integer");
            }

            Comparer<byte> reverseOrderComparer = Comparer<byte>.Create((b1, b2) => b2.CompareTo(b1));
            byte[] digits = GetDigitsArr(number);

            for (int i = 1; i < digits.Length; i++)
            {
                int biggetInd = GetLessBiggerIndex(digits, digits[i], 0, i - 1);
                if (biggetInd == -1)
                {
                    Array.Sort(digits, 0, i + 1, reverseOrderComparer);
                }
                else
                {
                    Swap(digits, i, biggetInd);
                    Array.Sort(digits, 0, i, reverseOrderComparer);
                    return GetNumber(digits);
                }
            }

            return -1;
        }

        /// <summary>
        /// Find next bigger number contains all digits from source number with detecting time spent on finding
        /// </summary>
        /// <param name="number">Source number</param>
        /// <param name="findTime">Time spent on finding</param>
        /// <returns>Next bigger number</returns>
        public static int FindNextBiggerNumberWithTime(int number, out TimeSpan findTime)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int nextBiggerNumber = FindNextBiggerNumber(number);
            stopwatch.Stop();
            findTime = stopwatch.Elapsed;
            return nextBiggerNumber;
        }

        /// <summary>
        /// Find next bigger number contains all digits from source number with detecting time spent on finding
        /// </summary>
        /// <param name="number">Source number</param>
        /// <returns>Tuple of next bigger number and time spent on finding</returns>
        public static Tuple<int, TimeSpan> FindNextBiggerNumberWithTime(int number)
        {
            int nextBiggerNumber = FindNextBiggerNumberWithTime(number, out TimeSpan time);
            return new Tuple<int, TimeSpan>(nextBiggerNumber, time);
        }

        /// <summary>
        /// Convert number to digits array numbering from right to left
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Array of digits</returns>
        private static byte[] GetDigitsArr(int number)
        {
            List<byte> digits = new List<byte>();
            for (int num = number; num > 0; num /= SystemBase)
            {
                digits.Add((byte)(num % SystemBase));
            }

            return digits.ToArray();
        }

        /// <summary>
        /// Get less bigger number index in array part
        /// </summary>
        /// <param name="array">Array to search</param>
        /// <param name="number">Compared number</param>
        /// <param name="startInd">Start index of array part to search</param>
        /// <param name="endInd">End index of array part to search</param>
        /// <returns>Index of less bigger number in array part or -1 if there is no such number</returns>
        private static int GetLessBiggerIndex(byte[] array, byte number, int startInd, int endInd)
        {
            if (startInd < 0 || endInd < 0 || startInd >= array.Length || endInd >= array.Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (endInd < startInd)
            {
                throw new ArgumentException("Start index should be less or equal than end index");
            }

            int biggerInd = -1;
            for (int i = startInd; i <= endInd; i++)
            {
                if (array[i] > number && (biggerInd == -1 || array[biggerInd] < array[i]))
                {
                    biggerInd = i;
                }
            }

            return biggerInd;
        }

        /// <summary>
        /// Swap two elements of array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="ind1"></param>
        /// <param name="ind2"></param>
        private static void Swap(byte[] array, int ind1, int ind2)
        {
            byte temp = array[ind1];
            array[ind1] = array[ind2];
            array[ind2] = temp;
        }

        /// <summary>
        /// Convert array of digits to number
        /// </summary>
        /// <param name="digits">Array of digits numbering from right to left</param>
        /// <returns></returns>
        private static int GetNumber(byte[] digits)
        {
            int number = 0;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                number = (number * SystemBase) + digits[i];
            }

            return number;
        }
    }
}
