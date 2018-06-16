using System;
using System.Collections.Generic;

namespace BooksApi.DataLayer
{
    public class Book
    {
        public string Guid { get; set; }

        public int ISBN { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public DateTime? PublishDate { get; set; }

        public string BookKindGuid { get; set; }

        public BookKind BookKind { get; set; }

        public Inventory Inventory { get; set; }

        public List<BookOrder> BookOrders { get; set; }
    }
}