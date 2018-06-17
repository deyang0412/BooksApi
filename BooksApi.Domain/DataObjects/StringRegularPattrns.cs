using System;

namespace BooksApi.Domain.DataObjects
{
    public class StringRegularPattrns
    {
        public const string OnlyChineseAndEnglish = "^[\u4e00-\u9fa5_a-zA-Z0-9]+$";
    }
}