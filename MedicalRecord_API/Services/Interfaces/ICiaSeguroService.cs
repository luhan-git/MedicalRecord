using MedicalRecord_API.Models;
using System.Linq.Expressions;

namespace MedicalRecord_API.Services.Interfaces
{
    public interface ICiaSeguroService
    {
        Task<Ciaseguro> GetAsync(Expression<Func<Ciaseguro, bool>> filters, bool tracked = true);
        Task<IEnumerable<Ciaseguro>> QueryAsync(Expression<Func<Ciaseguro, bool>>? filter = null,
                                            params Expression<Func<Ciaseguro, object>>[] Includes);
        Task<Ciaseguro> Create(Ciaseguro entity);
        Task Update(Ciaseguro entity);
        Task Delete(Ciaseguro seguro);
    }
}
