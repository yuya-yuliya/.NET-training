using BookLibrary.Finders;
using BookLibrary.Logging;
using BookLibrary.Sort;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookLibrary
{
    /// <summary>
    /// Provides the methods to work with collection of Book class instances
    /// </summary>
    public class BookListService
    {
        private static ILogger logger;

        static BookListService()
        {
            logger = new NLogger(typeof(BookListService).ToString());
        }

        /// <summary>
        /// Enumeration of tag types
        /// </summary>
        public enum Tag
        {
            Isbn,
            Title,
            Author,
            Publisher,
            Year,
            CountPages,
            Price
        }

        /// <summary>
        /// Adds book in the collection of instances of Book class, if the collection doesn't contains this object
        /// </summary>
        /// <param name="books">The collection of Book class instances</param>
        /// <param name="book">The Book class instance for adding</param>
        /// <exception cref="ArgumentException">Collection is already contains the current Book class instance</exception>
        public static void AddBook(ICollection<Book> books, Book book)
        {
            if (books.Contains(book))
            {
                logger.Warn($"Try to add the exsisting book: {book}");
                throw new ArgumentException($"Collection is already contains {book}");
            }
           
            books.Add(book);
            logger.Info($"Successfully add {book}");
        }

        /// <summary>
        /// Removes book form the collection of instances of Book class, if
        /// </summary>
        /// <param name="books">The collection of Book class instances</param>
        /// <param name="book">The Book class instance for removing</param>
        /// <returns>True if removing was successful, otherwise false</returns>
        /// <exception cref="ArgumentException">Collection doesn't contain the current Book class instance</exception>
        public static bool RemoveBook(ICollection<Book> books, Book book)
        {
            if (!books.Contains(book))
            {
                logger.Warn($"Try to remove the non-existing book: {book}");
                throw new ArgumentException($"Collection doesn't contain {book}");
            }
            if (books.Remove(book))
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

        /// <summary>
        /// Finds book in books collection by tag
        /// </summary>
        /// <param name="books">The collection of Book class instances</param>
        /// <param name="tag">Type of tag for finding</param>
        /// <param name="value">Finging value of tag</param>
        /// <returns>Matching instance of Book class, if finding success; otherwise null</returns>
        public static Book FindBookByTag(ICollection<Book> books, Tag tag, object value)
        {
            Dictionary<Tag, IBookFinder> findDict = new Dictionary<Tag, IBookFinder>
            {
                [Tag.Author] = new ByAuthorFinder(),
                [Tag.CountPages] = new ByCountPagesFinder(),
                [Tag.Isbn] = new ByIsbnFinder(),
                [Tag.Price] = new ByPriceFinder(),
                [Tag.Publisher] = new ByPublisherFinder(),
                [Tag.Title] = new ByTitleFinder(),
                [Tag.Year] = new ByYearFinder()
            };
            try
            {
                return findDict[tag].Find(books, value);
            }
            catch (Exception ex)
            {
                logger.Error($"Find book by tag exception: {ex}\nArguments: {books}\n{tag}\n{value}");
                throw ex;
            }
        }

        /// <summary>
        /// Get ordered enumerable by tag from collection of Book class instances
        /// </summary>
        /// <param name="books">The collection of Book class instances</param>
        /// <param name="tag">The type of sorting tag</param>
        /// <returns>Ordered by tag enumerable of Book class instances</returns>
        public static IOrderedEnumerable<Book> SortBooksByTag(ICollection<Book> books, Tag tag)
        {
            Dictionary<Tag, IBookSorter> findDict = new Dictionary<Tag, IBookSorter>
            {
                [Tag.Author] = new ByAuthorSorter(),
                [Tag.CountPages] = new ByCountPagesSorter(),
                [Tag.Isbn] = new ByIsbnSorter(),
                [Tag.Price] = new ByPriceSorter(),
                [Tag.Publisher] = new ByPublisherSorter(),
                [Tag.Title] = new ByTitleSorter(),
                [Tag.Year] = new ByYearSorter()
            };
            try
            {
                return findDict[tag].Sort(books);
            }
            catch (Exception ex)
            {
                logger.Error($"Sort books by tag exception: {ex}\nArguments: {books}\n{tag}");
                throw ex;
            }
        }
    }
}
