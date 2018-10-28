namespace BankAccountLibrary.ReadWrite
{
    /// <summary>
    /// Provides methods for reading/writing instances of T class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IReadWrite<T>
    {
        /// <summary>
        /// Read T class instance
        /// </summary>
        /// <returns>New instance of T class</returns>
        T Read();
        /// <summary>
        /// Write T class instance
        /// </summary>
        /// <param name="item">T class instance</param>
        void Write(T item);
    }
}
