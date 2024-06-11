using MedicalRecord_API.Models;

namespace MedicalRecord_API.Repository.Interfaces
{
    public interface IPacienteRepository : IGenericRepository<Paciente>
    {
        Task<Paciente> Create(Paciente entity);
        Task Update(Paciente entity);
    }
}
