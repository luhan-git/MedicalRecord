using MedicalRecord_API.Models;

namespace MedicalRecord_API.Repository.Interfaces
{
    public interface IUsuarioRepository:IGenericRepository<Usuario>
    {
        Task<int>Create(Usuario entity);
        Task Update(Usuario entity);
    }
}
