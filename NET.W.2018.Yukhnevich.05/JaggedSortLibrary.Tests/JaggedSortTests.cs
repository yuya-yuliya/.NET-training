using NUnit.Framework;

namespace JaggedSortLibrary.Tests
{
    [TestFixture]
    public class JaggedSortTests
    {
        private int[] array1 = { 1, 4 };
        private int[] array2 = { 7, 3, 4, 8, 11 };
        private int[] array3 = { 5, 9, 20, 95 };
        private int[] array4 = { 12 };
        private int[][] jaggedArray;

        [SetUp]
        public void SetUp()
        {
            jaggedArray = new int[][] {
                array1,
                array2,
                array3,
                array4
            };
        }

        [Test]
        public void SumSort_test()
        {
            int[][] expected =
            {
                array1,
                array4,
                array2,
                array3
            };

            JaggedSort.SumSort(jaggedArray);

            Assert.AreEqual(expected, jaggedArray);
        }

        [Test]
        public void MaxElementSort_test()
        {
            int[][] expected =
            {
                array1,
                array2,
                array4,
                array3
            };

            JaggedSort.MaxElementSort(jaggedArray);

            Assert.AreEqual(expected, jaggedArray);
        }

        [Test]
        public void MinElementSort_test()
        {
            int[][] expected =
            {
                array1,
                array2,
                array3,
                array4
            };

            JaggedSort.MinElementSort(jaggedArray);

            Assert.AreEqual(expected, jaggedArray);
        }
    }
}
