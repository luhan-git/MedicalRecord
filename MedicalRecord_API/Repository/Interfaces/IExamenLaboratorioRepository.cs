using MedicalRecord_API.Models;

namespace MedicalRecord_API.Repository.Interfaces
{
    public interface IExamenLaboratorioRepository:IGenericRepository<Examenlaboratorio>
    {
        Task<Examenlaboratorio> Create(Examenlaboratorio entity);
        Task Update(Examenlaboratorio entity);
    }
}
