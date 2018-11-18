using System.Collections.Generic;

namespace BankAccountLibrary.ReadWrite
{
    /// <summary>
    /// Provides methods to read/write a collections of T class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICollectionReadWrite<T> : IReadWrite<T>
    {
        /// <summary>
        /// Read a collection of T class
        /// </summary>
        /// <returns>A collection of T class instances</returns>
        ICollection<T> CollectionRead();

        /// <summary>
        /// Write a collection of T class
        /// </summary>
        /// <param name="items">A collection of T class instances</param>
        void CollectionWrite(ICollection<T> items);
    }
}
