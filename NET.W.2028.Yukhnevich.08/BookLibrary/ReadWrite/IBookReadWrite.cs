using System.Collections.Generic;

namespace BookLibrary.ReadWrite
{
    public interface IBookReadWrite
    {
        ICollection<Book> ReadCollection();
        void WriteCollection(ICollection<Book> books);
        Book ReadBook();
        void WriteBook(Book book);
    }
}
