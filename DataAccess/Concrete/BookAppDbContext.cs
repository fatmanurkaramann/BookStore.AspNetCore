using DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class BookAppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public BookAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<DataAccess.Entities.Author> Authors { get; set; }
        public DbSet<DataAccess.Entities.Book> Books { get; set; }
        public DbSet<DataAccess.Entities.Category> Categories { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Address> Addresses { get; set; }



    }
}
