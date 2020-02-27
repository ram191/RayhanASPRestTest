using System;
namespace RayhanASPRestTest.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

        public OrderItem OrderItem { get; set; }

        public Product()
        {
            Created_at = DateTime.Now;
            Updated_at = DateTime.Now;
        }
    }
}
