using System;
using System.Collections.Generic;

namespace FibonacciLibrary
{
    /// <summary>
    /// Provides static method to generate Fibonacci sequence
    /// </summary>
    public class FibonacciNumbers
    {
        /// <summary>
        /// Generate Fibonacci sequence
        /// </summary>
        /// <returns>Fibonacci sequence</returns>
        public static IEnumerable<long> FibonacciNumbersSequence()
        {
            long prev = 1, curr = 1;
            yield return prev;
            while (true)
            {
                yield return curr;
                long sum;
                try
                {
                    sum = checked(curr + prev);
                }
                catch (OverflowException)
                {
                    break;
                }

                prev = curr;
                curr = sum;
            }
        }
    }
}
