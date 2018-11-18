using System;

namespace MatrixLibrary
{
    /// <summary>
    /// Provides extension method for adding matrix
    /// </summary>
    public static class MatrixExtension
    {
        /// <summary>
        /// Add together given matrices using current adding function
        /// </summary>
        /// <typeparam name="T">Type of matrix values</typeparam>
        /// <param name="matrix1">First matrix</param>
        /// <param name="matrix2">Second matrix</param>
        /// <param name="addingFunc">Adding function</param>
        /// <returns>The result matrix</returns>
        public static SquareMatrix<T> AddMatrix<T>(this SquareMatrix<T> matrix1, SquareMatrix<T> matrix2, Func<T, T, T> addingFunc)
        {
            if (matrix1 == null || matrix2 == null || addingFunc == null)
            {
                throw new ArgumentNullException();
            }

            if (matrix1.Size != matrix2.Size)
            {
                throw new ArithmeticException("Both matrix must be the same size");
            }

            int size = matrix1.Size;
            T[,] newMatrix = new T[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    newMatrix[i, j] = addingFunc(matrix1[i, j], matrix2[i, j]);
                }
            }

            return new SquareMatrix<T>(newMatrix);
        }
    }
}
