using System;
using System.Collections.Generic;

namespace BooksApi.DataLayer
{
    public class Order
    {
        public string Guid { get; set; }

        public string OrderNo { get; set; }

        public string UserGuid { get; set; }

        public int Quantity { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? EstimateToDelivery { get; set; }

        public User User { get; set; }

        public List<BookOrder> BookOrders { get; set; }
    }
}