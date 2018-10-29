using System;
using System.Globalization;

namespace BookLibrary
{
    /// <summary>
    /// This is a book class.
    /// </summary>
    public class Book : IFormattable
    {
        /// <summary>
        /// Initializes a new instance of book.
        /// </summary>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <param name="author">
        /// The author.
        /// </param>
        /// <param name="year">
        /// The publishing year.
        /// </param>
        /// <param name="publishingHouse">
        /// The publishing house.
        /// </param>
        /// <param name="edition">
        /// The edition.
        /// </param>
        /// <param name="pages">
        /// The number of pages.
        /// </param>
        /// <param name="price">
        /// The price.
        /// </param>
        public Book(string title, string author, int year, string publishingHouse, int edition, int pages, double price)
        {
            Title = title;
            Author = author;
            Year = year;
            PublishingHouse = publishingHouse;
            Edition = edition;
            Pages = pages;
            Price = price;
        }

        /// <summary>
        /// Gets title.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets author.
        /// </summary>
        public string Author { get; }

        /// <summary>
        /// Gets year.
        /// </summary>
        public int Year { get; }

        /// <summary>
        /// Gets publishing house.
        /// </summary>
        public string PublishingHouse { get; }

        /// <summary>
        /// Gets edition.
        /// </summary>
        public int Edition { get; }

        /// <summary>
        /// Gets pages.
        /// </summary>
        public int Pages { get; }

        /// <summary>
        /// Gets the price.
        /// </summary>
        public double Price { get; }

        /// <summary>
        /// Gets the instance of a book as a string.
        /// </summary>
        /// <returns>
        /// The instance of a book as a string.
        /// </returns>
        public override string ToString()
        {
            return ToString("G", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Gets the instance of a book as a string in special format.
        /// </summary>
        /// <param name="format">
        /// The format in which the instance of a book is represented.
        /// </param>
        /// <returns>
        /// The instance of a book as a string in special <paramref name="format"/>.
        /// </returns>
        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Gets the instance of a book as a string in special format according to special culture.
        /// </summary>
        /// <param name="format">
        /// The format in which the instance of a book is represented. G is an overrided ToString().
        /// </param>
        /// <param name="formatProvider">
        /// The format according to which some objects are formatted.
        /// </param>
        /// <returns>
        /// The instance of a book as a string in special <paramref name="format"/> and <paramref name="formatProvider"/>.
        /// </returns>
        /// <exception cref="FormatException">
        /// Thrown when <paramref name="format"/> is wrong.
        /// </exception>
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
                    return $"Book record: {Author}, {Title}, {Year}, {PublishingHouse}, {Edition}, {Pages}, {Price.ToString("C", formatProvider)}";
                case "P":
                    return $"Book record: {Author}, {Title}, {Year}, {PublishingHouse}";
                case "Y":
                    return $"Book record: {Author}, {Title}, {Year}";
                case "A":
                    return $"Book record: {Author}, {Title}";
                case "T":
                    return $"Book record: {Title}";
                case "H":
                    return $"Book record: {Title}, {Year}, {PublishingHouse}";
                case "M":
                    return $"Book record: {Title}, {Price.ToString("C", formatProvider)}";
                case "E":
                    return $"Book record: {Author}, {Title}, {Edition}, {Pages}";
                default: 
                    throw new FormatException($"{nameof(format)} is not supported.");
            }
        }
    }
}
