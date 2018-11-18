using System.Collections;
using System.Collections.Generic;

namespace BookLibrary
{
    /// <summary>
    /// Represents storage of Book class instances
    /// </summary>
    public class BookListStorage : ICollection<Book>
    {
        private List<Book> books;

        /// <summary>
        /// Initialize new instance of BookListStorage with fill book list, copied from current collection
        /// </summary>
        /// <param name="books">The source collection for BookListStorage</param>
        public BookListStorage(ICollection<Book> books)
        {
            this.books = new List<Book>(books);
        }

        /// <summary>
        /// Initialize new instance of BookListStorage with empty book list
        /// </summary>
        public BookListStorage()
        {
            books = new List<Book>();
        }

        /// <summary>
        /// Gets copy of internal list of Book class instances
        /// </summary>
        public List<Book> Books
        {
            get
            {
                List<Book> booksCopy = new List<Book>();
                booksCopy.AddRange(books);
                return booksCopy;
            }
        }

        /// <summary>
        /// Gets count of Book class instances in storage
        /// </summary>
        public int Count => ((ICollection<Book>)books).Count;

        /// <summary>
        /// True if the collection is readonly, false otherwise
        /// </summary>
        public bool IsReadOnly => ((ICollection<Book>)books).IsReadOnly;

        public void Add(Book item)
        {
            ((ICollection<Book>)books).Add(item);
        }

        /// <summary>
        /// Clears the book list storage
        /// </summary>
        public void Clear()
        {
            ((ICollection<Book>)books).Clear();
        }

        /// <summary>
        /// Checks the containing of current Book class instance
        /// </summary>
        /// <param name="item">The Book class instance</param>
        /// <returns>True if the storage contains the current Book class instance</returns>
        public bool Contains(Book item)
        {
            return ((ICollection<Book>)books).Contains(item);
        }

        /// <summary>
        /// Copies the content of storage to array, starts from given index
        /// </summary>
        /// <param name="array">Destination for copying</param>
        /// <param name="arrayIndex">Start index</param>
        public void CopyTo(Book[] array, int arrayIndex)
        {
            ((ICollection<Book>)books).CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the given Book class instance from storage
        /// </summary>
        /// <param name="item">The Book class instance to remove</param>
        /// <returns>True if the removing was successful, false otherwise</returns>
        public bool Remove(Book item)
        {
            return ((ICollection<Book>)books).Remove(item);
        }

        /// <summary>
        /// Gets the enumerator for parametrized collection
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Book> GetEnumerator()
        {
            return ((ICollection<Book>)books).GetEnumerator();
        }

        /// <summary>
        /// Gets the enumerator for universal collection
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((ICollection<Book>)books).GetEnumerator();
        }
    }
}