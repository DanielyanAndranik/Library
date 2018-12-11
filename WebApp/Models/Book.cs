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
            OrderBook = new HashSet<OrderBook>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public DateTime? Published { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public bool? IsOccupational { get; set; }
        public string Image { get; set; }
        public byte TotalCount { get; set; }
        public byte AvailableCount { get; set; }
        public int? Rating { get; set; }

        public ICollection<OrderBook> OrderBook { get; set; }
    }
}
