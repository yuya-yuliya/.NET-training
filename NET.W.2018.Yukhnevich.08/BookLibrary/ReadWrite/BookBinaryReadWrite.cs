using System.Collections.Generic;
using System.IO;

namespace BookLibrary.ReadWrite
{
    /// <summary>
    /// Class provides methods for read and wtite in binary form to file of book information
    /// </summary>
    public class BookBinaryReadWrite : IBookReadWrite
    {
        /// <summary>
        /// Path to read/write file
        /// </summary>
        public readonly string Path;

        /// <summary>
        /// Initializes a new instance of the BookBinaryReadWrite class that has path to read/write file
        /// </summary>
        /// <param name="path">Path to read/write file</param>
        public BookBinaryReadWrite(string path)
        {
            Path = path;
        }

        /// <summary>
        /// Read the information of book from file
        /// </summary>
        /// <returns>New instance of Book class that has information</returns>
        public Book ReadBook()
        {
            using (BinaryReader reader = new BinaryReader(File.OpenRead(Path)))
            {
                return ReadBook(reader);
            }
        }

        /// <summary>
        /// Read collection of Book instances from file in binary form
        /// </summary>
        /// <returns>Collection of books</returns>
        public ICollection<Book> ReadCollection()
        {
            List<Book> books = new List<Book>();
            using (BinaryReader reader = new BinaryReader(File.OpenRead(Path)))
            {
                while (reader.PeekChar() > -1)
                {
                    books.Add(ReadBook(reader));
                }
            }
            return books;
        }

        /// <summary>
        /// Write the information of book in file
        /// </summary>
        /// <param name="book">Instance of Book class that has information to write</param>
        public void WriteBook(Book book)
        {
            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(Path)))
            {
                WriteBook(writer, book);
            }
        }

        /// <summary>
        /// Write collection of Book class instances in file in binary form
        /// </summary>
        /// <param name="books">Collection of Book class instances</param>
        public void WriteCollection(ICollection<Book> books)
        {
            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(Path)))
            {
                foreach (Book book in books)
                {
                    WriteBook(writer, book);
                }
            }
        }

        /// <summary>
        /// Read the information of book from binary reader
        /// </summary>
        /// <param name="reader">Binary reader for reading</param>
        /// <returns>New instance of Book class that has information</returns>
        private Book ReadBook(BinaryReader reader)
        {
            string isbn = reader.ReadString();
            string title = reader.ReadString();
            string author = reader.ReadString();
            string publisher = reader.ReadString();
            int year = reader.ReadInt32();
            int countPages = reader.ReadInt32();
            double price = reader.ReadDouble();
            return new Book(isbn, title, author, publisher, year, countPages, price);
        }

        /// <summary>
        /// Write the information of book using binary writer
        /// </summary>
        /// <param name="writer">Binary writer for writing</param>
        /// <param name="account">Instance of Book class</param>
        private void WriteBook(BinaryWriter writer, Book book)
        {
            writer.Write(book.Isbn);
            writer.Write(book.Title);
            writer.Write(book.Author);
            writer.Write(book.Publisher);
            writer.Write(book.Year);
            writer.Write(book.CountPages);
            writer.Write(book.Price);
        }
    }
}
