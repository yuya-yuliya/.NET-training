using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GCDLibrary
{
    /// <summary>
    /// Class provides methods to find GCD of two or more numbers
    /// </summary>
    public class GCD
    {
        /// <summary>
        /// Get GCD of two or more numbers using Euclidean algorithm
        /// </summary>
        /// <param name="num1">First number</param>
        /// <param name="num2">Second number</param>
        /// <param name="numbers">Other numbers</param>
        /// <returns>GCD of all numbers</returns>
        public static int GetGCDEuclidean(int num1, int num2, params int[] numbers)
        {
            return GetGCD(EuclideanGCD, num1, num2, numbers);
        }

        /// <summary>
        /// Get GCD of two or more numbers using Binary algorithm
        /// </summary>
        /// <param name="num1">First number</param>
        /// <param name="num2">Second number</param>
        /// <param name="numbers">Other numbers</param>
        /// <returns>GCD of all numbers</returns>
        public static int GetGCDBinary(int num1, int num2, params int[] numbers)
        {
            return GetGCD(BinaryGCD, num1, num2, numbers);    
        }

        /// <summary>
        /// Get GCD of two or more numbers using Euclidean algorithm
        /// </summary>
        /// <param name="time">Time spent on finding GCD</param>
        /// <param name="num1">First number</param>
        /// <param name="num2">Second number</param>
        /// <param name="numbers">Other numbers</param>
        /// <returns>GCD of all numbers</returns>
        public static int GetGCDEuclidean(out TimeSpan time, int num1, int num2, params int[] numbers)
        {
            return GetGCD(EuclideanGCD, out time, num1, num2, numbers);
        }

        /// <summary>
        /// Get GCD of two or more numbers using Binary algorithm
        /// </summary>
        /// <param name="time">Time spent on finding GCD</param>
        /// <param name="num1">First number</param>
        /// <param name="num2">Second number</param>
        /// <param name="numbers">Other numbers</param>
        /// <returns>GCD of all numbers</returns>
        public static int GetGCDBinary(out TimeSpan time, int num1, int num2, params int[] numbers)
        {
            return GetGCD(BinaryGCD, out time, num1, num2, numbers);
        }

        /// <summary>
        /// Get GCD of two or more numbers using some function
        /// </summary>
        /// <param name="gcdFinder">Function to find GCD of two positive numbers</param>
        /// <param name="num1">First number</param>
        /// <param name="num2">Second number</param>
        /// <param name="numbers">Other numbers</param>
        /// <returns>GCD of all numbers</returns>
        private static int GetGCD(Func<int, int, int> gcdFinder, int num1, int num2, params int[] numbers)
        {
            List<int> numList = new List<int>(numbers);
            numList.Add(num1);
            int gcd = Math.Abs(num2);
            for (int i = 0; i < numList.Count; i++)
            {
                gcd = gcdFinder(gcd, Math.Abs(numList[i]));
            }
            return gcd;
        }

        /// <summary>
        /// <summary>
        /// Get GCD of two or more numbers using some function
        /// </summary>
        /// <param name="gcdFinder">Function to find GCD of two positive numbers</param>
        /// <param name="time">Time spent on finding GCD</param>
        /// <param name="num1">First number</param>
        /// <param name="num2">Second number</param>
        /// <param name="numbers">Other numbers</param>
        /// <returns>GCD of all numbers</returns>
        private static int GetGCD(Func<int, int, int> gcdFinder, out TimeSpan time, int num1, int num2, params int[] numbers)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int gcd = GetGCD(gcdFinder, num1, num2, numbers);
            stopwatch.Stop();
            time = stopwatch.Elapsed;
            return gcd;
        }

        /// <summary>
        /// Get GCD of two positive numbers using Euclidean algorithm
        /// </summary>
        /// <param name="num1">First positive number</param>
        /// <param name="num2">Second positive number</param>
        /// <returns>GCD of two positive numbers</returns>
        private static int EuclideanGCD(int num1, int num2)
        {
            int temp;
            while (num2 != 0)
            {
                temp = num2;
                num2 = num1 % num2;
                num1 = temp;
            }
            return num1;
        }

        /// <summary>
        /// Get GCD of two positive numbers using Binary algorithm
        /// </summary>
        /// <param name="num1">First positive number</param>
        /// <param name="num2">Second positive number</param>
        /// <returns>GCD of two positive numbers</returns>
        private static int BinaryGCD(int num1, int num2)
        {
            if (num1 == 0 || num1 == num2)
            {
                return num2;
            }
            if (num2 == 0)
            {
                return num1;
            }
            if ((num1 & 1) == 0)
            {
                if ((num2 & 1) == 0)
                {
                    return BinaryGCD(num1 >> 1, num2 >> 1) << 1;
                }
                else
                {
                    return BinaryGCD(num1 >> 1, num2);
                }
            }
            if ((num2 & 1) == 0)
            {
                return BinaryGCD(num1, num2 >> 1);
            }
            if (num1 > num2)
            {
                return BinaryGCD((num1 - num2) >> 1, num2);
            }
            else
            {
                return BinaryGCD((num2 - num1) >> 1, num1);
            }
        }
    }
}
