using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("Order")]
    public partial class Order
    {
        public Order()
        {
            OrderBooks = new HashSet<OrderBook>();
            OrderServices = new HashSet<OrderService>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public User Customer { get; set; }
        public ICollection<OrderBook> OrderBooks { get; set; }
        public ICollection<OrderService> OrderServices { get; set; }
    }
}
