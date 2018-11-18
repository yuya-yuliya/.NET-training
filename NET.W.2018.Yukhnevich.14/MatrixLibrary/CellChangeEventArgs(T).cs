namespace MatrixLibrary
{
    /// <summary>
    /// Represents argument for cell change event handler
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CellChangeEventArgs<T>
    {
        /// <summary>
        /// Initialize new instance of CellChangeEventArgs with given data
        /// </summary>
        /// <param name="rowIndex">Row of changed cell</param>
        /// <param name="columnIndex">Column of changed cell</param>
        /// <param name="oldValue">Old value of changed cell</param>
        /// <param name="newValue">New value of changed cell</param>
        public CellChangeEventArgs(int rowIndex, int columnIndex, T oldValue, T newValue)
        {
            Row = rowIndex;
            Column = columnIndex;
            OldValue = oldValue;
            NewValue = newValue;
        }

        /// <summary>
        /// Column of changed cell
        /// </summary>
        public int Column { get; private set; }

        /// <summary>
        /// Row of changed cell
        /// </summary>
        public int Row { get; private set; }

        /// <summary>
        /// New value of changed cell
        /// </summary>
        public T NewValue { get; private set; }

        /// <summary>
        /// Old value of changed cell
        /// </summary>
        public T OldValue { get; private set; }
    }
}
