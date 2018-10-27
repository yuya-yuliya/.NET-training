using System.Collections;
using System.Collections.Generic;

namespace BookLibrary
{
    public class BookListStorage : ICollection<Book>
    {
        private List<Book> books;

        public BookListStorage(ICollection<Book> books)
        {
            this.books = new List<Book>(books);
        }

        public BookListStorage()
        {
            books = new List<Book>();
        }

        public List<Book> Books
        {
            get
            {
                List<Book> booksCopy = new List<Book>();
                booksCopy.AddRange(books);
                return booksCopy;
            }
        }

        public int Count => ((ICollection<Book>)books).Count;

        public bool IsReadOnly => ((ICollection<Book>)books).IsReadOnly;

        public void Add(Book item)
        {
            ((ICollection<Book>)books).Add(item);
        }

        public void Clear()
        {
            ((ICollection<Book>)books).Clear();
        }

        public bool Contains(Book item)
        {
            return ((ICollection<Book>)books).Contains(item);
        }

        public void CopyTo(Book[] array, int arrayIndex)
        {
            ((ICollection<Book>)books).CopyTo(array, arrayIndex);
        }

        public bool Remove(Book item)
        {
            return ((ICollection<Book>)books).Remove(item);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return ((ICollection<Book>)books).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((ICollection<Book>)books).GetEnumerator();
        }
    }
}