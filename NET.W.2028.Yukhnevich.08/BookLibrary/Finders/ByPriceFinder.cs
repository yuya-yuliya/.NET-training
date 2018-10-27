using System;
using System.Collections.Generic;

namespace BookLibrary.Finders
{
    public class ByPriceFinder : IBookFinder<double>
    {
        private const double Delta = 0.0001;

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

        public Book Find(ICollection<Book> books, object value)
        {
            return Find(books, (double)value);
        }
    }
}
