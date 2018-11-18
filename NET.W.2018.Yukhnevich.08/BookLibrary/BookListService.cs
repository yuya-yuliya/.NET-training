using BookLibrary.Finders;
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
                throw new ArgumentException($"Collection is already contains {book}");
            }
           
            books.Add(book);
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
                throw new ArgumentException($"Collection doesn't contain {book}");
            }

            return books.Remove(book);
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
            catch (KeyNotFoundException ex)
            {
                throw new ArgumentException($"{nameof(tag)} is invalid", ex);
            }
            catch (InvalidCastException ex)
            {
                throw new ArgumentException($"{nameof(value)} has invalid tipe for current tag type", ex);
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
            catch (KeyNotFoundException ex)
            {
                throw new ArithmeticException($"{nameof(tag)} is invalid", ex);
            }
        }
    }
}
