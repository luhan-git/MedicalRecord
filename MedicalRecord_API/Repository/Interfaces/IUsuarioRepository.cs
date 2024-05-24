using MedicalRecord_API.Models;
using MedicalRecord_API.Models.Dtos.Usuario;

namespace MedicalRecord_API.Repository.Interfaces
{
    public interface IUsuarioRepository:IGenericRepository<Usuario>
    {
        Task<bool>IsUserUnique(string correo);
        Task<LoginResponseDto>Login(LoginRequestDto loginRequestDto);
        Task <Usuario>Create(Usuario entity);
        Task Update(Usuario entity);
    }
}
