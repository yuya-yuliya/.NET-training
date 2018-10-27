using System.Collections.Generic;
using System.IO;

namespace BookLibrary.ReadWrite
{
    public class BookBinaryReadWrite : IBookReadWrite
    {
        public readonly string Path;
        
        public BookBinaryReadWrite(string path)
        {
            Path = path;
        }

        public Book ReadBook()
        {
            using (BinaryReader reader = new BinaryReader(File.OpenRead(Path)))
            {
                return ReadBook(reader);
            }
        }

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

        public void WriteBook(Book book)
        {
            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(Path)))
            {
                WriteBook(writer, book);
            }
        }

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
