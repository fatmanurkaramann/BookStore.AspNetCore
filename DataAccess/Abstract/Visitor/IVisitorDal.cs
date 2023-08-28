using Core.DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.Visitor
{
    public interface IVisitorDal:IRepository<Entities.AppUser>
    {
    }
}
