using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.Sort
{
    public class ByPublisherSorter : IBookSorter
    {
        public IOrderedEnumerable<Book> Sort(ICollection<Book> books)
        {
            return from book in books
                   orderby book.Publisher
                   select book;
        }
    }
}
