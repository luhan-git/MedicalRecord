using System.Linq.Expressions;

namespace MedicalRecord_API.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filters, bool tracked = true);
        Task<List<TEntity>> QueryAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        params Expression<Func<TEntity, object>>[] includes);
        Task Delete(TEntity entity);
    }
}
