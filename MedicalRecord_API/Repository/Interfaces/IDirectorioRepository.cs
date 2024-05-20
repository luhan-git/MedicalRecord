using MedicalRecord_API.Models;

namespace MedicalRecord_API.Repository.Interfaces
{
    public interface IDirectorioRepository : IGenericRepository<Directorio>
    {
        Task<Directorio> Create(Directorio entity);
        Task Update(Directorio entity);
    }
}
