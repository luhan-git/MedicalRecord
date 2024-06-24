using MedicalRecord_API.Models;
using System.Linq.Expressions;

namespace MedicalRecord_API.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> Create(Usuario usuario);
        Task<Usuario> GetById(int id);
        Task<IEnumerable<Usuario>> List();
        Task<bool> IsUserUnique(string correo);

    }
}