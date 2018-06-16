using System.Collections.Generic;

namespace BooksApi.DataLayer
{
    public class User
    {
        public string Guid { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public List<Order> Orders { get; set; }
    }
}