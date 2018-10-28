using System.Collections.Generic;

namespace BookLibrary.Finders
{
    /// <summary>
    /// Class provides methods for finding books by ISBN
    /// </summary>
    public class ByIsbnFinder : IBookFinder<string>
    {
        /// <summary>
        /// Find book in the collection by ISBN
        /// </summary>
        /// <param name="books">The books collection</param>
        /// <param name="value">The ISBN string</param>
        /// <returns>The first element matches the ISBN condition, if found; otherwise null</returns>
        public Book Find(ICollection<Book> books, string value)
        {
            foreach (Book book in books)
            {
                if (book.Isbn == value)
                {
                    return book;
                }
            }
            return default(Book);
        }

        /// <summary>
        /// Find book in the collection by ISBN
        /// </summary>
        /// <param name="books">The books collection</param>
        /// <param name="value">The ISBN object that can be casted to string</param>
        /// <returns>The first element matches the ISBN condition, if found; otherwise null</returns>
        public Book Find(ICollection<Book> books, object value)
        {
            return Find(books, (string)value);
        }
    }
}
