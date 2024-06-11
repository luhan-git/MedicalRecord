using MedicalRecord_API.Models;

namespace MedicalRecord_API.Repository.Interfaces
{
    public interface IPresentacionRepository : IGenericRepository<Presentacion>
    {
        Task<Presentacion> Create(Presentacion entity);
        Task Update(Presentacion entity);
    }
}
