using System;
using NUnit.Framework;
using GCDLibrary;
using System.Diagnostics;

namespace GCDLibrary.Tests
{
    [TestFixture]
    public class GCDTests
    {
        [TestCase(4, 6, 8, 10, 20, 14, 16, ExpectedResult = 2)]
        [TestCase(0, 2, ExpectedResult = 2)]
        [TestCase(2, 0, ExpectedResult = 2)]
        [TestCase(1, 3, ExpectedResult = 1)]
        [TestCase(-5, 10, ExpectedResult = 5)]
        public int GetGCDEuclidean_test(int num1, int num2, params int[] numbers)
        {
            return GCD.GetGCDEuclidean(num1, num2, numbers);
        }

        [TestCase(4, 6, 8, 10, 20, 14, 16, ExpectedResult = 2)]
        [TestCase(0, 2, ExpectedResult = 2)]
        [TestCase(2, 0, ExpectedResult = 2)]
        [TestCase(1, 3, ExpectedResult = 1)]
        [TestCase(-5, 10, ExpectedResult = 5)]
        public int GetGCDBinary_test(int num1, int num2, params int[] numbers)
        {
            return GCD.GetGCDBinary(num1, num2, numbers);
        }

        [Test]
        public void GetGCDEuclidean_outTime_test()
        {
            int[] numbers = new int[1000000];
            Stopwatch stopwatch = Stopwatch.StartNew();
            GCD.GetGCDEuclidean(out TimeSpan time, numbers[0], numbers[1], numbers);
            stopwatch.Stop();
            Assert.LessOrEqual(time.Milliseconds, stopwatch.ElapsedMilliseconds);
        }

        [Test]
        public void GetGCDBinary_outTime_test()
        {
            int[] numbers = new int[1000000];
            Stopwatch stopwatch = Stopwatch.StartNew();
            GCD.GetGCDBinary(out TimeSpan time, numbers[0], numbers[1], numbers);
            stopwatch.Stop();
            Assert.LessOrEqual(time.Milliseconds, stopwatch.ElapsedMilliseconds);
        }
    }
}
