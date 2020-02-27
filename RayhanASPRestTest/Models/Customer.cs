using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RayhanASPRestTest.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Full_name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        [MaxLength(20)]
        public string Phone_number { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

        public Customer()
        {
            Created_at = DateTime.Now;
            Updated_at = DateTime.Now;
        }
    }
}
