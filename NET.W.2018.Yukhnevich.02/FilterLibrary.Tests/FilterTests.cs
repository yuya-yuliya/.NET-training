using NUnit.Framework;
using FilterLibrary;
using System;

namespace FilterLibrary.Tests
{
    [TestFixture]
    public class FilterTests
    {
        [TestCase(7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17, ExpectedResult = new int[]{7, 70, 17})]
        [TestCase(9, 11, 14, 5, 23, 11, ExpectedResult = new int[] { })]
        [TestCase(1, -11, 13, 7, 5, 24, 5 ,-51, 17, ExpectedResult = new int[] {-11, 13, -51, 17 })]
        public int[] Filter_FilterDigit(int digit, params int[] numbers)
        {
            return Filter.FilterDigit(digit, numbers);
        }

        [TestCase(10, 11, 5, 17)]
        [TestCase(-1, 5, 7)]
        public void Filter_FilterDigit_ArgumentException(int digit, params int[] numbers)
        {
            Assert.Throws(typeof(ArgumentException), () => { Filter.FilterDigit(digit, numbers); });
        }
    }
}
