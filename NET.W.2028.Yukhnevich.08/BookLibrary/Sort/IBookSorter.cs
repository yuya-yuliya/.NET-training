using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.Sort
{
    public interface IBookSorter
    {
        IOrderedEnumerable<Book> Sort(ICollection<Book> books);
    }
}
