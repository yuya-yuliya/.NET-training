using System;
using System.Globalization;
using BookLibrary;
using NUnit.Framework;

namespace BookFormatExtensionLibrary.Tests
{
    [TestFixture]
    public class BookFormatExtensionTests
    {
        public Book book = new Book("978-0-3408-3617-0", "The Dark Tower", "Stephen King", "Hodder & Stoughton", 2004, 740, 20);

        [TestCase(ExpectedResult = "ISBN: 978-0-3408-3617-0, Title: The Dark Tower, Author: Stephen King, Year: 2004, Price: $20")]
        public string ToShopFormatString_AddInnerFormatProvider_ValidResult() =>
            string.Format(new BookFormatExtension(CultureInfo.GetCultureInfo("en-US")), "{0:SH}", book);

        [TestCase(ExpectedResult = "ISBN: 978-0-3408-3617-0, Title: The Dark Tower, Author: Stephen King, Year: 2004, Price: 20 ₽")]
        public string ToShopFormatString_ValidResult() =>
            string.Format(new BookFormatExtension(), "{0:SH}", book);

        [TestCase(ExpectedResult = "Title: The Dark Tower, Author: Stephen King, Year: 2004, Count pages: 740")]
        public string ToFormatString_OldFormat_ValidResult() =>
            string.Format(new BookFormatExtension(), "{0:S}", book);
    }
}
