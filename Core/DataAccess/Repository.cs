using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public class Repository<T,TContext> : IRepository<T> where T : class where TContext : DbContext
    {
        protected readonly TContext _context;

        public Repository(TContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();
        public async Task<int> AddAsync(T entity)
        {
            Table.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public Task<int> Delete(int Id)
        {
            var entity = Table.Find(Id);
            Table.Remove(entity);
            return _context.SaveChangesAsync();
        }

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }

        public async Task<T> GetByIdAsync(int id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await Table.FindAsync(id);
        }

        public async Task<int> Update(T entity)
        {
            Table.Update(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
