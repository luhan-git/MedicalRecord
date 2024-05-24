using AutoMapper;
using MedicalRecord_API.Models;
using MedicalRecord_API.Models.Dtos.Usuario;
using MedicalRecord_API.Repository.Interfaces;
using MedicalRecord_API.Utils.Recursos.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.IdentityModel.Tokens;
using MySqlConnector;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MedicalRecord_API.Repository.Implements
{
    public class UsuarioRepositoy : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly DbhistoriasContext _context;
        private readonly ILogger<UsuarioRepositoy> _logger;
        private readonly IMapper _mapper;
        private string _secretkey;
        public UsuarioRepositoy(DbhistoriasContext context, ILogger<UsuarioRepositoy> logger,IMapper mapper,IConfiguration configuration) : base(context)
        {

            _context = context;
            _mapper = mapper;
            _secretkey = configuration.GetValue<string>("apiSetting:Secret");
            _logger = logger;
        }
        public async Task<Usuario> Create(Usuario entity)
        {
            try
            {

                await _context.Database.ExecuteSqlRawAsync("CALL sp_InsertUsuario(@nombre, @correo, @clave, @cargo, @especialidad, @nroColMedico,@rol)",
                                                           new MySqlParameter("@nombre", entity.Nombre),
                                                           new MySqlParameter("@correo", entity.Correo),
                                                           new MySqlParameter("@clave", entity.Clave),
                                                           new MySqlParameter("@cargo", entity.Cargo),
                                                           new MySqlParameter("@especialidad", entity.Especialidad),
                                                           new MySqlParameter("@nroColMedico", entity.NroColMedico),
                                                           new MySqlParameter("@rol",entity.Rol)
                                                           );   
                _logger.LogWarning("Se creo un nuevo usuario en la base de datos");
               Usuario usuario= await _context.Set<Usuario>().FirstOrDefaultAsync(u => string.Equals(u.Correo, entity.Correo)) ?? new();
                usuario.Clave = "";
                return usuario;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en create usuario");
                throw;
            }
        }

        public async Task<bool> IsUserUnique(string correo)
        {
            Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(u=> string.Equals(u.Correo, correo));
            if(usuario == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(u => string.Equals(u.Correo, loginRequestDto.Correo)
                                                                          && string.Equals(u.Clave, loginRequestDto.Password));
            if (usuario == null)
                return new LoginResponseDto();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key=Encoding.UTF8.GetBytes(_secretkey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.Name, usuario.Id.ToString()),
                    new(ClaimTypes.Role, usuario.Rol)
                }),
                Expires= DateTime.UtcNow.AddDays(7),
                SigningCredentials=new(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDto loginResponseDto = new()
            {
                Token = tokenHandler.WriteToken(token),
                UsuarioDto = _mapper.Map<UsuarioDto>(usuario)

            };
            return loginResponseDto;
        }

        public async Task Update(Usuario entity)
        {
            try
            {
                entity.Clave ??= await _context.Set<Usuario>()
                                                .Where(u => u.Id == entity.Id)
                                                .Select(u => u.Clave)
                                                .FirstOrDefaultAsync();


                await _context.Database.ExecuteSqlRawAsync("CALL sp_UpdateUsuario(@idUpdate,@nombre, @correo, @clave,@cargo, @especialidad, @nroColMedico,@activo)",
                                                           new MySqlParameter("@idUpdate", entity.Id),
                                                           new MySqlParameter("@nombre", entity.Nombre),
                                                           new MySqlParameter("@correo", entity.Correo),
                                                           new MySqlParameter("@clave", entity.Clave),
                                                           new MySqlParameter("@cargo", entity.Cargo),
                                                           new MySqlParameter("@especialidad", entity.Especialidad),
                                                           new MySqlParameter("@nroColMedico", entity.NroColMedico),
                                                           new MySqlParameter("@activo", entity.Activo)
                                                           );
                _logger.LogWarning("Se actualizó un usuario con id: {id} en la base de datos", entity.Id);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en update usuario");
                throw;
            }
        }
    }
}
