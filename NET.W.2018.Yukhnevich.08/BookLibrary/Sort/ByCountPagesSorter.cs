using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.Sort
{
    /// <summary>
    /// Class provides method for sorting Books class instances collection by count of page
    /// </summary>
    public class ByCountPagesSorter : IBookSorter
    {
        /// <summary>
        /// Get ordered enumerable by count of page from collection of Book class instances
        /// </summary>
        /// <param name="books">The collection of Book class instances</param>
        /// <returns>Ordered enumerable by count of page of Book class instances</returns>
        public IOrderedEnumerable<Book> Sort(ICollection<Book> books)
        {
            return from book in books
                   orderby book.CountPages
                   select book;
        }
    }
}
