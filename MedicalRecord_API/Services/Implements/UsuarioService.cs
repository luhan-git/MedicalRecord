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
         private readonly IMapper _mapper;
          private readonly string? _secretkey;
        public UsuarioService(IUsuarioRepository repo,IConfiguration configuration,IMapper mapper)
        {
            _secretkey = configuration.GetValue<string>("ApiSettings:Secret");
            _repo=repo;
            _mapper=mapper;
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

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            Usuario usuario = await _repo.GetAsync(u => string.Equals(u.Correo, loginRequestDto.Correo)
                                                && string.Equals(u.Clave, loginRequestDto.Password));
            if (usuario == null)
                return new();
            if(_secretkey==null)return new();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key=Encoding.UTF8.GetBytes(_secretkey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new(ClaimTypes.Name, usuario.Id.ToString()),
                    new(ClaimTypes.Role, usuario.Rol)
                ]),
                Expires= DateTime.UtcNow.AddDays(7),
                SigningCredentials=new(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDto loginResponseDto = new()
            {
                Token = tokenHandler.WriteToken(token),
                Usuario = _mapper.Map<UsuarioDto>(usuario)

            };
            return loginResponseDto;
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