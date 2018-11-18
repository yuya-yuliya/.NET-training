using System.Collections.Generic;

namespace BookLibrary.Finders
{
    /// <summary>
    /// Provides method for finding books by some tag of T class
    /// </summary>
    public interface IBookFinder<in T> : IBookFinder
    {
        /// <summary>
        /// Find book in the collection by some tag of T class
        /// </summary>
        /// <param name="books">The books collection</param>
        /// <param name="value">The tag value</param>
        /// <returns>The first element matches the tag value condition, if found; otherwise null</returns>
        Book Find(ICollection<Book> books, T value);
    }
}
