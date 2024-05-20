using MedicalRecord_API.Models;
using MedicalRecord_API.Repository.Interfaces;
using MedicalRecord_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;

namespace MedicalRecord_API.Repository.Implements
{
    public class UsuarioRepositoy : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly DbhistoriasContext _context;
        private readonly IUtilsService _utilsService;
        private readonly ILogger<UsuarioRepositoy> _logger;
        public UsuarioRepositoy(DbhistoriasContext context, IUtilsService utilsService, ILogger<UsuarioRepositoy> logger) : base(context)
        {

            _context = context;
            _utilsService = utilsService;
            _logger = logger;
        }

        public async Task<Usuario> Create(Usuario entity)
        { 
            try
            {
            
                await _context.Database.ExecuteSqlRawAsync("CALL sp_InsertUsuario(@nombre, @correo, @clave, @cargo, @especialidad, @nroColMedico)",
                                                           new MySqlParameter("@nombre", entity.Nombre),
                                                           new MySqlParameter("@correo", entity.Correo),
                                                           new MySqlParameter("@clave",  entity.Clave),
                                                           new MySqlParameter("@cargo", entity.Cargo),
                                                           new MySqlParameter("@especialidad", entity.Especialidad),
                                                           new MySqlParameter("@nroColMedico", entity.NroColMedico)
                                                           );
                _logger.LogWarning("Se creo un nuevo usuario en la base de datos");
                return await _context.Set<Usuario>().FirstOrDefaultAsync(u => string.Equals(u.Correo, entity.Correo)) ?? new();
            }
            catch (Exception)
            {
                _logger.LogError("Error creando un usuario");
                throw;
            }
        }

        public async Task Update(Usuario entity)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync("CALL sp_UpdateUsuario(@idUpdate,@nombre, @correo, @cargo, @especialidad, @nroColMedico,@activo)",
                                                           new MySqlParameter("@idUpdate", entity.Id),
                                                           new MySqlParameter("@nombre", entity.Nombre),
                                                           new MySqlParameter("@correo", entity.Correo),
                                                           new MySqlParameter("@cargo", entity.Cargo),
                                                           new MySqlParameter("@especialidad", entity.Especialidad),
                                                           new MySqlParameter("@nroColMedico", entity.NroColMedico),
                                                           new MySqlParameter("@activo", entity.Activo)
                                                           );
                _logger.LogWarning("Se actualizó un usuario con id: {id} en la base de datos", entity.Id);

            }
            catch (Exception)
            {
                _logger.LogError("Error actualizando un usuario");
                throw;
            }
        }

        public async Task<bool> ChangePassword(Usuario usuario)
        {
            try
            {
                _context.Set<Usuario>().Update(usuario);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
