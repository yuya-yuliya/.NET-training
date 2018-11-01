using System;
using System.Globalization;
using NUnit.Framework;

namespace BookLibrary.Tests
{
    [TestFixture]
    public class BookTests
    {
        public Book book = new Book("978-0-3408-3617-0", "The Dark Tower", "Stephen King", "Hodder & Stoughton", 2004, 740, 20);

        [TestCase("G", ExpectedResult = "Title: The Dark Tower, Author: Stephen King, Publisher: Hodder & Stoughton, ISBN: 978-0-3408-3617-0, Year: 2004, Count pages: 740, Price: 20 ₽")]
        [TestCase("F", ExpectedResult = "Title: The Dark Tower, Author: Stephen King, Publisher: Hodder & Stoughton, ISBN: 978-0-3408-3617-0, Year: 2004, Count pages: 740, Price: 20 ₽")]
        [TestCase("C", ExpectedResult = "Title: The Dark Tower, Author: Stephen King")]
        [TestCase("P", ExpectedResult = "Title: The Dark Tower, Author: Stephen King, Publisher: Hodder & Stoughton, Year: 2004")]
        [TestCase("S", ExpectedResult = "Title: The Dark Tower, Author: Stephen King, Year: 2004, Count pages: 740")]
        public string ToString_ValidFormat_ValidResult(string format) =>
            book.ToString(format);

        [TestCase(ExpectedResult = "Title: The Dark Tower, Author: Stephen King, Publisher: Hodder & Stoughton, ISBN: 978-0-3408-3617-0, Year: 2004, Count pages: 740, Price: $20")]
        public string ToString_OtherCultureInfo_ValidResult() =>
            book.ToString("G", CultureInfo.GetCultureInfo("en-US"));

        [Test]
        public void ToString_WrongFormatString_ThrowsFormatException() =>
            Assert.Throws<FormatException>(() => book.ToString("A"));
    }
}
