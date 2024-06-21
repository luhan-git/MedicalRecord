using MedicalRecord_API.Models;
using System.Linq.Expressions;

namespace MedicalRecord_API.Services.Interfaces
{
    public interface IDetalleAlergiaService
    {
        Task<IQueryable<Detallealergia>> Query(Expression<Func<Detallealergia, bool>>? filters = null);
    }
}
