using System;
using System.Collections;
using System.Globalization;
using NUnit.Framework;

namespace BookLibrary.Tests
{
    [TestFixture]
    public class BookTests
    {
        [TestCaseSource(typeof(DataForToStringTests))]
        public string ToStringTests_Book(Book book)
            => book.ToString();

        [TestCaseSource(typeof(DataForToStringIFormattableTests))]
        public string ToStringIFormattableTests_BookAndFormat(Book book, string format)
            => book.ToString(format);

        [TestCaseSource(typeof(DataForToStringIFormattableWithCultureTests))]
        public string ToStringIFormattableTests_BookAndFormat(Book book, string format, IFormatProvider provider)
            => book.ToString(format, provider);

        [Test]
        public void ToStringTests_WrongFormat_ThrowsFormatException()
            => Assert.Throws<FormatException>(() =>
                new Book("C# in Depth", "Jon Skeet", 2019, "Manning", 4, 900, 40).ToString("N"));
    }

    internal class DataForToStringTests : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new TestCaseData(new Book("C# in Depth", "Jon Skeet", 2019, "Manning", 4, 900, 40)).Returns($"Book record: Jon Skeet, C# in Depth, 2019, Manning, 4, 900, {40.ToString("C", CultureInfo.CurrentCulture)}");
        }
    }

    internal class DataForToStringIFormattableTests : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            Book book = new Book("C# in Depth", "Jon Skeet", 2019, "Manning", 4, 900, 40);

            yield return new TestCaseData(book, "P").Returns("Book record: Jon Skeet, C# in Depth, 2019, Manning");
            yield return new TestCaseData(book, "Y").Returns("Book record: Jon Skeet, C# in Depth, 2019");
            yield return new TestCaseData(book, "A").Returns("Book record: Jon Skeet, C# in Depth");
            yield return new TestCaseData(book, "P").Returns("Book record: Jon Skeet, C# in Depth, 2019, Manning");
            yield return new TestCaseData(book, "T").Returns("Book record: C# in Depth");
            yield return new TestCaseData(book, "H").Returns("Book record: C# in Depth, 2019, Manning");
            yield return new TestCaseData(book, "M").Returns($"Book record: C# in Depth, {book.Price.ToString("C", CultureInfo.CurrentCulture)}");
            yield return new TestCaseData(book, "E").Returns("Book record: Jon Skeet, C# in Depth, 4, 900");
        }
    }

    internal class DataForToStringIFormattableWithCultureTests : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            Book book = new Book("C# in Depth", "Jon Skeet", 2019, "Manning", 4, 900, 40);

            yield return new TestCaseData(book, "G", CultureInfo.GetCultureInfo("en-US")).Returns("Book record: Jon Skeet, C# in Depth, 2019, Manning, 4, 900, $40.00");
            yield return new TestCaseData(book, "Y", CultureInfo.GetCultureInfo("en-US")).Returns("Book record: Jon Skeet, C# in Depth, 2019");
            yield return new TestCaseData(book, "M", CultureInfo.GetCultureInfo("en-US")).Returns("Book record: C# in Depth, $40.00");
        }
    }
}
