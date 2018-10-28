using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.Sort
{
    /// <summary>
    /// Class provides method for sorting Books class instances collection by year
    /// </summary>
    public class ByYearSorter : IBookSorter
    {
        /// <summary>
        /// Get ordered enumerable by year from collection of Book class instances
        /// </summary>
        /// <param name="books">The collection of Book class instances</param>
        /// <returns>Ordered enumerable by year of Book class instances</returns>
        public IOrderedEnumerable<Book> Sort(ICollection<Book> books)
        {
            return from book in books
                   orderby book.Year
                   select book;
        }
    }
}
