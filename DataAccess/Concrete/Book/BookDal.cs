using Core.DataAccess;
using DataAccess.Abstract.Book;
using DataAccess.Entities;
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
    }
}
