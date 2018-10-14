using NUnit.Framework;
using NumberLibrary;
using System.Diagnostics;
using System;

namespace NumberLibrary.Tests
{
    [TestFixture]
    public class BiggerNumberTests
    {
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public int BiggerNumber_FindNextBiggerNumber(int number)
        {
            return BiggerNumber.FindNextBiggerNumber(number);
        }

        [Test]
        public void BiggerNumber_FindNextBiggerNumberWithTime_OutParameter()
        {
            int number = 1234321;
            Stopwatch stopwatch = new Stopwatch();
            TimeSpan findTime = new TimeSpan();
            stopwatch.Start();
            int nextBiggerNumber = BiggerNumber.FindNextBiggerNumberWithTime(number, out findTime);
            stopwatch.Stop();
            Assert.LessOrEqual(findTime, stopwatch.Elapsed);
        }

        [Test]
        public void BiggerNumber_FindNextBiggerNumberWithTime_Tuple()
        {
            int number = 1234321;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Tuple<int, TimeSpan> nextBiggerAndTime = BiggerNumber.FindNextBiggerNumberWithTime(number);
            stopwatch.Stop();
            Assert.LessOrEqual(nextBiggerAndTime.Item2, stopwatch.Elapsed);
        }
    }
}
