using MedicalRecord_API.Models;

namespace MedicalRecord_API.Repository.Interfaces
{
    public interface IDirectorioRepository : IGenericRepository<Directorio>
    {
        Task<int> Create(Directorio entity);
        Task Update(Directorio entity);
    }
}
