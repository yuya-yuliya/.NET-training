using System.Collections.Generic;

namespace BookLibrary.Finders
{
    public interface IBookFinder<in T> : IBookFinder
    {
        Book Find(ICollection<Book> books, T value);
    }
}
