using System;
using NUnit.Framework;

namespace MatrixLibrary.Tests
{
    [TestFixture]
    class DiagonalMatrixTests
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
            { 1, 0, 0, 0 },
            { 0, 2, 0, 0 },
            { 0, 0, 3, 0 },
            { 0, 0, 0, 4 }
        };

        public static string[,] StringArray =
        {
            { "A", null, null },
            { null, "B", null },
            { null, null, "C" }
        };

        [Test]
        public void Constructor_ValueTypeArrayNotSquare_Throws()
        {
            Assert.Throws<ArgumentException>(() => new DiagonalMatrix<int>(new int[1, 4]));
        }

        [Test]
        public void Constructor_RefTypeArrayNotSquare_Throws()
        {
            Assert.Throws<ArgumentException>(() => new DiagonalMatrix<string>(new string[1, 2]));
        }

        [Test]
        public void Constructor_ValueTypeArray()
        {
            Assert.DoesNotThrow(() => new DiagonalMatrix<int>(IntArray));
        }

        [Test]
        public void Constructor_RefTypeArray()
        {
            Assert.DoesNotThrow(() => new DiagonalMatrix<string>(StringArray));
        }

        [Test]
        public void Constructor_WrongSize_ValueType_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new DiagonalMatrix<int>(-2));
        }

        [Test]
        public void Constructor_WrongSize_RefType_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new DiagonalMatrix<string>(-1));
        }

        [Test]
        public void Constructor_Size_ValueType()
        {
            int size = 5;
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>(size);
            Assert.AreEqual(size, matrix.Size);
        }

        [Test]
        public void Constructor_Size_RefType()
        {
            int size = 5;
            DiagonalMatrix<string> matrix = new DiagonalMatrix<string>(size);
            Assert.AreEqual(size, matrix.Size);
        }

        [Test]
        public void SetCell_ValueType()
        {
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>(IntArray);
            int value = 7;
            matrix[1, 1] = value;
            Assert.AreEqual(value, matrix[1, 1]);
        }

        [Test]
        public void SetCell_RefType()
        {
            DiagonalMatrix<string> matrix = new DiagonalMatrix<string>(StringArray);
            string value = "F";
            matrix[0, 0] = value;
            Assert.AreEqual(value, matrix[0, 0]);
        }

        [Test]
        public void SetCell_CellOutsideMainDiagonal_ValueType_Throws()
        {
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>(IntArray);
            int value = 7;
            Assert.Throws<ArgumentOutOfRangeException>(() => matrix[1, 0] = value);
        }

        [Test]
        public void SetCell_CellOutsideMainDiagonal_RefType_Throws()
        {
            DiagonalMatrix<string> matrix = new DiagonalMatrix<string>(StringArray);
            string value = "F";
            Assert.Throws<ArgumentOutOfRangeException>(() => matrix[1, 0] = value);
        }

        [Test]
        public void SetCell_Callback_ValueType()
        {
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>(IntArray);
            matrix.CellChange += CellChange;
            int value = 7;
            matrix[1, 1] = value;
            Assert.AreEqual(value, matrix[1, 1]);
            Assert.IsTrue(_wasCallback);
        }

        [Test]
        public void SetCell_Callback_RefType()
        {
            DiagonalMatrix<string> matrix = new DiagonalMatrix<string>(StringArray);
            matrix.CellChange += CellChange;
            string value = "F";
            matrix[1, 1] = value;
            Assert.AreEqual(value, matrix[1, 1]);
            Assert.IsTrue(_wasCallback);
        }

        [Test]
        public void GetCell_ValueType()
        {
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>(IntArray);
            Assert.AreEqual(IntArray[1, 1], matrix[1, 1]);
        }

        [Test]
        public void GetCell_RefType()
        {
            DiagonalMatrix<string> matrix = new DiagonalMatrix<string>(StringArray);
            Assert.AreEqual(StringArray[1, 1], matrix[1, 1]);
        }
    }
}
