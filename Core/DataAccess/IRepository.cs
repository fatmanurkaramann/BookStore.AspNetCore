using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IRepository<T> where T : class
    {
        Task<int> AddAsync(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(int Id);
        IQueryable<T> GetAll(bool tracking=true);
        Task<T> GetByIdAsync(int id,bool tracking=true);
    }
}
