using System;
using System.Collections.Generic;

namespace ShopEase.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string CustomerName { get; set; }

        public DateTime OrderDate { get; set; }

        public List<CartItem> Items { get; set; }

        public decimal Total { get; set; }

        public decimal GST { get; set; }

        public decimal Discount { get; set; }

        public decimal GrandTotal { get; set; }
    }
}