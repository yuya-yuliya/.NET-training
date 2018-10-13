using System;
using NUnit.Framework;
using Number;

namespace NumberNUnitTest
{
    [TestFixture]
    public class NumberNUnitTest
    {
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        public int Numbers_InsertNumber(int numberSource, int numberIn, int startBit, int endBit)
        {
            return Numbers.InsertNumber(numberSource, numberIn, startBit, endBit);
        }
    }
}
