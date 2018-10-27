using System.Collections.Generic;

namespace BookLibrary.Finders
{
    public class ByYearFinder : IBookFinder<int>
    {
        public Book Find(ICollection<Book> books, int value)
        {
            foreach (Book book in books)
            {
                if (book.Year == value)
                {
                    return book;
                }
            }
            return default(Book);
        }

        public Book Find(ICollection<Book> books, object value)
        {
            return Find(books, (int)value);
        }
    }
}
