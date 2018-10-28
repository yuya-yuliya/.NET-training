using System.Collections.Generic;

namespace BookLibrary.Finders
{
    /// <summary>
    /// Classs provides methods for finding books by title
    /// </summary>
    public class ByTitleFinder : IBookFinder<string>
    {
        /// <summary>
        /// Find book in the collection by title
        /// </summary>
        /// <param name="books">The books collection</param>
        /// <param name="value">The title string</param>
        /// <returns>The first element matches the title condition, if found; otherwise null</returns>
        public Book Find(ICollection<Book> books, string value)
        {
            foreach (Book book in books)
            {
                if (book.Title == value)
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
        /// <param name="value">The title object that can be casted to string</param>
        /// <returns>The first element matches the title condition, if found; otherwise null</returns>
        public Book Find(ICollection<Book> books, object value)
        {
            return Find(books, (string)value);
        }
    }
}
