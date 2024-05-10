using MedicalRecord_API.Models;
using Microsoft.VisualBasic.FileIO;

namespace MedicalRecord_API.Repository.Interfaces
{
    public interface IUbicacionRepository:IGenericRepository<Ubicacion>
    {
        Task<int> Create(Ubicacion entity);
        Task Update (Ubicacion entity);
    }
}
