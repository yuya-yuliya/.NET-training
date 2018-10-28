using System.Collections.Generic;

namespace BookLibrary.Finders
{
    /// <summary>
    /// Class provides methods for finding books by publisher
    /// </summary>
    public class ByPublisherFinder : IBookFinder<string>
    {
        /// <summary>
        /// Find book in the collection by publisher
        /// </summary>
        /// <param name="books">The books collection</param>
        /// <param name="value">The publisher string</param>
        /// <returns>The first element matches the publisher condition, if found; otherwise null</returns>
        public Book Find(ICollection<Book> books, string value)
        {
            foreach (Book book in books)
            {
                if (book.Publisher == value)
                {
                    return book;
                }
            }
            return default(Book);
        }

        /// <summary>
        /// Find book in the collection by publisher
        /// </summary>
        /// <param name="books">The books collection</param>
        /// <param name="value">The publisher object that can be casted to string</param>
        /// <returns>The first element matches the publisher condition, if found; otherwise null</returns>
        public Book Find(ICollection<Book> books, object value)
        {
            return Find(books, (string)value);
        }
    }
}
