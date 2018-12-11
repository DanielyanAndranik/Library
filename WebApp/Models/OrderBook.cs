using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("OrderBook")]
    public partial class OrderBook
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }

        public Book Book { get; set; }
        public Order Order { get; set; }
    }
}
