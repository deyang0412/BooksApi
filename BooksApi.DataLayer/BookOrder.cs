namespace BooksApi.DataLayer
{
    public class BookOrder
    {
        public string BookGuid { get; set; }

        public string OrderGuid { get; set; }

        public Book Book { get; set; }

        public Order Order { get; set; }
    }
}