using System;
namespace RayhanASPRestTest.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string Full_name { get; set; }
        public string Phone_number { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

        public Driver()
        {
            Created_at = DateTime.Now;
            Updated_at = DateTime.Now;
        }
    }
}
