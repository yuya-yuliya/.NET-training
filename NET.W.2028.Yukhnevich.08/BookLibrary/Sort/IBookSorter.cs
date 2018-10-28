using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.Sort
{
    /// <summary>
    /// Provides method for sorting Books class instances collection by tag
    /// </summary>
    public interface IBookSorter
    {
        /// <summary>
        /// Get ordered enumerable by tag from collection of Book class instances
        /// </summary>
        /// <param name="books">The collection of Book class instances</param>
        /// <returns>Ordered enumerable by tag of Book class instances</returns>
        IOrderedEnumerable<Book> Sort(ICollection<Book> books);
    }
}
