using System.Collections.Generic;

namespace BooksApi.DataLayer
{
    public class BookKind
    {
        public int Guid { get; set; }

        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }
}