using MedicalRecord_API.Models;

namespace MedicalRecord_API.Repository.Interfaces
{
    public interface IProcedimientoRepository : IGenericRepository<Procedimiento>
    {
        Task<int> Create(Procedimiento entity);
        Task Update(Procedimiento entity);
    }
}
