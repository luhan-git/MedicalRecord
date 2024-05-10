using MedicalRecord_API.Models;

namespace MedicalRecord_API.Repository.Interfaces
{
    public interface ICiaSegurosRepository : IGenericRepository<CiaSeguros>
    {
        Task<int> Create(CiaSeguros entity);
        Task Update(CiaSeguros entity);
    }
}
