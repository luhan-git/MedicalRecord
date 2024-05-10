using MedicalRecord_API.Models;

namespace MedicalRecord_API.Repository.Interfaces
{
    public interface IProcedimientoRepository : IGenericRepository<Procedimientos>
    {
        Task<int> Create(Procedimientos entity);
        Task Update(Procedimientos entity);
    }
}
