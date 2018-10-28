using System.Collections.Generic;

namespace BookLibrary.Finders
{
    /// <summary>
    /// Provides method for finding books by some tag
    /// </summary>
    public interface IBookFinder
    {
        /// <summary>
        /// Find book in the collection by some tag
        /// </summary>
        /// <param name="books">The books collection</param>
        /// <param name="value">The tag object</param>
        /// <returns>The first element matches the tag condition, if found; otherwise null</returns>
        Book Find(ICollection<Book> books, object value);
    }
}
