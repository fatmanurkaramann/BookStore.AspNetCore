using BookStore.AspNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.AspNetCore.AppDbContext
{
    public class BookStoreDbContext:DbContext
    {
        public BookStoreDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
