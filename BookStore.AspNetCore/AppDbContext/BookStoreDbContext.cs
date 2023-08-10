using BookStore.AspNetCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.AspNetCore.AppDbContext
{
    public class BookStoreDbContext:IdentityDbContext<AppUser,AppRole,int>
    {
        //DbContextOptions nesnesi, veritabanı bağlantısının ve yapılandırmasının nasıl
        //oluşturulacağını belirleyen ayarları içerir. Bu nedenle, BookStoreDbContext ctor u
        //bu seçenekleri alarak veritabanı bağlantısının nasıl yapılandırılacağını belirtir.
        public BookStoreDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

    }
}
