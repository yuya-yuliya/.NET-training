using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BookLibrary
{
    /// <summary>
    /// Class represents a book
    /// </summary>
    public class Book : IComparable<Book>, IEquatable<Book>, IFormattable
    {
        #region fields

        private string _isbn;
        private int _year;
        private int _countPages;
        private double _price;

        #endregion fields

        #region constructors
        /// <summary>
        /// Initialize new instance of Book class with needed information
        /// </summary>
        /// <param name="isbn">The book ISBN number</param>
        /// <param name="title">The book title</param>
        /// <param name="author">The book author</param>
        /// <param name="publisher">Publisher of the book</param>
        /// <param name="year">The book publishing year</param>
        /// <param name="countPages">The book count of page</param>
        /// <param name="price">The book price</param>
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

        #region properties
        /// <summary>
        /// The book author
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// The book title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The book publisher
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// The book publishing year
        /// </summary>
        public int Year
        {
            get => _year;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Year must be positive number");
                }

                _year = value;
            }
        }

        /// <summary>
        /// The book count of page
        /// </summary>
        public int CountPages
        {
            get => _countPages;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Count pages must be positive number");
                }

                _countPages = value;
            }
        }

        /// <summary>
        /// The book price
        /// </summary>
        public double Price
        {
            get => _price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price must be positive number");
                }

                _price = value;
            }
        }

        /// <summary>
        /// The book ISBN
        /// </summary>
        public string Isbn
        {
            get => _isbn;
            set
            {
                if (!IsbnIsValid(value))
                {
                    throw new ArgumentException("Isbn string is invalid");
                }

                _isbn = value;
            }
        }

        #endregion roperties

        #region publicMethods
        /// <summary>
        /// Compares current instance with another instance of Book class
        /// </summary>
        /// <param name="book">The instance of Book class</param>
        /// <returns>Zero if equals, positive if current greater, negative otherwise</returns>
        public int CompareTo(Book book)
        {
            if (book == null)
            {
                return 1;
            }

            if (this.Equals(book))
            {
                return 0;
            }

            return CompareFields(book);
        }

        /// <summary>
        /// Determines whether current instance is equal to other instance of Book class
        /// </summary>
        /// <param name="other">Other instance of Book class</param>
        /// <returns>True if the other instance of Book class is equal to the current instance; otherwise, false</returns>
        public bool Equals(Book other)
        {
            return this.Equals((object)other);
        }

        /// <summary>
        /// Determines whether current instance is equal to other object
        /// </summary>
        /// <param name="other">Other object</param>
        /// <returns>True if the specified object is equal to the current object; otherwise, false</returns>
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
            return _isbn.Equals(book._isbn) && 
                _year == book._year && 
                _countPages == book._countPages && 
                _price == book._price && 
                Author.Equals(book.Author) && 
                Title.Equals(book.Title) && 
                Publisher.Equals(book.Publisher);
        }

        /// <summary>
        /// Get hash code of current object
        /// </summary>
        /// <returns>The hash code</returns>
        public override int GetHashCode()
        {
            string[] stringFields = { _isbn, Author, Title, Publisher };
            int[] valueFields = { _year, _countPages, (int)_price };
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
                    
                    hash = (hashBase * hash) + stringHash;
                }

                foreach (int value in valueFields)
                {
                    hash = (hashBase * hash) + value;
                }
            }

            return hash;
        }

        /// <summary>
        /// Get string presentation of information of current object using format string
        /// </summary>
        /// <param name="format">Format string</param>
        /// <returns>The string presentation of current object</returns>
        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Get string presentation of information of current object using format string and format provider
        /// </summary>
        /// <param name="format">Format string</param>
        /// <param name="formatProvider">Instance of class implements IFormatProvider interface</param>
        /// <returns>The string presentation of current object</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "G";
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            switch (format.ToUpperInvariant())
            {
                case "G":
                case "F":
                    return string.Format(formatProvider, "Title: {0}, Author: {1}, Publisher: {2}, ISBN: {3}, Year: {4}, Count pages: {5}, Price: {6:C0}", Title, Author, Publisher, Isbn, Year, CountPages, Price);
                case "C":
                    return string.Format(formatProvider, "Title: {0}, Author: {1}", Title, Author);
                case "P":
                    return string.Format(formatProvider, "Title: {0}, Author: {1}, Publisher: {2}, Year: {3}", Title, Author, Publisher, Year);
                case "S":
                    return string.Format(formatProvider, "Title: {0}, Author: {1}, Year: {2}, Count pages: {3}", Title, Author, Year, CountPages);
                default:
                    throw new FormatException($"The {format} format string is not supported.");
            }
        }

        /// <summary>
        /// Get string presentation of information of current object 
        /// </summary>
        /// <returns>The string presentation of current object</returns>
        public override string ToString()
        {
            return ToString("G", CultureInfo.CurrentCulture);
        }

        #endregion publicMethods

        #region privateMethods
        /// <summary>
        /// Check the validation of ISBN string
        /// </summary>
        /// <param name="isbnString">ISBN string</param>
        /// <returns>True if the ISBN string is valid, otherwise false</returns>
        private bool IsbnIsValid(string isbnString)
        {
            const int IsbnLength = 13;

            if (isbnString == null)
            {
                throw new ArgumentNullException();
            }

            isbnString = isbnString.Replace("-", string.Empty);

            if (!Regex.IsMatch(isbnString, $"^\\d{{{IsbnLength}}}$"))
            {
                return false;
            }

            int[] coefficient = { 1, 3 };
            int sum = 0;
            for (int i = 0; i < IsbnLength; i++)
            {
                sum += Convert.ToInt32(isbnString[i]) * coefficient[i % 2];
            }

            return sum % 10 == 0;
        }

        /// <summary>
        /// Compares fields of current object and other instance of Book class
        /// </summary>
        /// <param name="book">Other instance of Book class</param>
        /// <returns>Zero if equals, positive if current greater, negative otherwise</returns>
        private int CompareFields(Book book)
        {
            int compareResult = 0;
            return (compareResult = _isbn.CompareTo(book._isbn)) != 0 ? compareResult :
                (compareResult = Title.CompareTo(book.Title)) != 0 ? compareResult :
                (compareResult = Author.CompareTo(book.Author)) != 0 ? compareResult :
                (compareResult = Publisher.CompareTo(book.Publisher)) != 0 ? compareResult :
                (compareResult = _year.CompareTo(book._year)) != 0 ? compareResult :
                (compareResult = _countPages.CompareTo(book._countPages)) != 0 ? compareResult :
                _countPages.CompareTo(book._countPages);
        }

        #endregion privateMethods
    }
}
