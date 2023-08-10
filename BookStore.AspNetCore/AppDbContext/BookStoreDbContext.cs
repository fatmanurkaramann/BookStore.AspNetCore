using BookStore.AspNetCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.AspNetCore.AppDbContext
{
    public class BookStoreDbContext:IdentityDbContext<AppUser,AppRole,int>
    {
        public BookStoreDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

    }
}
