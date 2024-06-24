using MedicalRecord_API.Models;

namespace MedicalRecord_API.Services.Interfaces
{
    public interface IUbicacionService
    {
        Task<IEnumerable<Departamento>> Departamentos();
        Task<IEnumerable<Provincia>>Provincias(int id);
        Task<IEnumerable<Distrito>> Distritos(int id);
    }
}
