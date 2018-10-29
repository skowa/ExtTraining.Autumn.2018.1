using System;
using System.Globalization;
using BookLibrary;

namespace BookExtension
{
    //To add our format we should add class, which implements IFormatProvider and ICustomProvider. Here we can see the decorator pattern.
    public class BookFormatExtension : IFormatProvider, ICustomFormatter
    {
        private readonly IFormatProvider _parent;

        public BookFormatExtension() : this(CultureInfo.CurrentCulture) { }

        public BookFormatExtension(IFormatProvider parent) => _parent = parent;

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }

            return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null || format != "Q")
            {
                return string.Format(_parent, "{0:" + format + "}", arg); //returns string according to parent IFormatProvider.
            }

            Book book = arg as Book;

            return $"Book record: {book?.Author}, {book?.Title}, {book?.Year}, {book?.Price.ToString("C", _parent)}";
        }
    }
}
