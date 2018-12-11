using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApp.Models
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderBook> OrderBooks { get; set; }
        public virtual DbSet<OrderService> OrderServices { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Genre).HasMaxLength(128);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Published).HasColumnType("date");

                entity.Property(e => e.Publisher).HasMaxLength(128);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.ExpectedReturnDate).HasColumnType("date");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.ReturnDate).HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__CustomerI__2A164134");
            });

            modelBuilder.Entity<OrderBook>(entity =>
            {
                entity.HasOne(d => d.Book)
                    .WithMany(p => p.OrderBook)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderBook__BookI__1AD3FDA4");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderBooks)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderBook__Order__19DFD96B");
            });

            modelBuilder.Entity<OrderService>(entity =>
            {
                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.HasOne(d => d.Librarian)
                    .WithMany(p => p.OrderService)
                    .HasForeignKey(d => d.LibrarianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderServ__Libra__2B0A656D");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderServices)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderServ__Order__1BC821DD");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(320)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });
        }
    }
}
