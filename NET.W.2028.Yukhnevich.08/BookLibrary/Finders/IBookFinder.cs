using System.Collections.Generic;

namespace BookLibrary.Finders
{
    public interface IBookFinder
    {
        Book Find(ICollection<Book> books, object value);
    }
}
