using System;
using System.Collections.Generic;

namespace RayhanASPRestTest.Models
{
    public enum Order_status { Created, Accepted, Sending, Done, Failure };

    public class Order
    {
        public int Id { get; set; }
        public int User_id  { get; set; }
        public Order_status Status { get; set; }
        public int Driver_id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public List<OrderItem> Order_detail { get; set; }

        public Order()
        {
            Status = Order_status.Created;
            Created_at = DateTime.Now;
            Updated_at = DateTime.Now;
        }

        public Customer Customer { get; set; }
        public Driver Driver { get; set; }
    }
}
