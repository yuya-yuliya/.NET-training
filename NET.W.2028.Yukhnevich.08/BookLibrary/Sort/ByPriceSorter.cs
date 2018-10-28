using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.Sort
{
    /// <summary>
    /// Class provides method for sorting Books class instances collection by price
    /// </summary>
    public class ByPriceSorter : IBookSorter
    {
        /// <summary>
        /// Get ordered enumerable by price from collection of Book class instances
        /// </summary>
        /// <param name="books">The collection of Book class instances</param>
        /// <returns>Ordered enumerable by price of Book class instances</returns>
        public IOrderedEnumerable<Book> Sort(ICollection<Book> books)
        {
            return from book in books
                   orderby book.Price
                   select book;
        }
    }
}
