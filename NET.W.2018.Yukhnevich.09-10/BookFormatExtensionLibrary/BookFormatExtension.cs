using System;
using System.Globalization;
using BookLibrary;

namespace BookFormatExtensionLibrary
{
    /// <summary>
    /// Provides format method for Book class to get formatting string in shop format not available in standard ToString
    /// </summary>
    public class BookFormatExtension : ICustomFormatter, IFormatProvider
    {
        public BookFormatExtension() : this(null)
        {
        }

        public BookFormatExtension(IFormatProvider formatProvider)
        {
            if (formatProvider == null)
            {
                InnerFormatProvider = CultureInfo.CurrentCulture;
            }
            else
            {
                InnerFormatProvider = formatProvider;
            }
        }

        public IFormatProvider InnerFormatProvider { get; private set; }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            if (arg.GetType() != typeof(Book))
            {
                try
                {
                    return HandleOtherFormats(format, arg, formatProvider);
                }
                catch (FormatException ex)
                {
                    throw new FormatException($"The {format} format string is not supported.", ex);
                }
            }

            Book book = (Book)arg;
            if (format.ToUpper() == "SH")
            {
                return $"ISBN: {book.Isbn}, " +
                    $"Title: {book.Title}, " +
                    $"Author: {book.Author}, " +
                    $"Year: {book.Year}, " +
                    $"Price: {book.Price.ToString("C0", InnerFormatProvider)}";
            }
            else
            {
                try
                {
                    return HandleOtherFormats(format, arg, formatProvider);
                }
                catch (FormatException ex)
                {
                    throw new FormatException($"The {format} format string is not supported.", ex);
                }
            }
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else
            {
                return null;
            }
        }

        private string HandleOtherFormats(string format, object arg, IFormatProvider formatProvider)
        {
            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            if (arg is IFormattable)
            {
                return ((IFormattable)arg).ToString(format, formatProvider);
            }
            else if (arg != null)
            {
                return arg.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
