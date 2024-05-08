using System.Linq.Expressions;

namespace MedicalRecord_API.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetEntity(Expression<Func<TEntity, bool>> filters, bool tracked = true);
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>>? filters = null);
        Task Delete(TEntity entity);
    }
}
