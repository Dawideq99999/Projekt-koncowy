using Bookstore.Models;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class BookDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Administrator> Administrators { get; set; } // Nowe DbSet dla Administratorów

        public BookDbContext(DbContextOptions<BookDbContext> options)
            : base(options)
        {
        }
    }
}
