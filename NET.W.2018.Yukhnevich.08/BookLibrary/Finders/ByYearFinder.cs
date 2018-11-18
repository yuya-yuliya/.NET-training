using System.Collections.Generic;

namespace BookLibrary.Finders
{
    /// <summary>
    /// Class provides methods for finding books by year
    /// </summary>
    public class ByYearFinder : IBookFinder<int>
    {
        /// <summary>
        /// Find book in the collection by year
        /// </summary>
        /// <param name="books">The books collection</param>
        /// <param name="value">The year</param>
        /// <returns>The first element matches the year condition, if found; otherwise null</returns>
        public Book Find(ICollection<Book> books, int value)
        {
            foreach (Book book in books)
            {
                if (book.Year == value)
                {
                    return book;
                }
            }
            return default(Book);
        }

        /// <summary>
        /// Find book in the collection by year
        /// </summary>
        /// <param name="books">The books collection</param>
        /// <param name="value">The year object that can be casted to int</param>
        /// <returns>The first element matches the title condition, if found; otherwise null</returns>
        public Book Find(ICollection<Book> books, object value)
        {
            return Find(books, (int)value);
        }
    }
}
