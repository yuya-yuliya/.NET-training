using System;
using System.Collections.Generic;
using System.Linq;
using BookLibrary;
using BookLibrary.ReadWrite;

namespace ConsoleShowBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("9785990257924", "Book", "Author", "Publisher", 2018, 20, 17),
                book2 = new Book("9785990257924", "Book", "Author", "Publisher", 2016, 20, 17),
                book3 = new Book("9785990257924", "Book", "Author", "Publisher", 2017, 20, 17);

            //Show equals
            Console.WriteLine("Is equals:");
            PrintBook(book1);
            Console.WriteLine("\n" + book1.Equals(book2) + "\n");
            PrintBook(book2);

            //Conmparing
            Console.WriteLine("\nCompare to:");
            PrintBook(book1);
            Console.WriteLine("\n" + book1.CompareTo(book3) + "\n");
            PrintBook(book3);

            //Get hash code
            Console.WriteLine("\nHash code:");
            PrintBook(book1);
            Console.WriteLine("\n" + book1.GetHashCode() + "\n");

            //Work with file
            if (args.Length >= 1)
            {
                IBookReadWrite bookReadWrite = new BookBinaryReadWrite(args[0]);
                BookListStorage books;
                ICollection<Book> booksCollection = new List<Book>();
                //Read collection from file
                try
                {
                    booksCollection = bookReadWrite.ReadCollection();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                books = new BookListStorage(booksCollection);
                Console.WriteLine("Collection from file: \n");
                PrintBookCollection(books);

                //Add book to collection
                Console.WriteLine("Add book:\n");
                book1.Title = "Book1";
                PrintBook(book1);
                try
                {
                    BookListService.AddBook(books, book1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("\nBook list: ");
                PrintBookCollection(books);

                //Find book by title in collection
                Console.WriteLine("Find book by title \"Book1\":\n");
                try
                {
                    Book findBook = BookListService.FindBookByTag(books, BookListService.Tag.Title, "Book1");
                    PrintBook(findBook);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                //Sorting by year
                Console.WriteLine("\nSort books by year:\n");
                PrintBookCollection(BookListService.SortBooksByTag(books, BookListService.Tag.Year).ToList());

                //Remove book from collection
                Console.WriteLine("Remove book:\n");
                PrintBook(book1);
                try
                {
                    BookListService.RemoveBook(books, book1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("\nBook list: ");
                PrintBookCollection(books);

                //Save collection to file
                Console.WriteLine($"Save books to {args[0]}");
                bookReadWrite.WriteCollection(books);
            }
            else
            {
                Console.WriteLine("Enter file path");
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Print the book info to console
        /// </summary>
        /// <param name="book"></param>
        static void PrintBook(Book book)
        {
            Console.WriteLine(book.ToString());
        }

        /// <summary>
        /// Print the book collection to console
        /// </summary>
        /// <param name="books"></param>
        static void PrintBookCollection(ICollection<Book> books)
        {
            foreach (Book book in books)
            {
                Console.WriteLine(book.ToString());
                Console.WriteLine();
            }
        }
    }
}
