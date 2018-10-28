using System.Collections.Generic;

namespace BookLibrary.ReadWrite
{
    /// <summary>
    /// Provides methods to read/write of Book class
    /// </summary>
    public interface IBookReadWrite
    {
        /// <summary>
        /// Read a collection of Book class
        /// </summary>
        /// <returns>A collection of Book class instances</returns>
        ICollection<Book> ReadCollection();
        /// <summary>
        /// Write a collection of Book class
        /// </summary>
        /// <param name="books">A collection of Book class instances</param>
        void WriteCollection(ICollection<Book> books);
        /// <summary>
        /// Read Book class instance
        /// </summary>
        /// <returns>New instance of Book class</returns>
        Book ReadBook();
        /// <summary>
        /// Write Book class instance
        /// </summary>
        /// <param name="book">Book class instance</param>
        void WriteBook(Book book);
    }
}
