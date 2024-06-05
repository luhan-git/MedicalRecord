using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using MedicalRecord_API.Models;
using MedicalRecord_API.Models.Dtos.Usuario;
using MedicalRecord_API.Repository.Interfaces;
using MedicalRecord_API.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;

namespace MedicalRecord_API.Services.Implements
{
    public class UsuarioService : IUsuarioService
    {
         private readonly IUsuarioRepository _repo;

        public UsuarioService(IUsuarioRepository repo)
        {
            _repo=repo;
        }
        public async Task<Usuario> Create(Usuario usuario)
        {
            usuario= await _repo.Create(usuario);
            return usuario;
        }

        public async  Task Delete(Usuario usuario)
        {
            await _repo.Delete(usuario);
        }

        public async Task<Usuario> GetAsync(Expression<Func<Usuario, bool>> filters, bool tracked = true)
        {
           Usuario usuario=await _repo.GetAsync(filters,tracked);
            return usuario;
        }

        public async Task<bool> IsUserUnique(string correo)
        {
             Usuario usuario =await _repo.GetAsync(u=> string.Equals(u.Correo,correo));
            bool band = usuario == null;
            return band;
        }

        public async Task<IEnumerable<Usuario>> QueryAsync(Expression<Func<Usuario, bool>>? filter = null, params Expression<Func<Usuario, object>>[] Includes)
        {
            IEnumerable<Usuario> usuarios =await _repo.QueryAsync(filter,Includes);
            return usuarios.ToList();
        }

        public async Task Update(Usuario usuario)
        {
            Usuario actual= await _repo.GetAsync(u=> u.Id==usuario.Id,false);
            usuario.Clave??=actual.Clave;
            usuario.Correo??=actual.Correo;
            usuario.FechaActualizacion= DateTime.Now;                                
            await _repo.Update(usuario);
        }
    }
}