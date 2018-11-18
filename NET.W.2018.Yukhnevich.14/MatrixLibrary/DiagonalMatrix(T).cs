using System;
using System.Collections.Generic;

namespace MatrixLibrary
{
    /// <summary>
    /// Represents diagonal matrix
    /// </summary>
    /// <typeparam name="T">Type of matrix values</typeparam>
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Initialize new instance of DiagonalMatrix with values from given array
        /// </summary>
        /// <param name="matrix">Array of matrix values</param>
        public DiagonalMatrix(T[,] matrix)
        {
            if (matrix.GetUpperBound(1) != matrix.GetUpperBound(0))
            {
                throw new ArgumentException($"{nameof(matrix)} must be square");
            }

            if (!this.IsDiagonal(matrix))
            {
                throw new ArgumentException($"{nameof(matrix)} must be diagonal");
            }

            int size = matrix.GetUpperBound(0) + 1;
            this._matrix = new T[size, size];
            Array.Copy(matrix, this._matrix, matrix.Length);
        }

        /// <summary>
        /// Initialize new instance of DiagonalMatrix with given size
        /// </summary>
        /// <param name="size">Size of matrix</param>
        public DiagonalMatrix(int size) : base(size)
        {
        }

        /// <summary>
        /// Element in the cross of i row and j column in matrix
        /// </summary>
        /// <param name="i">Index of row</param>
        /// <param name="j">Index of column</param>
        /// <returns>Value of cell</returns>
        public override T this[int i, int j]
        {
            set
            {
                int size = _matrix.GetUpperBound(0) + 1;
                if (i >= size || j >= size)
                {
                    throw new ArgumentOutOfRangeException();
                }

                EqualityComparer<T> comparer = EqualityComparer<T>.Default;
                if (i != j && !comparer.Equals(value, default(T)))
                {
                    throw new ArgumentOutOfRangeException($"Entries outside the main diagonal are all {default(T)}");
                }

                T oldValue = _matrix[i, j];
                this._matrix[i, j] = value;
                this.OnCellChange(this, new CellChangeEventArgs<T>(i, j, oldValue, value));
            }
        }

        /// <summary>
        /// Checks if the array is diagonal matrix
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns>True if the array is diagonal matrix, otherwise false</returns>
        private bool IsDiagonal(T[,] matrix)
        {
            int size = matrix.GetUpperBound(0) + 1;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i != j)
                    {
                        if (!comparer.Equals(matrix[i, j], default(T)))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
