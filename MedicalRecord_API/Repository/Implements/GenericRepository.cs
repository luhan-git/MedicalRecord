using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace MedicalRecord_API.Repository.Implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbhistoriasContext _context;
        internal DbSet<TEntity>dbSet;
        public GenericRepository(DbhistoriasContext context)
        {

            _context = context;
            this.dbSet = _context.Set<TEntity>();

        }

        public async Task Delete(TEntity entity)
        {
            dbSet.Remove(entity);
            await _context.SaveChangesAsync();

        }

        public async Task<TEntity> GetEntity(Expression<Func<TEntity, bool>> filters, bool tracked = true)
        {
            IQueryable<TEntity> query = dbSet;
            if (!tracked) query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(filters);
        }

        public async Task<List<TEntity>> QueryAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;
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
    }
}
