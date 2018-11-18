using NUnit.Framework;
using System;

namespace MatrixLibrary.Tests
{
    [TestFixture]
    public class SquareMatrixTests
    {
        private bool _wasCallback;

        [SetUp]
        public void SetUp()
        {
            _wasCallback = false;
        }

        public void CellChange<T>(object sender, CellChangeEventArgs<T> e)
        {
            _wasCallback = true;
        }

        public static int[,] IntArray =
        {
            { 1, 2, 3, 4 },
            { 1, 2, 3, 4 },
            { 1, 2, 3, 4 },
            { 1, 2, 3, 4 }
        };

        public static string[,] StringArray =
        {
            { "A", "B", "C" },
            { "A", "B", "C" },
            { "A", "B", "C" }
        };

        [Test]
        public void Constructor_ValueTypeArrayNotSquare_Throws()
        {
            Assert.Throws<ArgumentException>(() => new SquareMatrix<int>(new int[1, 4]));
        }

        [Test]
        public void Constructor_RefTypeArrayNotSquare_Throws()
        {
            Assert.Throws<ArgumentException>(() => new SquareMatrix<string>(new string[1,2]));
        }

        [Test]
        public void Constructor_ValueTypeArray()
        {
            Assert.DoesNotThrow(() => new SquareMatrix<int>(IntArray));
        }

        [Test]
        public void Constructor_RefTypeArray()
        {
            Assert.DoesNotThrow(() => new SquareMatrix<string>(StringArray));
        }

        [Test]
        public void Constructor_WrongSize_ValueType_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SquareMatrix<int>(-2));
        }

        [Test]
        public void Constructor_WrongSize_RefType_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SquareMatrix<string>(-1));
        }

        [Test]
        public void Constructor_Size_ValueType()
        {
            int size = 5;
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(size);
            Assert.AreEqual(size, squareMatrix.Size);
        }

        [Test]
        public void Constructor_Size_RefType()
        {
            int size = 5;
            SquareMatrix<string> squareMatrix = new SquareMatrix<string>(size);
            Assert.AreEqual(size, squareMatrix.Size);
        }

        [Test]
        public void SetCell_ValueType()
        {
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(IntArray);
            int value = 7;
            squareMatrix[1, 3] = value;
            Assert.AreEqual(value, squareMatrix[1, 3]);
        }

        [Test]
        public void SetCell_RefType()
        {
            SquareMatrix<string> squareMatrix = new SquareMatrix<string>(StringArray);
            string value = "F";
            squareMatrix[1, 1] = value;
            Assert.AreEqual(value, squareMatrix[1, 1]);
        }

        [Test]
        public void SetCell_Callback_ValueType()
        {
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(IntArray);
            squareMatrix.CellChange += CellChange;
            int value = 7;
            squareMatrix[1, 3] = value;
            Assert.AreEqual(value, squareMatrix[1, 3]);
            Assert.IsTrue(_wasCallback);
        }

        [Test]
        public void SetCell_Callback_RefType()
        {
            SquareMatrix<string> squareMatrix = new SquareMatrix<string>(StringArray);
            squareMatrix.CellChange += CellChange;
            string value = "F";
            squareMatrix[1, 1] = value;
            Assert.AreEqual(value, squareMatrix[1, 1]);
            Assert.IsTrue(_wasCallback);
        }

        [Test]
        public void GetCell_ValueType()
        {
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(IntArray);
            Assert.AreEqual(IntArray[1, 1], squareMatrix[1, 1]);
        }

        [Test]
        public void GetCell_RefType()
        {
            SquareMatrix<string> squareMatrix = new SquareMatrix<string>(StringArray);
            Assert.AreEqual(StringArray[1, 1], squareMatrix[1, 1]);
        }
    }
}
