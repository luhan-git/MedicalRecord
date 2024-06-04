using MedicalRecord_API.Models;
using MedicalRecord_API.Models.Dtos.Usuario;

namespace MedicalRecord_API.Repository.Interfaces
{
    public interface IUsuarioRepository:IGenericRepository<Usuario>
    {
        Task <Usuario>Create(Usuario entity);
        Task Update(Usuario entity);
    }
}
