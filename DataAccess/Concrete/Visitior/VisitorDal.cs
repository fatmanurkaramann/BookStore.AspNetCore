using Core.DataAccess;
using DataAccess.Abstract.Visitor;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Visitior
{
    public class VisitorDal : Repository<Entities.AppUser, BookAppDbContext>, IVisitorDal
    {
        public VisitorDal(BookAppDbContext context) : base(context)
        {
            
        }
    }
}
