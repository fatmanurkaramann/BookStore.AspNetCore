using Core.DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.Book
{
    public interface IBookDal:IRepository<Entities.Book> 
    {
    }
}
