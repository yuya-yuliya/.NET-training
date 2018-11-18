using System;
using NUnit.Framework;

namespace MatrixLibrary.Tests
{
    [TestFixture]
    class SymmetricMatrixTests
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
            { 2, 2, 3, 4 },
            { 3, 3, 3, 4 },
            { 4, 4, 4, 4 }
        };

        public static string[,] StringArray =
        {
            { "A", "B", "C" },
            { "B", "B", "C" },
            { "C", "C", "C" }
        };

        [Test]
        public void Constructor_ValueTypeArrayNotSquare_Throws()
        {
            Assert.Throws<ArgumentException>(() => new SymmetricMatrix<int>(new int[1, 4]));
        }

        [Test]
        public void Constructor_RefTypeArrayNotSquare_Throws()
        {
            Assert.Throws<ArgumentException>(() => new SymmetricMatrix<string>(new string[1, 2]));
        }

        [Test]
        public void Constructor_ValueTypeArray()
        {
            Assert.DoesNotThrow(() => new SymmetricMatrix<int>(IntArray));
        }

        [Test]
        public void Constructor_RefTypeArray()
        {
            Assert.DoesNotThrow(() => new SymmetricMatrix<string>(StringArray));
        }

        [Test]
        public void Constructor_WrongSize_ValueType_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SymmetricMatrix<int>(-2));
        }

        [Test]
        public void Constructor_WrongSize_RefType_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SymmetricMatrix<string>(-1));
        }

        [Test]
        public void Constructor_Size_ValueType()
        {
            int size = 5;
            SymmetricMatrix<int> matrix = new SymmetricMatrix<int>(size);
            Assert.AreEqual(size, matrix.Size);
        }

        [Test]
        public void Constructor_Size_RefType()
        {
            int size = 5;
            SymmetricMatrix<string> matrix = new SymmetricMatrix<string>(size);
            Assert.AreEqual(size, matrix.Size);
        }

        [Test]
        public void SetCell_ValueType()
        {
            SymmetricMatrix<int> matrix = new SymmetricMatrix<int>(IntArray);
            int value = 7;
            matrix[1, 3] = value;
            Assert.AreEqual(value, matrix[1, 3]);
            Assert.AreEqual(value, matrix[3, 1]);
        }

        [Test]
        public void SetCell_RefType()
        {
            SymmetricMatrix<string> matrix = new SymmetricMatrix<string>(StringArray);
            string value = "F";
            matrix[0, 1] = value;
            Assert.AreEqual(value, matrix[0, 1]);
            Assert.AreEqual(value, matrix[1, 0]);
        }

        [Test]
        public void SetCell_Callback_ValueType()
        {
            SymmetricMatrix<int> matrix = new SymmetricMatrix<int>(IntArray);
            matrix.CellChange += CellChange;
            int value = 7;
            matrix[1, 3] = value;
            Assert.AreEqual(value, matrix[1, 3]);
            Assert.AreEqual(value, matrix[3, 1]);
            Assert.IsTrue(_wasCallback);
        }

        [Test]
        public void SetCell_Callback_RefType()
        {
            SymmetricMatrix<string> matrix = new SymmetricMatrix<string>(StringArray);
            matrix.CellChange += CellChange;
            string value = "F";
            matrix[0, 1] = value;
            Assert.AreEqual(value, matrix[0, 1]);
            Assert.AreEqual(value, matrix[1, 0]);
            Assert.IsTrue(_wasCallback);
        }

        [Test]
        public void GetCell_ValueType()
        {
            SymmetricMatrix<int> matrix = new SymmetricMatrix<int>(IntArray);
            Assert.AreEqual(IntArray[1, 1], matrix[1, 1]);
        }

        [Test]
        public void GetCell_RefType()
        {
            SymmetricMatrix<string> matrix = new SymmetricMatrix<string>(StringArray);
            Assert.AreEqual(StringArray[1, 1], matrix[1, 1]);
        }
    }
}
