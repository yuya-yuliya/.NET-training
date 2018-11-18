using System.Collections.Generic;

namespace BookLibrary.Finders
{
    /// <summary>
    /// Class provides methods for finding books by count of page
    /// </summary>
    public class ByCountPagesFinder : IBookFinder<int>
    {
        /// <summary>
        /// Find book in the collection by count of page
        /// </summary>
        /// <param name="books">The books collection</param>
        /// <param name="value">The count of page</param>
        /// <returns>The first element matches the count of page condition, if found; otherwise null</returns>
        public Book Find(ICollection<Book> books, int value)
        {
            foreach (Book book in books)
            {
                if (book.CountPages == value)
                {
                    return book;
                }
            }
            return default(Book);
        }

        /// <summary>
        /// Find book in the collection by count of page
        /// </summary>
        /// <param name="books">The books collection</param>
        /// <param name="value">The count of page object that can be casted to int</param>
        /// <returns>The first element matches the count of page condition, if found; otherwise null</returns>
        public Book Find(ICollection<Book> books, object value)
        {
            return Find(books, (int)value);
        }
    }
}
