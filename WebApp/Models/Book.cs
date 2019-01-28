using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("Book")]
    public partial class Book
    {
        public Book()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public DateTime? Published { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public string Type { get; set; }
        public byte[] Image { get; set; }
        public byte TotalCount { get; set; }
        public byte AvailableCount { get; set; }
        public int? Rating { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
