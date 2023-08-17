using Core.DataAccess;
using DataAccess.Abstract.Author;
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
    }
}
