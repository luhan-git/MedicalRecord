using System.Linq.Expressions;

namespace MedicalRecord_API.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Create(T entity);
        Task Update(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>> filters, bool tracked = true);
        Task<IQueryable<T>> Query(Expression<Func<T, bool>>? filters = null);
        Task<IEnumerable<T>> QueryAsync(
        Expression<Func<T, bool>>? filter = null);
        Task Delete(T entity);
    }
}
