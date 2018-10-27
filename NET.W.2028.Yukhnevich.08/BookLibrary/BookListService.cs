using BookLibrary.Finders;
using BookLibrary.Sort;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookLibrary
{
    public class BookListService
    {
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

        public static void AddBook(ICollection<Book> books, Book book)
        {
            if (books.Contains(book))
            {
                throw new ArgumentException($"Collection is already contains {book}");
            }
            books.Add(book);
        }

        public static bool RemoveBook(ICollection<Book> books, Book book)
        {
            if (!books.Contains(book))
            {
                throw new ArgumentException($"Collection doesn't contain {book}");
            }
            return books.Remove(book);
        }

        public static Book FindBookByTag(ICollection<Book> books, Tag tag, object value)
        {
            Dictionary<Tag, IBookFinder> findDict = new Dictionary<Tag, IBookFinder>
            {
                [Tag.Author] = (IBookFinder)new ByAuthorFinder(),
                [Tag.CountPages] = (IBookFinder)new ByCountPagesFinder(),
                [Tag.Isbn] = (IBookFinder)new ByIsbnFinder(),
                [Tag.Price] = (IBookFinder)new ByPriceFinder(),
                [Tag.Publisher] = (IBookFinder)new ByPublisherFinder(),
                [Tag.Title] = (IBookFinder)new ByTitleFinder(),
                [Tag.Year] = (IBookFinder)new ByYearFinder()
            };
            return findDict[tag].Find(books, value);
        }

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
            return findDict[tag].Sort(books);
        }
    }
}
