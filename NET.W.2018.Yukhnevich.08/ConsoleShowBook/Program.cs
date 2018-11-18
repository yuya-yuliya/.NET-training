using System;
using System.Collections.Generic;
using System.Linq;
using BookLibrary;
using BookLibrary.ReadWrite;
using ConsoleShowBook.Logging;

namespace ConsoleShowBook
{
    public class Program
    {
        private static ILogger logger;

        public static void Main(string[] args)
        {
            logger = new NLogger(typeof(Program).ToString());

            Book book1 = new Book("9785990257924", "Book", "Author", "Publisher", 2018, 20, 17),
                book2 = new Book("9785990257924", "Book", "Author", "Publisher", 2016, 20, 17),
                book3 = new Book("9785990257924", "Book", "Author", "Publisher", 2017, 20, 17);

            // Show equals
            Console.WriteLine("Is equals:");
            PrintBook(book1);
            Console.WriteLine("\n" + book1.Equals(book2) + "\n");
            PrintBook(book2);

            // Conmparing
            Console.WriteLine("\nCompare to:");
            PrintBook(book1);
            Console.WriteLine("\n" + book1.CompareTo(book3) + "\n");
            PrintBook(book3);

            // Get hash code
            Console.WriteLine("\nHash code:");
            PrintBook(book1);
            Console.WriteLine("\n" + book1.GetHashCode() + "\n");

            // Work with file
            if (args.Length >= 1)
            {
                // Read books from file
                ICollection<Book> books = ReadBookCollection(args[0]);
                Console.WriteLine("Collection from file: \n");
                PrintBookCollection(books);

                // Add book to colection
                Console.WriteLine("Add book:\n");
                book1.Title = "Book1";
                PrintBook(book1);
                AddBook(books, book1);
                Console.WriteLine("\nBook list: ");
                PrintBookCollection(books);

                // Find book by title in collection
                Console.WriteLine("Find book by title \"Book1\":\n");
                Book findBook = FindBookByTag(books, BookListService.Tag.Title, "Book1");
                if (findBook != null)
                {
                    PrintBook(findBook);
                }

                // Sorting by year
                Console.WriteLine("\nSort books by year:\n");
                PrintBookCollection(SortBooksByTag(books, BookListService.Tag.Year));

                // Remove book from collection
                Console.WriteLine("Remove book:\n");
                PrintBook(book1);
                RemoveBook(books, book1);
                Console.WriteLine("\nBook list: ");
                PrintBookCollection(books);

                // Save collection to file
                Console.WriteLine($"Save books to {args[0]}");
                if (SaveBookCollection(args[0], books))
                {
                    Console.WriteLine("Successfully saved");
                }
                else
                {
                    Console.WriteLine("Saving fails");
                }
            }
            else
            {
                Console.WriteLine("Enter file path");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Reads collection from file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private static ICollection<Book> ReadBookCollection(string filePath)
        {
            IBookReadWrite bookReadWrite = new BookBinaryReadWrite(filePath);
            ICollection<Book> booksCollection = new List<Book>();
            try
            {
                booksCollection = bookReadWrite.ReadCollection();
                logger.Info($"Book collection successfully readed from {filePath}");
            }
            catch (Exception ex)
            {
                logger.Warn($"Read book collection exceprion: {ex}");
            }

            return new BookListStorage(booksCollection);
        }

        /// <summary>
        /// Save collection to file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="books"></param>
        /// <returns></returns>
        private static bool SaveBookCollection(string filePath, ICollection<Book> books)
        {
            IBookReadWrite bookReadWrite = new BookBinaryReadWrite(filePath);
            try
            {
                bookReadWrite.WriteCollection(books);
                logger.Info("Successfully saved to file");
                return true;
            }
            catch (Exception ex)
            {
                logger.Warn($"Write book collection to file fails: {ex}");
                return false;
            }
        }

        /// <summary>
        /// Add book to collection
        /// </summary>
        /// <param name="books"></param>
        /// <param name="book"></param>
        private static void AddBook(ICollection<Book> books, Book book)
        {
            try
            {
                BookListService.AddBook(books, book);
                logger.Info($"Successfully add {book}");
            }
            catch (Exception ex)
            {
                logger.Warn($"Add book in collection exception: {ex}");
            }
        }

        /// <summary>
        /// Find book by some tag value
        /// </summary>
        /// <param name="books"></param>
        /// <param name="tag"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static Book FindBookByTag(ICollection<Book> books, BookListService.Tag tag, object value)
        {
            try
            {
                Book findBook = BookListService.FindBookByTag(books, BookListService.Tag.Title, value);
                if (findBook != null)
                {
                    logger.Info($"Succesfully find book by {tag} with value \"{value}\"");
                }
                else
                {
                    logger.Info($"Book collection doesn't contain book with tag {tag} value \"{value}\"");
                }

                return findBook;
            }
            catch (Exception ex)
            {
                logger.Warn($"Book finding exception: {ex}");
                return null;
            }
        }

        /// <summary>
        /// Sorting books by some tag
        /// </summary>
        /// <param name="books"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        private static ICollection<Book> SortBooksByTag(ICollection<Book> books, BookListService.Tag tag)
        {
            try
            {
                ICollection<Book> sortedBooks = BookListService.SortBooksByTag(books, BookListService.Tag.Year).ToList();
                logger.Info("Book collection successfully sorted");
                return sortedBooks;
            }
            catch (Exception ex)
            {
                logger.Warn($"Book collection sorting exception: {ex}");
                return null;
            }
        }

        /// <summary>
        /// Removes book from book collection
        /// </summary>
        /// <param name="books"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        private static bool RemoveBook(ICollection<Book> books, Book book)
        {
            try
            {
                if (BookListService.RemoveBook(books, book))
                {
                    logger.Info($"Successfully remove: {book}");
                    return true;
                }
                else
                {
                    logger.Info($"Remove failed: {book}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                logger.Warn($"Remove book exception: {ex}");
                return false;
            }
        }

        /// <summary>
        /// Print the book info to console
        /// </summary>
        /// <param name="book"></param>
        private static void PrintBook(Book book)
        {
            if (book != null)
            {
                Console.WriteLine(book.ToString());
            }
        }

        /// <summary>
        /// Print the book collection to console
        /// </summary>
        /// <param name="books"></param>
        private static void PrintBookCollection(ICollection<Book> books)
        {
            if (books != null)
            {
                foreach (Book book in books)
                {
                    Console.WriteLine(book.ToString());
                    Console.WriteLine();
                }
            }
        }
    }
}
