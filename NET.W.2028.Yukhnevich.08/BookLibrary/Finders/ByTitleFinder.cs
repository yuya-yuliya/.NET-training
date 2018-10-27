using System.Collections.Generic;

namespace BookLibrary.Finders
{
    public class ByTitleFinder : IBookFinder<string>
    {
        public Book Find(ICollection<Book> books, string value)
        {
            foreach (Book book in books)
            {
                if (book.Title == value)
                {
                    return book;
                }
            }
            return default(Book);
        }

        public Book Find(ICollection<Book> books, object value)
        {
            return Find(books, (string)value);
        }
    }
}
