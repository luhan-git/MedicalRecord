using MedicalRecord_API.Models;
using MedicalRecord_API.Repository;
using MedicalRecord_API.Services.Interfaces;
using System.Linq.Expressions;

namespace MedicalRecord_API.Services.Implements
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGenericRepository<Usuario> _repo;
        private readonly IUtilsService _encryt;
        public UsuarioService(IGenericRepository<Usuario> repo,IUtilsService encrypt)
        {
            _repo = repo;
            _encryt = encrypt;
        }

        public async Task<Usuario> Create(Usuario usuario)
        {
            usuario.Clave= _encryt.ConvertirSha256(usuario.Clave);
            usuario = await _repo.Create(usuario);
            return usuario;
        }

        public async Task<IEnumerable<Usuario>> List()
        {
            IEnumerable<Usuario>usuarios = await _repo.QueryAsync();
            return usuarios;
        }

        public async Task<Usuario> GetById(int id)
        {
            Usuario usuario= await _repo.GetAsync(u => u.Id == id);
            return usuario;
        }

        public async Task<bool> IsUserUnique(string correo)
        {
            Usuario usuario = await _repo.GetAsync(u => string.Equals(u.Correo, correo));
            bool isUniq = usuario == null;
            return isUniq;
        }
    }
}