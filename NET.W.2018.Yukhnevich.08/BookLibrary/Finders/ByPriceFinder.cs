using System;
using System.Collections.Generic;

namespace BookLibrary.Finders
{
    /// <summary>
    /// Class provides methods for finding books by price
    /// </summary>
    public class ByPriceFinder : IBookFinder<double>
    {
        private const double Delta = 0.0001;

        /// <summary>
        /// Find book in the collection by price
        /// </summary>
        /// <param name="books">The books collection</param>
        /// <param name="value">The price</param>
        /// <returns>The first element matches the price condition, if found; otherwise null</returns>
        public Book Find(ICollection<Book> books, double value)
        {
            foreach (Book book in books)
            {
                if (Math.Abs(book.Price - value) <= Delta)
                {
                    return book;
                }
            }
            return default(Book);
        }

        /// <summary>
        /// Find book in the collection by price
        /// </summary>
        /// <param name="books">The books collection</param>
        /// <param name="value">The price object that can be casted to double</param>
        /// <returns>The first element matches the price condition, if found; otherwise null</returns>
        public Book Find(ICollection<Book> books, object value)
        {
            return Find(books, (double)value);
        }
    }
}
