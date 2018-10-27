using System;
using System.Text.RegularExpressions;

namespace BookLibrary
{
    public class Book : IComparable<Book>, IEquatable<Book>
    {
        #region fields&Properties

        private string isbn;
        private int year;
        private int countPages;
        private double price;

        public string Author { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }

        public int Year
        {
            get => year;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Year must be positive number");
                }
                year = value;
            }
        }

        public int CountPages
        {
            get => countPages;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Count pages must be positive number");
                }
                countPages = value;
            }
        }

        public double Price
        {
            get => price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price must be positive number");
                }
                price = value;
            }
        }

        public string Isbn
        {
            get => isbn;
            set
            {
                if (!IsbnIsValid(value))
                {
                    throw new ArgumentException("Isbn string is invalid");
                }
                isbn = value;
            }
        }

        #endregion fields&Properties

        #region constructors

        private Book()
        {
            isbn = "";
            Title = "";
            Author = "";
            Publisher = "";
        }

        public Book(string isbn, string title, string author, string publisher, int year, int countPages, double price)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            Publisher = publisher;
            Year = year;
            CountPages = countPages;
            Price = price;
        }

        #endregion constructors

        #region publicMethods

        public int CompareTo(Book book)
        {
            if (book == null)
            {
                return 1;
            }
            if (Equals(book))
            {
                return 0;
            }

            return CompareFields(book);
        }


        public bool Equals(Book other)
        {
            return Equals((object)other);
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            Book book = (Book)obj;
            return isbn.Equals(book.isbn) && 
                year == book.year && 
                countPages == book.countPages && 
                price == book.price && 
                Author.Equals(book.Author) && 
                Title.Equals(book.Title) && 
                Publisher.Equals(book.Publisher);
        }

        public override int GetHashCode()
        {
            string[] stringFields = { isbn, Author, Title, Publisher };
            int[] valueFields = { year, countPages, (int)price };
            int hash = 1;
            int hashBase = 31;

            unchecked
            {
                foreach (string str in stringFields)
                {
                    int stringHash = 0;
                    for (int i = 0; i < str.Length; i++)
                    {
                        stringHash += str[i];
                    }
                    hash = hashBase * hash + stringHash;
                }

                foreach (int value in valueFields)
                {
                    hash = hashBase * hash + value;
                }
            }

            return hash;
        }

        public override string ToString()
        {
            return $"Title: {Title}\n" +
                $"Author: {Author}\n" +
                $"Publisher: {Publisher}\n" +
                $"ISBN: {isbn}\nYear: {year}\n" +
                $"Count pages: {countPages}\n" +
                $"Price: {price}";
        }

        #endregion publicMethods

        #region privateMethods

        private bool IsbnIsValid(string isbnString)
        {
            const int IsbnLength = 13;

            if (isbnString == null)
            {
                throw new ArgumentNullException();
            }
            if (!Regex.IsMatch(isbnString, $"^\\d{{{IsbnLength}}}$"))
            {
                return false;
            }

            int[] coefficient = { 1, 3 };
            int sum = 0;
            for (int i = 0; i < IsbnLength; i++)
            {
                sum += (Convert.ToInt32(isbnString[i]) * coefficient[i % 2]);
            }
            return sum % 10 == 0;
        }

        private int CompareFields(Book book)
        {
            int compareResult = 0;
            return (compareResult = isbn.CompareTo(book.isbn)) != 0 ? compareResult :
                (compareResult = Title.CompareTo(book.Title)) != 0 ? compareResult :
                (compareResult = Author.CompareTo(book.Author)) != 0 ? compareResult :
                (compareResult = Publisher.CompareTo(book.Publisher)) != 0 ? compareResult :
                (compareResult = year.CompareTo(book.year)) != 0 ? compareResult :
                (compareResult = countPages.CompareTo(book.countPages)) != 0 ? compareResult :
                countPages.CompareTo(book.countPages);
        }

        #endregion privateMethods
    }
}
