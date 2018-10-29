using System;
using System.Collections;
using System.Globalization;
using BookLibrary;
using NUnit.Framework;

namespace BookExtension.Tests
{
    [TestFixture]
    public class BookFormatExtensionTests
    {
        [TestCaseSource(typeof(DataForToStringTests))]
        public string ExtensionToStringTests_Book(string format, Book book)
            => string.Format(new BookFormatExtension(), "{0:" + format +"}", book);

        [TestCaseSource(typeof(DataForToStringWithProviderTests))]
        public string ExtensionToStringTestsWithFormatProvider_Book(string format, Book book, IFormatProvider provider)
            => string.Format(new BookFormatExtension(provider), "{0:" + format + "}", book);
    }

    internal class DataForToStringTests : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            Book book = new Book("C# in Depth", "Jon Skeet", 2019, "Manning", 4, 900, 40);
            yield return new TestCaseData("Q", book).Returns($"Book record: Jon Skeet, C# in Depth, 2019, {book.Price.ToString("C", CultureInfo.CurrentCulture)}");
            yield return new TestCaseData("A", book).Returns("Book record: Jon Skeet, C# in Depth");
            yield return new TestCaseData("A", null).Returns("");
        }
    }

    internal class DataForToStringWithProviderTests : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            Book book = new Book("C# in Depth", "Jon Skeet", 2019, "Manning", 4, 900, 40);
            yield return new TestCaseData("Q", book, CultureInfo.GetCultureInfo("en-US")).Returns($"Book record: Jon Skeet, C# in Depth, 2019, $40.00");
        }
    }
}
