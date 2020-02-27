using System;
namespace RayhanASPRestTest.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int Order_id { get; set; }
        public Order Order { get; set; }

        public int Product_id { get; set; }
        public Product Product { get; set; }
    }
}
