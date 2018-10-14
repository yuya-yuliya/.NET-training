using System;
using System.Collections.Generic;

namespace FilterLibrary
{
    /// <summary>
    /// Class provides method to filter number list in array of numbers containing the given digit
    /// </summary>
    public class Filter
    {
        private const int MinDigit = 0;
        private const int MaxDigit = 9;
        private const int SystemBase = 10;

        /// <summary>
        /// Filter number list in array of numbers containing the given digit
        /// </summary>
        /// <param name="digit">Filter digit</param>
        /// <param name="numbers">Number list for filter</param>
        /// <returns>Array of numbers containing filter digit</returns>
        public static int[] FilterDigit(int digit, params int[] numbers)
        {
            if (!IsDigit(digit))
            {
                throw new ArgumentException("First parameter must be a 10 system base digit");
            }

            List<int> containDigitNumbers = new List<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (HasDigit(digit, numbers[i]))
                {
                    containDigitNumbers.Add(numbers[i]);
                }
            }

            return containDigitNumbers.ToArray();
        }

        /// <summary>
        /// Check number is a digit
        /// </summary>
        /// <param name="number">Number for checking</param>
        /// <returns>True if number is a digit, otherwise false</returns>
        private static bool IsDigit(int number)
        { 
            if (number >= MinDigit && number <= MaxDigit)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check number is containing the given digit
        /// </summary>
        /// <param name="digit">Check digit</param>
        /// <param name="number">Number for checking</param>
        /// <returns>True if number is containing the digit, otherwise false</returns>
        private static bool HasDigit(int digit, int number)
        {
            for (int num = number; num != 0; num /= SystemBase)
            {
                if (Math.Abs(num % SystemBase) == digit)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
