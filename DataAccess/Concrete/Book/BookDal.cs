using Core.DataAccess;
using DataAccess.Abstract.Book;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Book
{
    public class BookDal : Repository<Entities.Book, BookAppDbContext>, IBookDal
    {
        public BookDal(BookAppDbContext context) : base(context)
        {
        }

        public async Task<Entities.Book> NoTrackingGetById(int Id,bool tracking=true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
