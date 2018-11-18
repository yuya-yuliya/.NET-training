using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MatrixLibrary.Tests
{
    [TestFixture]
    public class ExtensionMatrixTests
    {
        public static IEnumerable<ITester> AddMatrixValueTypeTestCases()
        {
            Func<int, int, int> intAdding = (a, b) => a + b;
            int[,] squareArr = 
            {
                { 1, 1, 1 },
                { 1, 1, 1 },
                { 1, 1, 1 }
            };
            int[,] diagonalArr = 
            {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 1 }
            };
            int[,] symmetricArr =
            {
                { 1, 2, 3 },
                { 2, 2, 3 },
                { 3, 3, 3 },
            };
            yield return new Tester<int>(AddMatrix(squareArr, squareArr, intAdding), new SquareMatrix<int>(squareArr), new SquareMatrix<int>(squareArr), intAdding);
            yield return new Tester<int>(AddMatrix(diagonalArr, diagonalArr, intAdding), new DiagonalMatrix<int>(diagonalArr), new DiagonalMatrix<int>(diagonalArr), intAdding);
            yield return new Tester<int>(AddMatrix(symmetricArr, symmetricArr, intAdding), new SymmetricMatrix<int>(symmetricArr), new SymmetricMatrix<int>(symmetricArr), intAdding);
            yield return new Tester<int>(AddMatrix(squareArr, diagonalArr, intAdding), new SquareMatrix<int>(squareArr), new DiagonalMatrix<int>(diagonalArr), intAdding);
            yield return new Tester<int>(AddMatrix(squareArr, symmetricArr, intAdding), new SquareMatrix<int>(squareArr), new SymmetricMatrix<int>(symmetricArr), intAdding);
            yield return new Tester<int>(AddMatrix(symmetricArr, diagonalArr, intAdding), new SymmetricMatrix<int>(symmetricArr), new DiagonalMatrix<int>(diagonalArr), intAdding);
        }

        public static IEnumerable<ITester> AddMatrixRefTypeTestCases()
        {
            Func<string, string, string> stringAdding = (a, b) => a + b;
            string[,] squareArr =
            {
                { "A", "B", "C" },
                { "A", "B", "C" },
                { "A", "B", "C" }
            };
            string[,] diagonalArr =
            {
                { "A", null, null },
                { null, "B", null },
                { null, null, "C" }
            };
            string[,] symmetricArr =
            {
                { "A", "B", "C" },
                { "B", "B", "C" },
                { "C", "C", "C" },
            };
            yield return new Tester<string>(AddMatrix(squareArr, squareArr, stringAdding), new SquareMatrix<string>(squareArr), new SquareMatrix<string>(squareArr), stringAdding);
            yield return new Tester<string>(AddMatrix(diagonalArr, diagonalArr, stringAdding), new DiagonalMatrix<string>(diagonalArr), new DiagonalMatrix<string>(diagonalArr), stringAdding);
            yield return new Tester<string>(AddMatrix(symmetricArr, symmetricArr, stringAdding), new SymmetricMatrix<string>(symmetricArr), new SymmetricMatrix<string>(symmetricArr), stringAdding);
            yield return new Tester<string>(AddMatrix(squareArr, diagonalArr, stringAdding), new SquareMatrix<string>(squareArr), new DiagonalMatrix<string>(diagonalArr), stringAdding);
            yield return new Tester<string>(AddMatrix(squareArr, symmetricArr, stringAdding), new SquareMatrix<string>(squareArr), new SymmetricMatrix<string>(symmetricArr), stringAdding);
            yield return new Tester<string>(AddMatrix(symmetricArr, diagonalArr, stringAdding), new SymmetricMatrix<string>(symmetricArr), new DiagonalMatrix<string>(diagonalArr), stringAdding);
        }

        [Test]
        public void AddMatrix_NullFirstMatrix_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => ((SquareMatrix<int>)null).AddMatrix(new SquareMatrix<int>(4), (i, j) => 5));
        }

        [Test]
        public void AddMatrix_NullSecondMatrix_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new DiagonalMatrix<int>(4).AddMatrix(null, (i, j) => 5));
        }

        [Test]
        public void AddMatrix_NullAdditionFunc_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new SymmetricMatrix<int>(4).AddMatrix(new SquareMatrix<int>(4), null));
        }

        [TestCaseSource(nameof(AddMatrixValueTypeTestCases))]
        public void AddMatrix_ValueType(ITester tester)
        {
            tester.Test();
        }

        [TestCaseSource(nameof(AddMatrixRefTypeTestCases))]
        public void AddMatrix_RefType(ITester tester)
        {
            tester.Test();
        }

        private static T[,] AddMatrix<T>(T[,] array1, T[,] array2, Func<T, T, T> addingFunc)
        {
            int size = array1.GetUpperBound(0) + 1;
            T[,] result = new T[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = addingFunc(array1[i, j], array2[i, j]);
                }
            }

            return result;
        }
    }

    public interface ITester
    {
        void Test();
    }

    public class Tester<T> : ITester
    {
        private T[,] _expected;
        private SquareMatrix<T> _matrix1;
        private SquareMatrix<T> _matrix2;
        private Func<T, T, T> _addingFunc;

        public Tester(T[,] expected, SquareMatrix<T> matrix1, SquareMatrix<T> matrix2, Func<T, T, T> addingFunc)
        {
            _expected = expected;
            _matrix1 = matrix1;
            _matrix2 = matrix2;
            _addingFunc = addingFunc;
        }

        public void Test()
        {
            SquareMatrix<T> result = _matrix1.AddMatrix(_matrix2, _addingFunc);
            Assert.AreEqual(_expected.Length, result.Count);
            for (int i = 0; i < result.Size; i++)
            {
                for (int j = 0; j < result.Size; j++)
                {
                    Assert.AreEqual(_expected[i, j], result[i, j], $"Expected: {_expected[i, j]} But was: {result[i, j]} at index [{i},{j}]");
                }
            }
        }

        public override string ToString()
        {
            return _matrix1.ToString() + " " + _matrix2.ToString();
        }
    }
}
