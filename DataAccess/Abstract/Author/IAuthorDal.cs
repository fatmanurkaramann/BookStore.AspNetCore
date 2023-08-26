using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.Author
{
    public interface IAuthorDal:IRepository<Entities.Author>
    {
        Task<Entities.Author> NoTrackingGetById(int Id, bool tracking = true, bool includeData = true);
    }
}
