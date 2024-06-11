using MedicalRecord_API.Models;

namespace MedicalRecord_API.Repository.Interfaces
{
    public interface ILaboratorioRepository : IGenericRepository<Laboratorio>
    {
        Task<Laboratorio> Create(Laboratorio entity);
        Task Update(Laboratorio entity);
    }
}