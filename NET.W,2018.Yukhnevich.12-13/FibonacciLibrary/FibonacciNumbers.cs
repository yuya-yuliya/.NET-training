using System;
using System.Collections.Generic;

namespace FibonacciLibrary
{
    public class FibonacciNumbers
    {
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
