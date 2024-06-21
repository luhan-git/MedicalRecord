using MedicalRecord_API.Models;
using MedicalRecord_API.Repository;
using MedicalRecord_API.Services.Interfaces;
using System.Linq.Expressions;

namespace MedicalRecord_API.Services.Implements
{
    public class DetalleAlergiaService : IDetalleAlergiaService
    {
        private readonly IGenericRepository<Detallealergia> _repo;
        public DetalleAlergiaService(IGenericRepository<Detallealergia> repo)
        {
            _repo = repo;
        }
        public async Task<IQueryable<Detallealergia>> Query(Expression<Func<Detallealergia, bool>>? filters = null)
        {
            IQueryable<Detallealergia> query = await _repo.Query(filters);
            return query;
        }
    }
}
