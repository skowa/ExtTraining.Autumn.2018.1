using System;

namespace StringExtension
{
    public static class Parser
    {
        public static int ToDecimal(this string source, int @base)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"{nameof(source)} is null");
            }

            if (@base > 16 || @base < 2)
            {
                throw new ArgumentOutOfRangeException($"{nameof(@base)} is out of range");
            }

            return ConvertToDecimal(source, @base);
        }

        private static int ConvertToDecimal(string source, int @base)
        {
            char[] numerals = source.ToCharArray();
            string numeralsValues = "0123456789ABCDEF";

            int result = 0;

            checked
            {
                for (int i = 0; i < numerals.Length; i++)
                {
                    int index = numeralsValues.IndexOf(numerals[i].ToString(), StringComparison.OrdinalIgnoreCase);
                    if (index >= @base || index == -1)
                    {
                        throw new ArgumentException($"{nameof(numerals)} is bad for {nameof(@base)}");
                    }

                    result += index * (int)Math.Pow(@base, numerals.Length - i - 1);
                }
            }
            
            return result;
        }
    }
}
