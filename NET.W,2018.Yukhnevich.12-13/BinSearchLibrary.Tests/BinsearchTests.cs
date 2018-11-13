using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace BinSearchLibrary.Tests
{
    [TestFixture]
    public class BinSearchTests
    {
        public static IEnumerable<ITester> InvalidArgumentTestCases()
        {
            yield return new Tester<int> { Exception = typeof(ArgumentException), TestArray = new int[] { 4, 3, 6, 7 }, Item = 5 };
            yield return new Tester<int> { Exception = typeof(ArgumentNullException), TestArray = null, Item = 1 };
            yield return new Tester<string> { Exception = typeof(ArgumentNullException), TestArray = new string[] { "A", "B", "C" }, Item = null };
            yield return new Tester<string> { Exception = typeof(ArgumentNullException), TestArray = null, Item = null };
        }

        public static IEnumerable<ITester> ValidArgumentValueTypeTestCases()
        {
            yield return new Tester<int> { TestArray = new int[] { }, Item = 1, Expected = -1 };
            yield return new Tester<int> { TestArray = new int[] { 1, 2, 3 }, Item =  -3, Expected = -1 };
            yield return new Tester<int> { TestArray = new int[] { 1, 2, 3 }, Item =  10, Expected = -1 };
            yield return new Tester<int> { TestArray = new int[] { 1, 2, 2, 4 }, Item = 2, Expected = 1 };
            yield return new Tester<int> { TestArray = new int[] { 1, 4, 6}, Item = 4, Expected = 1};
        }

        public static IEnumerable<ITester> ValidArgumentRefTypeTestCases()
        {
            yield return new Tester<string> { TestArray = new string[] { }, Item = "A", Expected = -1 };
            yield return new Tester<string> { TestArray = new string[] { "C", "D", "E" }, Item = "A", Expected = -1 };
            yield return new Tester<string> { TestArray = new string[] { "C", "D", "E" }, Item = "F", Expected = -1 };
            yield return new Tester<string> { TestArray = new string[] { "A", "B", "B", "G"}, Item = "B", Expected = 1 };
            yield return new Tester<string> { TestArray = new string[] { "A", "C", "D" }, Item = "C", Expected = 1 };
        }

        [TestCaseSource("InvalidArgumentTestCases")]
        public void FindIndex_InvalidArgument_ExceptionThrows(ITester tester)
        {
            tester.TestExecute();
        }

        [TestCaseSource("ValidArgumentValueTypeTestCases")]
        public void FindIndex_ValidArgument_ValueType_ValidResult(ITester tester)
        {
            tester.TestExecute();
        }

        [TestCaseSource("ValidArgumentRefTypeTestCases")]
        public void FindIndex_ValidArgument_RefType_ValidResult(ITester tester)
        {
            tester.TestExecute();
        }
    }

    public interface ITester
    {
        void TestExecute();
    }

    public class Tester<T> : ITester
    {
        public Type Exception { get; set; }
        public T[] TestArray { get; set; }
        public T Item { get; set; }
        public int Expected { get; set; }

        public void TestExecute()
        {
            if (Exception != null)
            {
                Assert.Throws(Exception, () => BinSearch.FindIndex(TestArray, Item));
            }
            else
            {
                Assert.AreEqual(Expected, BinSearch.FindIndex(TestArray, Item));
            }
        }

        public override string ToString()
        {
            return "Test array: " +
                $"{(TestArray == null ? "null" : $"{{ {string.Join(", ", TestArray)} }}")}" +
                "; Item: " +
                $"{Item}" +
                $"; {(Exception == null ? $"Expected: {Expected}" : $"Exception: {Exception.ToString()}")}";
        }
    }
}
