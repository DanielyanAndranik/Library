using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("OrderService")]
    public partial class OrderService
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int LibrarianId { get; set; }
        public string ServiceName { get; set; }

        public User Librarian { get; set; }
        public Order Order { get; set; }
    }
}
