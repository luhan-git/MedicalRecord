using MedicalRecord_API.Models;

namespace MedicalRecord_API.Repository.Interfaces
{
    public interface IExamenLaboratorio
    {
        Task<int> Create(Examenlaboratorio entity);
        Task Update(Examenlaboratorio entity);
    }
}
