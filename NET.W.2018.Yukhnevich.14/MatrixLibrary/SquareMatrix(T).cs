using System;

namespace MatrixLibrary
{
    /// <summary>
    /// Represents square matrix
    /// </summary>
    /// <typeparam name="T">Type of matrix values</typeparam>
    public class SquareMatrix<T>
    {
        /// <summary>
        /// Initialize new instance of SquareMatrix with values from given array
        /// </summary>
        /// <param name="matrix">Array of matrix values</param>
        public SquareMatrix(T[,] matrix)
        {
            if (matrix.GetUpperBound(1) != matrix.GetUpperBound(0))
            {
                throw new ArgumentException($"{nameof(matrix)} must be square");
            }

            int size = matrix.GetUpperBound(0) + 1;
            _matrix = new T[size, size];
            Array.Copy(matrix, _matrix, matrix.Length);
        }

        /// <summary>
        /// Initialize new instance of SquareMatrix with given size
        /// </summary>
        /// <param name="size">Size of matrix</param>
        public SquareMatrix(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            _matrix = new T[size, size];
        }

        /// <summary>
        /// Initialize new instance of SquareMatrix zero capacity
        /// </summary>
        protected SquareMatrix()
        {
            _matrix = new T[0, 0];
        }

        /// <summary>
        /// Delegate for handling matrix cell changes
        /// </summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Cell change information</param>
        public delegate void CellChangeHandler(object sender, CellChangeEventArgs<T> e);

        /// <summary>
        /// Event on the matrix cell changed
        /// </summary>
        public event CellChangeHandler CellChange;

        /// <summary>
        /// Count of elements in the matrix
        /// </summary>
        public int Count
        {
            get
            {
                return _matrix.Length;
            }
        }

        /// <summary>
        /// Size of the matrix
        /// </summary>
        public int Size
        {
            get
            {
                return _matrix.GetUpperBound(0) + 1;
            }
        }

        /// <summary>
        /// Array of the matrix values
        /// </summary>
        protected T[,] _matrix { get; set; }

        /// <summary>
        /// Element in cross of i row and j column in matrix
        /// </summary>
        /// <param name="i">Index of row</param>
        /// <param name="j">Index of column</param>
        /// <returns>Value of cell</returns>
        public virtual T this[int i, int j]
        {
            get
            {
                int size = _matrix.GetUpperBound(0) + 1;
                if (i >= size || j >= size)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return _matrix[i, j];
            }

            set
            {
                int size = _matrix.GetUpperBound(0) + 1;
                if (i >= size || j >= size)
                {
                    throw new ArgumentOutOfRangeException();
                }

                T oldValue = _matrix[i, j];
                _matrix[i, j] = value;
                OnCellChange(this, new CellChangeEventArgs<T>(i, j, oldValue, value));
            }
        }

        /// <summary>
        /// Notify about the matrix cell changes
        /// </summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Cell change information</param>
        protected virtual void OnCellChange(object sender, CellChangeEventArgs<T> e)
        {
            CellChange?.Invoke(sender, e);
        }
    }
}
