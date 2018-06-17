using System;

namespace BooksApi.Domain.Extensions
{
    public static class StringExtension
    {
        public static bool HasValue(this string s)
        {
            return !string.IsNullOrEmpty(s) && !string.IsNullOrWhiteSpace(s);
        }
    }
}