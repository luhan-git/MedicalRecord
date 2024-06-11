using MedicalRecord_API.Models;
using System.Linq.Expressions;

namespace MedicalRecord_API.Services.Interfaces
{
    public interface IPresentacionService
    {

        Task<Presentacion> GetAsync(Expression<Func<Presentacion, bool>> filters, bool tracked = true);
        Task<List<Presentacion>> QueryAsync(
       Expression<Func<Presentacion, bool>>? filter = null,
       params Expression<Func<Presentacion, object>>[] includes);
        Task<Presentacion> Create(Presentacion presentacion);
        Task Update(Presentacion presentacion);
        Task Delete(Presentacion presentacion);
    }
}