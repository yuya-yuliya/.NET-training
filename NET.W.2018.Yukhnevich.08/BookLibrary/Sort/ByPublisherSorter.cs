using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.Sort
{
    /// <summary>
    /// Class provides method for sorting Books class instances collection by publisher
    /// </summary>
    public class ByPublisherSorter : IBookSorter
    {
        /// <summary>
        /// Get ordered enumerable by publisher from collection of Book class instances
        /// </summary>
        /// <param name="books">The collection of Book class instances</param>
        /// <returns>Ordered enumerable by publisher of Book class instances</returns>
        public IOrderedEnumerable<Book> Sort(ICollection<Book> books)
        {
            return from book in books
                   orderby book.Publisher
                   select book;
        }
    }
}
