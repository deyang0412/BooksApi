using System;

namespace BooksApi.DataLayer
{
    public class Inventory
    {
        public string Guid { get; set; }

        public string BookGuid { get; set; }

        public Book Book { get; set; }

        public DateTime? ReplenishDate { get; set; }

        public int Quantity { get; set; }
    }
}