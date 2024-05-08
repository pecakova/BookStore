using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;
using static System.Reflection.Metadata.BlobBuilder;
using System.Reflection.Emit;

namespace BookStore.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext (DbContextOptions<BookStoreContext> options)
            : base(options)
        {
        }

        public DbSet<BookStore.Models.Author> Author { get; set; } = default!;
        public DbSet<BookStore.Models.BookGenre> BookGenre { get; set; } = default!;
        public DbSet<BookStore.Models.Genre> Genre { get; set; } = default!;
        public DbSet<BookStore.Models.Review> Review { get; set; } = default!;
        public DbSet<BookStore.Models.UserBooks> UserBooks { get; set; } = default!;
        public DbSet<BookStore.Models.Book> Book { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Configure one-to-many relationship between Author and Book
            builder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);

            builder.Entity<BookGenre>()
                .HasKey(bg => new { bg.BookId, bg.GenreId });

            builder.Entity<BookGenre>()
            .HasOne(bg => bg.Book)
            .WithMany(b => b.Genre)
            .HasForeignKey(bg => bg.BookId);

            builder.Entity<BookGenre>()
            .HasOne(bg => bg.Genre)
            .WithMany(g => g.Book)
            .HasForeignKey(bg => bg.GenreId);

            builder.Entity<Review>()
            .HasOne(r => r.Book)
            .WithMany(b => b.Review)
            .HasForeignKey(r => r.BookId);

            builder.Entity<UserBooks>()
            .HasOne<Book>(ub => ub.Book)
            .WithMany(b => b.UserBooks)
            .HasForeignKey(ub => ub.BookId);

        }
    }
}
