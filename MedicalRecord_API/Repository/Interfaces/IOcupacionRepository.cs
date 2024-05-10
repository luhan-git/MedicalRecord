using MedicalRecord_API.Models;

namespace MedicalRecord_API.Repository.Interfaces
{
    public interface IOcupacionRepository
    {
        Task<int> Create(Ocupacion entity);
        Task Update(Ocupacion entity);
    }
}
