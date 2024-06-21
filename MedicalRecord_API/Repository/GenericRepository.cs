using MedicalRecord_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Linq.Expressions;

namespace MedicalRecord_API.Repository.Implements
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MedicalrecordContext _context;
        internal DbSet<T> dbSet;
        public GenericRepository(MedicalrecordContext context)
        {

            _context = context;
            this.dbSet = _context.Set<T>();

        }

        public async Task<T> Create(T entity)
        {
            await dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            dbSet.Remove(entity);
            await _context.SaveChangesAsync();

        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filters, bool tracked = true)
        {
            IQueryable<T> query = dbSet;
            if (!tracked) query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(filters);
        }

        public async Task<IQueryable<T>> Query(Expression<Func<T, bool>>? filters = null)
        {
            try
            {
                IQueryable<T> queryEntidad = filters == null ? dbSet : dbSet.Where(filters);
                return queryEntidad;
            }
            catch
            {

                throw;
            }
        }

        public async Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>>? filter = null,
                                               params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }

        public async  Task Update(T entity)
        {
            dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
