using System.Collections.Generic;

namespace BookLibrary.Finders
{
    /// <summary>
    /// Class provides methods for finding books by author
    /// </summary>
    public class ByAuthorFinder : IBookFinder<string>
    {
        /// <summary>
        /// Find book in the collection by author
        /// </summary>
        /// <param name="books">The books collection</param>
        /// <param name="value">The author string</param>
        /// <returns>The first element matches the author condition, if found; otherwise null</returns>
        public Book Find(ICollection<Book> books, string value)
        {
            foreach (Book book in books)
            {
                if (book.Author == value)
                {
                    return book;
                }
            }
            return default(Book);
        }

        /// <summary>
        /// Find book in the collection by author
        /// </summary>
        /// <param name="books">The books collection</param>
        /// <param name="value">The author object that can be casted to string</param>
        /// <returns>The first element matches the author condition, if found; otherwise null</returns>
        public Book Find(ICollection<Book> books, object value)
        {
            return Find(books, (string)value);
        }
    }
}
