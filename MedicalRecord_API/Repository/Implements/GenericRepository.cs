using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedicalRecord_API.Repository.Implements
{
    public class GenericRepositoty<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbhistoriasContext _context;
        internal DbSet<TEntity>dbSet;
        public GenericRepositoty(DbhistoriasContext context)
        {

            _context = context;
            this.dbSet = _context.Set<TEntity>();

        }
        public async Task Create(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
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

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>>? filters = null)
        {
            IQueryable<TEntity> query = filters == null ? dbSet : dbSet.Where(filters);
            return await query.ToListAsync();

        }
    }
}
