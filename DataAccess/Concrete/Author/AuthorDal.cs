using Core.DataAccess;
using DataAccess.Abstract.Author;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Author
{
    public class AuthorDal : Repository<Entities.Author, BookAppDbContext>, IAuthorDal
    {
        public AuthorDal(BookAppDbContext context) : base(context)
        {
        }

        public async Task<Entities.Author> NoTrackingGetById(int Id, bool tracking = true, bool includeData = true)
        {
            var query = Table.AsQueryable();
            if (!tracking || includeData)
            {
                query = query.AsNoTracking().Include(b => b.Books).Include(a => a.Universities).Include(c=>c.Universities);
            }

            return await query.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
