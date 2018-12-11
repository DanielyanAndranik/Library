using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("User")]
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
            OrderService = new HashSet<OrderService>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public string Role { get; set; }
        public bool Approved { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<OrderService> OrderService { get; set; }
    }
}
