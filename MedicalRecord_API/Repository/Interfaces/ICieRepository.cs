using MedicalRecord_API.Models;

namespace MedicalRecord_API.Repository.Interfaces
{
    public interface ICieRepository:IGenericRepository<Cie>
    {
        Task<int> Create(Cie entity);
        Task Update(Cie entity);
    }
}
